
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using GooglePlayGames.BasicApi;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

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

    void Awake() {
        ClearTextsData();
    }

    void OnEnable()
    {
        if (!_preloader) _preloader = preloader;
        if (!Social.localUser.authenticated && Application.internetReachability != NetworkReachability.NotReachable) {//Non autenticato ma con connessione
          if(thisWorld=="0")  SocialConnection.instance.LogIn(); //Solo una volta
        }
        else
        {

            print("Authenticated:" + Social.localUser.authenticated + " Connection: " + Application.internetReachability);
        }

        ClearTextsData();//cancella tutti i testi
        if (!SocialConnection.NoCorrectDeviceID)
        {

            UpdateAllWebData(false);
            Invoke("DeactivatePreloader", 5);
        }
        else { print("No correct Device!"); SocialConnection.instance.OnLogOut(); }
    }


    public void UpdateAllWebData(bool activateGameObject)
    {
        if (!CheckInternetConnection.IsOnline) return;
        if (SocialConnection.NoCorrectDeviceID)
        {
            print("No correct Device!");
            SocialConnection.instance.OnLogOut();
            return;
        }

        if (activateGameObject)
        {
            MainMenu.HighScorePanel.SetActive(true);
            MainMenu.HighScorePanel.GetComponent<CanvasGroup>().alpha = 0;
            MainMenu.HighScorePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        StartCoroutine(ShowPlayerWorldScores(activateGameObject));//Prende punteggio (facendo il confronto tra(PlayerPref e database))
        if (Application.internetReachability != NetworkReachability.NotReachable && Social.localUser.authenticated )
        {
            StartCoroutine(GetWebData("PlayerRank"));//Prende dati da Web
            StartCoroutine(GetWebData("PlayersNumber"));//Prende dati da Web
            StartCoroutine(GetWebData("FirstFive"));//Prende dati da Web
            StartCoroutine(GetWebData("FirstFiveScores"));//Prende dati da Web
        }




        print("WebDataUpdated");
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
        UserName.text = "-";
        UserScore.text = "---";
    }


    IEnumerator ShowPlayerWorldScores(bool activateGameObject)
    {
        if(!CheckInternetConnection.IsOnline) yield return null;
           WorldPoints =0;
        // Parte off-line sul dispositivo
        UserName.text = SocialConnection.UserName;//Aggiorno il nickName
        if (PlayerPrefs.HasKey(GameManager.Instance.AppName + thisWorld + "_WorldPoints"))
        WorldPoints=  PlayerPrefs.GetInt(GameManager.Instance.AppName + thisWorld + "_WorldPoints"); //Punti Totali del mondo thisWorld (qui lo prende dal PlayerPref, non on.line)

        if (Application.internetReachability != NetworkReachability.NotReachable)//Se c'è la connessione, fai il confornto
        {

            string post_url = LeaderboadrsURL + "&accesskey=" + SocialConnection.AccessKey + "&UserID=" + SocialConnection.UserID + "&world=" + thisWorld + "&getdata=getWorldScore" + "&DeviceID=" + SystemInfo.deviceUniqueIdentifier;

            // Post the URL to the site and create a download object to get the result.
            WWW hs_post = new WWW("http://" + post_url);
            yield return hs_post; // Wait until the download is done
            string WebPoints=hs_post.text;
            //Comparazione dei due punteggi
            WorldPoints= ScoresComparation(WorldPoints, System.Int32.Parse(WebPoints));//Dopo questo metodo WorldPoints sarà aggiornato
        }

        PlayerPrefs.SetInt(GameManager.Instance.AppName + thisWorld + "_WorldPoints",WorldPoints); //Risalva sul PlayerPref, dopo la comparazione)
        UserScore.text = WorldPoints.ToString();

       yield return UserScore.text; //Dato dal PlayerPref


        StartCoroutine(SendWorldScore(activateGameObject));//Risalva il dato on-line inviando quello del PlayerPref (dopo la comparazione con quello on-line)
        print("WorldPoints for World "+ thisWorld+": "+UserScore.text);

        //Dopo l'aggiornamento dei punteggi, aggiorna tutto riscaricando da WEB le leaderboards
        if (Application.internetReachability != NetworkReachability.NotReachable && Social.localUser.authenticated )
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

        print("ScoresComparation: FromPlayerPref =" + fromPlayerPref+ "FormWeb =" + FormWeb);
        if (fromPlayerPref > FormWeb)
            return fromPlayerPref;
        else
            return FormWeb;

    }


    // Invia un nuovo record sul databse
    IEnumerator SendWorldScore(bool activateGameObject)
    {

        string post_url = LeaderboadrsURL + "&accesskey=" + SocialConnection.AccessKey + "&UserID=" + SocialConnection.UserID + "&world="+ thisWorld+"&NewScore="+ UserScore.text + "&DeviceID=" + SystemInfo.deviceUniqueIdentifier;

        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW("http://" + post_url);
        yield return hs_post; // Wait until the download is done


        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
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


        _preloader.SetActive(true);

        WWW hs_get = new WWW("http://" + LeaderboadrsURL + "&accesskey=" + SocialConnection.AccessKey + "&UserID=" + SocialConnection.UserID + "&world=" + thisWorld + "&accesskey=" + SocialConnection.AccessKey+ "&getdata="+data + "&DeviceID=" + SystemInfo.deviceUniqueIdentifier);
        yield return hs_get;

        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            if (data == "PlayerRank") { 
                UserRank.text=hs_get.text.Trim()+"."; // this is a GUIText that will display the scores in game.
                print("PlayerRank: " +hs_get.text.Trim()+ " >data:"+ data+"");//Scrivilo in console
            }
            if (data == "PlayersNumber")
                NumberOfPlayers.text = hs_get.text.Trim(); // this is a GUIText that will display the scores in game.
            if (data == "FirstFive")
                PolupateLeaderBoard(hs_get.text.Trim());
            if (data == "FirstFiveScores")
                PolupateScores(hs_get.text.Trim());
        }
        _preloader.SetActive(false);
    }


    void PolupateLeaderBoard(string FirstFiveData) {
        print(FirstFiveData);
        for (int i = 0; i <= 4; i++) 
        UsersNamesUITexts[i].text = FirstFiveData.Split('@')[i];
    }

    void PolupateScores(string FirstFiveScoresData)
    {
        print(FirstFiveScoresData);
        for (int i = 0; i <= 4; i++)
            ScoresUITexts[i].text = FirstFiveScoresData.Split('@')[i];

    }


    void DeactivatePreloader()
    {
        preloader.SetActive(false);
    }



}
