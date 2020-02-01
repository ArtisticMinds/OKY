
using UnityEngine;
//using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
//using GooglePlayGames.BasicApi;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine.Networking;
using System.Net;
using System.Text;

public class W_WorldScores : MonoBehaviour
{

    public string LeaderboadrsURL;
    public string thisWorld;
    public Text[] UsersNamesUITexts;
    public Text[] ScoresUITexts;


    public Text UserName;
    public Text UserScore;
    public Text UserRank;
    public Text NumberOfPlayers;
    public GameObject preloader;
    public static GameObject _preloader;
    public int WorldPoints;

    public static bool enableUpdate; //Per evitare di fare l'update ad ogni OnEnable

    void Awake() {
        ClearTextsData();
        enableUpdate = true;
        if (!_preloader) _preloader = preloader;
    }

    void OnEnable()
    {

        if (enableUpdate)
        {
            _preloader.SetActive(true);
            StartCoroutine(UpdateData());
            Invoke("DeactivatePreloader", 5);
        }


    }

    IEnumerator UpdateData()
    {
        yield return new WaitForSeconds(0.2f);
        if (!_preloader) _preloader = preloader;
        if (!Social.localUser.authenticated && Application.internetReachability != NetworkReachability.NotReachable)
        {//Non autenticato ma con connessione
            if (thisWorld == "0") if (SocialConnection.instance) SocialConnection.instance.LogIn(); //Solo una volta
        }
        else
        {

            print("Authenticated:" + Social.localUser.authenticated + " Connection: " + Application.internetReachability);
        }

        ClearTextsData();//cancella tutti i testi


        UpdateAllWebData(false);
        Invoke("DeactivatePreloader", 5);
        enableUpdate = false; //Si riattiva solo dopo aver giocato un livello
    }

    public void UpdateAllWebData(bool activateGameObject)
    {
        if (!CheckInternetConnection.IsOnline) return;

        if (!agreeUpdate)  return ;
        agreeUpdate = false;

        if (activateGameObject)
        {
            MainMenu.HighScorePanel.SetActive(true);
            MainMenu.HighScorePanel.GetComponent<CanvasGroup>().alpha = 0;
            MainMenu.HighScorePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        StartCoroutine(ShowPlayerWorldScores(activateGameObject));//Prende punteggio (facendo il confronto tra(PlayerPref e database))
        if (Application.internetReachability != NetworkReachability.NotReachable && Social.localUser.authenticated )
        {
            preloader.SetActive(true);
            StartCoroutine(GetWebData("PlayerRank"));//Prende dati da Web
            StartCoroutine(GetWebData("PlayersNumber"));//Prende dati da Web
            StartCoroutine(GetWebData("FirstFive"));//Prende dati da Web
            StartCoroutine(GetWebData("FirstFiveScores"));//Prende dati da Web
        }



        Invoke("ReactivateUpdate", 5);
        //print("WebDataUpdated");
    }

    void ClearTextsData()
    {
        for (int i = 0; i <= 4; i++)
        {
            UsersNamesUITexts[i].text = "---";
            ScoresUITexts[i].text = "---";
        }

        UserRank.text = "---"; // this is a GUIText that will display the scores in game.
        NumberOfPlayers.text = "--";
        UserName.text = " ";
        UserScore.text = "---";
    }


    bool agreeUpdate=true;
    //PLAYER SCORE
    IEnumerator ShowPlayerWorldScores(bool activateGameObject)
    {


        if (!CheckInternetConnection.IsOnline) yield return null;
        WorldPoints = 0;
        // Parte off-line sul dispositivo
        UserName.text = SocialConnection.UserName;//Aggiorno il nickName
        if (PlayerPrefs.HasKey(GameManager.Instance.AppName + thisWorld + "_WorldPoints"))
            WorldPoints = PlayerPrefs.GetInt(GameManager.Instance.AppName + thisWorld + "_WorldPoints"); //Punti Totali del mondo thisWorld (qui lo prende dal PlayerPref, non on.line)
        

            if (Application.internetReachability != NetworkReachability.NotReachable && SocialConnection.UserID != "")//Se c'è la connessione, fai il confornto
            {
                //Link per i worldScore di questo utente
                string post_url = "http://" + LeaderboadrsURL + "&accesskey=" + SocialConnection.AccessKey + "&UserID=" + SocialConnection.UserID + "&world=" + thisWorld + "&getdata=getWorldScore" + "&DeviceID=" + SystemInfo.deviceUniqueIdentifier;
             //   print("User Point URL : " + post_url);
                string hs_get = "";
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                using (WebClient webClient = new WebClient())
                {
                    webClient.Encoding = Encoding.UTF8;
                    hs_get = webClient.DownloadString(post_url);

                }

                yield return hs_get;
                string WebPoints = hs_get.Trim();

                if (WebPoints == "") WebPoints = "0";
              //  print("(User WorldPoints) World:" + thisWorld + " WEB_Points:" + WebPoints);

            //Comparazione dei due punteggi
            if (WebPoints != "")
                    WorldPoints = ScoresComparation(WorldPoints, System.Int32.Parse(WebPoints));//Dopo questo metodo WorldPoints sarà aggiornato
                   PlayerPrefs.SetInt(GameManager.Instance.AppName + thisWorld + "_WorldPoints", WorldPoints); //Risalva sul PlayerPref, dopo la comparazione)
            }

             


        
        UserScore.text = WorldPoints.ToString();

       yield return UserScore.text; //Dato dal PlayerPref


        StartCoroutine(SendWorldScore(activateGameObject));//Risalva il dato on-line inviando quello del PlayerPref (dopo la comparazione con quello on-line)
       // print("This User WorldPoints for World "+ thisWorld+": "+UserScore.text);

        //Dopo l'aggiornamento dei punteggi, aggiorna tutto riscaricando da WEB le leaderboards
        if (Application.internetReachability != NetworkReachability.NotReachable )
        {

                    StartCoroutine(GetWebData("PlayerRank"));//Prende dati da Web

                    StartCoroutine(GetWebData("PlayersNumber"));//Prende dati da Web

                    StartCoroutine(GetWebData("FirstFive"));//Prende dati da Web

                    StartCoroutine(GetWebData("FirstFiveScores"));//Prende dati da Web
            
        }
        
    }

    //Fa la comparazione tra il punteggio on-line e quello nel PlayerPref
    //Se quello on-line è più alto vuol dire che l'utente sta usando un dispositivo
    //diverso (dove non è salvato il punteggio aggiornato) dunque prende quello
    //on-line e lo salva sul PlayerPref. Poi può eseguire il SendWorldScore rinviando
    //il punteggio sul database che sarà comunque sempre aggiornato a quello più alto
    //tra i suoi dispositivi
    int ScoresComparation(int fromPlayerPref,int FormWeb) {

        print("ScoresComparation world "+thisWorld+" - FromPlayerPref = " + fromPlayerPref+ " FormWeb = " + FormWeb);
        if (fromPlayerPref > FormWeb)
            return fromPlayerPref;
        else
            return FormWeb;

    }


    // Invia un nuovo record sul databse
    IEnumerator SendWorldScore(bool activateGameObject)
    {
        if (!Social.localUser.authenticated) yield break;

        string post_url = "https://www."+ LeaderboadrsURL + "&accesskey=" + SocialConnection.AccessKey + "&UserID=" + SocialConnection.UserID + "&world="+ thisWorld+"&NewScore="+ UserScore.text + "&DeviceID=" + SystemInfo.deviceUniqueIdentifier;

        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        string hs_post = "";
        using (WebClient webClient = new WebClient())
        {
            webClient.Encoding = Encoding.UTF8;
            hs_post = webClient.DownloadString(post_url);

        }


        if (hs_post.Contains("Error"))
        {
            print("<color=#AA0000>There was an error posting the high score: </color>" + hs_post);
        }
        else {
            print("NEWSCORE"+post_url);
        }


        if (activateGameObject)
        {
            MainMenu.HighScorePanel.GetComponent<CanvasGroup>().alpha = 1;
            MainMenu.HighScorePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
            MainMenu.HighScorePanel.SetActive(false);

        }

    }




    // Get the scores from the MySQL DB to display in a UIText.
    IEnumerator GetWebData(string data)
    {


        _preloader.SetActive(true); Invoke("DeactivatePreloader", 5);
        string url = "http://" + LeaderboadrsURL  + "&UserID=" + SocialConnection.UserID + "&world=" + thisWorld + "&getdata=" + data ;
        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        string  hs_get = "";
        using (WebClient webClient = new WebClient())
        {
            webClient.Encoding = Encoding.UTF8;
            hs_get = webClient.DownloadString(url);

        }

        yield return hs_get; // Wait until the download is done

       // print("<color=#FFFFFF>GetWebData URL ("+ data+"): </color>"+ url);
       // print("<color=#FFFFFF>ReturnDataText (" + data + "): </color>" + hs_get);
        if (hs_get== null)
        {
            print("<color=#AA0000>There was an error getting the high score:</color> " + hs_get);
        }
        else
        {
            if (data == "PlayerRank")
            {
                UserRank.text = hs_get.Trim() + "."; // this is a GUIText that will display the scores in game.
               // print("<color=#FFFFFF>url: </color>" + url);//Scrivilo in console
               // print("<color=#FFFFFF>PlayerRank: </color>" + hs_get.Trim() );//Scrivilo in console
            }

            if (data == "PlayersNumber") { 
                NumberOfPlayers.text = hs_get.Trim(); // this is a GUIText that will display the scores in game.
          //  print("PlayersNumber: " + hs_get.Trim() );//Scrivilo in console
            }

            if (data == "FirstFive")
            {
              //  print("FirstFive: " + hs_get.Trim() );//Scrivilo in console
                PolupateLeaderBoard(hs_get.Trim());

            }

            if (data == "FirstFiveScores")
            {
              //  print("FirstFiveScores: " + hs_get.Trim() );//Scrivilo in console
                PolupateScores(hs_get.Trim());
            
            }
        }
 
        _preloader.SetActive(false);
    }


    void PolupateLeaderBoard(string FirstFiveData) {
       // print("FirstFiveData: "+FirstFiveData);
        for (int i = 0; i <= 4; i++) 
        UsersNamesUITexts[i].text = FirstFiveData.Split('@')[i];
    }

    void PolupateScores(string FirstFiveScoresData)
    {
       // print(FirstFiveScoresData);
        for (int i = 0; i <= 4; i++)
            ScoresUITexts[i].text = FirstFiveScoresData.Split('@')[i];

    }


    void DeactivatePreloader()
    {
        preloader.SetActive(false);
    }



    void ReactivateUpdate()
    {
        agreeUpdate = true;
    }


}
