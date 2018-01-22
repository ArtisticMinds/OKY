using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class W_GemManager : MonoBehaviour {

    public string GemURL;
    public static W_GemManager _istance;
    public int PlayerGems;
    Text _InGameGemText;
    Text _InMenuGemText;
    public GameObject _OffLineGems;
    public static bool GetedGemsDeleted;
    public GemItem[] gemIntheScene;

    void Awake () {

                if (_istance != null)
        {
            Destroy(transform.root.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(transform.root.gameObject);
            _istance = this;
        }

        SceneManager.sceneLoaded += OnSceneWasLoaded;
        GetedGemsDeleted = false;
        GemStatusUpdate();
    }

    void OnSceneWasLoaded(Scene previousScene, LoadSceneMode loadSceneMode)
    {


        if (GameManager.Level != 1)
        { //Se non è il menu ma un livello del gioco
            _InGameGemText = GameObject.Find("_gems").GetComponent<Text>();
             gemIntheScene = FindObjectsOfType<GemItem>();
        }
        else 
            {
             _InMenuGemText = GameObject.Find("_MenuGems").GetComponent<Text>();
            _OffLineGems= GameObject.Find("_OffLineGems");

            if (GameManager.Instance.PrimoAvvio)
            {
                Invoke("AddInitialGems", 2);
            }
               

        }

        Invoke("UpdateData", 3);

        InvokeRepeating("GemStatusUpdate",3,3);

        DeleteGetedGemsInThisLevel(false);//Nel gioco, elimina fisicamente le gemme già raccolte dal livello
    }

    void AddInitialGems() {
            AddGems(GameManager.Instance.NewUserGems);//Aggiunge gemme iniziali
    }


    //Ad ogni caricamento di scena
    public void UpdateData() {
        
        print("W_GemManager UpdateData");
        if (!Social.localUser.authenticated || Application.internetReachability == NetworkReachability.NotReachable)
        {

            //NO CONNECTION

            DeleteGetedGemsInThisLevel(true);//Nel gioco, con true come parametro elimina fisicamente tutte le gemme dal livello (perchè non connesso)

            print("<color=#FF0000>NO INTERNET CONNECTION or NO USER AUTHENTICATED: User authenticated=" + Social.localUser.authenticated + " Social authenticated= " + Social.localUser.authenticated + "</color>");
            if (_OffLineGems) _OffLineGems.SetActive(true);
            GemStatusUpdate();
            return;
        }
        else
        {
            DeleteGetedGemsInThisLevel(false);//Nel gioco, elimina fisicamente le gemme già raccolte dal livello
            StartCoroutine(GetPlayerGemsFromDatabase()); //Prende le gemme del Player dal database
            if (_OffLineGems) _OffLineGems.SetActive(false);
            GemStatusUpdate();
        }

     
    }


    void OnDestroy()
    {

        SceneManager.sceneLoaded -= OnSceneWasLoaded;

    }



    public void AddGems(int numGems)
    {

        StartCoroutine(AddGemsToDatabase(numGems));//Aggiungo value a quelle inviate aggiornando sul database
        GemStatusUpdate();
    }

    //Chiamato dal pulsante
    public void ResumeWithGems() {

        if(GameManager.LastCheckPoint != Vector3.zero)//Se esiste un punto di Respawn
        if (PlayerGems > 0) { //Se ho almeno una gemma
           StartCoroutine(RemoveGemsFromDatabase(1));//Toglie una gemma dal database
            GameManager.Instance.ReSpawnOky();
                GemStatusUpdate();
            return;
        }


        GemStatusUpdate();
    }

    // Invia il nuovo Numero di gemme sul databse (getData=SetGems)
    IEnumerator RemoveGemsFromDatabase(int numGems)
    {
        print("<color=white>  SetGems: \nnumGems:" + numGems+"</color>");
        if (Social.localUser.authenticated && Application.internetReachability != NetworkReachability.NotReachable)
        {

            yield return StartCoroutine(GetPlayerGemsFromDatabase());//Prendo le gemme già presenti nel databse (da questo punto PlayerGems è preso da WWW)

            print("<color=white> Numero Gemme nel Databse:" + PlayerGems + "</color>");

            int SetGem = PlayerGems - numGems; //rimuovo quelle inviate alla funzione

            print("<color=white> Nuovo numeroGems da postare sul Database:" + SetGem + "</color>");

            //Spedisco sul database il numero aggiornato
            string post_url = GemURL + "accesskey=" + SocialConnection.AccessKey + "&nickname=" + Social.localUser.userName + "&UserID=" + SocialConnection.UserID + "&DeviceID=" + SystemInfo.deviceUniqueIdentifier + "&getdata=SetGems" + "&SetGems=" + SetGem;

            // Post the URL to the site and create a download object to get the result.
            WWW hs_post = new WWW("http://" + post_url);
            yield return hs_post; // Wait until the download is done

            //Aggiorno la variabile PlayerGems
            PlayerGems = SetGem;

            print("<color=white> NumeroGems aggiornate:" + PlayerGems + "</color>");


            if (numGems > 0 && GameUI.Instance)
            {  //Visualizza ogni volta che vengono aggiunte delle gemme durante un livello
                GameUI.Instance._AddGemsUI.GetComponentInChildren<Text>(true).text = ("-" + numGems + "!");//Setta la UI
                GameUI.Instance._AddGemsUI.SetActive(true);//Visualizza la UI
            }


            if (hs_post.error != null)
            {
                print("There was an error posting the high score: " + hs_post.error);
            }
            else
            {
                print("< color = white > GEMS ADDED</color>" + post_url);
            }

        }

        GemStatusUpdate();
    }


    // Invia il nuovo Numero di gemme sul databse (getData=SetGems)
    IEnumerator AddGemsToDatabase(int numGems)
    {

        print("<color=white>  SetGems: \nnumGems:" + numGems+ "</color>");
        if (Social.localUser.authenticated && Application.internetReachability != NetworkReachability.NotReachable)
        {
            
            yield return StartCoroutine(GetPlayerGemsFromDatabase());//Prendo le gemme già presenti nel databse (da questo punto PlayerGems è preso da WWW)

            print("<color=white> Numero Gemme nel Databse:" + PlayerGems + "</color>");

            int SetGem = PlayerGems+numGems; //aggiungo quelle inviate alla funzione

            print("<color=white> Nuovo numeroGems da postare sul Database:" + SetGem);

            //Spedisco sul database il numero aggiornato
            string post_url = GemURL + "accesskey=" + SocialConnection.AccessKey + "&nickname=" + Social.localUser.userName+ "&UserID=" + SocialConnection.UserID + "&DeviceID=" + SystemInfo.deviceUniqueIdentifier + "&getdata=SetGems" + "&SetGems=" + SetGem;

            // Post the URL to the site and create a download object to get the result.
            WWW hs_post = new WWW("http://" + post_url);
            yield return hs_post; // Wait until the download is done

            //Aggiorno la variabile PlayerGems
            PlayerGems = SetGem;

            print("<color=white> NumeroGems aggiornate:" + PlayerGems + "</color>");


            if (numGems > 0&& GameUI.Instance)
            {  //Visualizza ogni volta che vengono aggiunte delle gemme durante un livello
                GameUI.Instance._AddGemsUI.GetComponentInChildren<Text>(true).text = ("+" + numGems + "!");//Setta la UI
                GameUI.Instance._AddGemsUI.SetActive(true);//Visualizza la UI
            }
            

            if (hs_post.error != null)
            {
                print("There was an error posting the high score: " + hs_post.error);
            }
            else
            {
                print("< color = white > GEMS ADDED</color>" + post_url);
            }

        }

        GemStatusUpdate();
    }




    //Ritorna le gemme salvate 
    IEnumerator GetPlayerGemsFromDatabase()
    {
        if (Social.localUser.authenticated && Application.internetReachability != NetworkReachability.NotReachable)
        {

            //Qui getFromWWW
            string post_url = GemURL + "accesskey=" + SocialConnection.AccessKey + "&nickname=" + Social.localUser.userName + "&UserID=" + SocialConnection.UserID + "&DeviceID=" + SystemInfo.deviceUniqueIdentifier + "&getdata=getGems";

            // Post the URL to the site and create a download object to get the result.
            WWW hs_post = new WWW("http://" + post_url);
            yield return hs_post; // Wait until the download is done
            string PlayerGemsFromWWW = hs_post.text;

            bool ConvertOK=int.TryParse(PlayerGemsFromWWW,out PlayerGems); //Segna il valore da Web su PlayerGems
            print(ConvertOK + "PlayerGems:"+ PlayerGemsFromWWW);

            if (GameManager.Level != 1)
                GameManager.m_Character.CheckResumePossibility();

        }
        else { GameUI.Instance.ResumeUseGems1.interactable = GameUI.Instance.ResumeUseGems2.interactable = false; }

        GemStatusUpdate();
    }


    //Cerca nel PlayerPref le Gemme che sono nel livello
    //Se le trova, le canancella.
   public void DeleteGetedGemsInThisLevel(bool All)
    {
       // GemItem[] gemIntheScene = FindObjectsOfType<GemItem>();

        //Per ora è 100, ovvero il numero massimo di gemme (numeroID) che penso che metterò mai nel gioco
        for (int i = 0; i < 100; i++)
        {

            if (All)
            {
                foreach (GemItem gemInScene in gemIntheScene)
                {
                    if (gemInScene)
                        Destroy(gemInScene.gameObject); //Se non connesso, distruggi qualisiasi Gemma dal livello

                }
                
                return;
            }
            else
            {
                if (PlayerPrefs.HasKey(GameManager.Instance.AppName + "_GemsIDGeted_" + i))
                    foreach (GemItem gemInScene in gemIntheScene)
                    {

                        if (i == gemInScene.GemID)//Se connesso distruggi solo quelle già raccolte
                          if(gemInScene)
                                Destroy(gemInScene.gameObject);
                    }
            }
    }

        GemStatusUpdate();
        GetedGemsDeleted = true; //Segnalo il controllo eseguito
        }


   public void GemStatusUpdate()
    {
        if (Social.localUser.authenticated && //Autenticato
            Application.internetReachability != NetworkReachability.NotReachable && CheckInternetConnection.IsOnline && //Internet connesso
        !SocialConnection.NoCorrectDeviceID) //Device corretto
        {
            if (_InGameGemText) _InGameGemText.text = PlayerGems.ToString(); //Aggiorna il testo a schermo
            if (_InMenuGemText) _InMenuGemText.text = PlayerGems.ToString(); //Aggiorna il testo a schermo
            if (_OffLineGems) _OffLineGems.SetActive(false);
        }
        else
        {
            //PlayerGems = 0;
            if (_InGameGemText) _InGameGemText.text = "--"; //Aggiorna il testo a schermo
            if (_InMenuGemText) _InMenuGemText.text = "--"; //Aggiorna il testo a schermo
            if (_OffLineGems) _OffLineGems.SetActive(true);
            
        }


    }



    public void BuySkin(int SkinID,int Cost) {

            if (PlayerGems >= Cost)
             { //Se ho almeno Cost gemme
            StartCoroutine(RemoveGemsFromDatabase(Cost));//Toglie le gemme (Cost) dal database
            GemStatusUpdate();
                PlayerPrefs.SetInt(GameManager.Instance.AppName + "Skin" + SkinID, 1); //Salva sul PlayerPref un dato (il numero è indifferente)
                return;
        }
        else { MainMenu.ShowNoGemsMessage(); }


        GemStatusUpdate();
    }

    public void UnlockAllLevels() {

        if (PlayerGems >= 100)
        { //Se ho almeno 100 gemme
            StartCoroutine(RemoveGemsFromDatabase(100));//Toglie le gemme (100) dal database
            GemStatusUpdate();
            PlayerPrefs.SetInt(GameManager.Instance.AppName + "_AllLevelsOpen", 1); //Salva sul PlayerPref un dato (il numero è indifferente)
            WorldLevelsPanel.AllLevelsOpen = true;
          
            MainMenu.OpenAllLevelsPanel.SetActive(false);
            MainMenu.AllLevelsOpened.SetActive(true);
            MainMenu.AcquistatoIcon.SetActive(WorldLevelsPanel.AllLevelsOpen);
            if (MainMenu.AcquistatoIcon.GetComponentInParent<Button>())
                MainMenu.AcquistatoIcon.GetComponentInParent<Button>().interactable = !WorldLevelsPanel.AllLevelsOpen;
            return;
        }
        else {
            MainMenu.OpenAllLevelsPanel.SetActive(false);
            MainMenu.ShowNoGemsMessage();
        }


        GemStatusUpdate();

    }


    public void UnlockBonusLevel(int LevelNumber)
    {

        if (PlayerGems >= 10)
        { //Se ho almeno 10 gemme
            StartCoroutine(RemoveGemsFromDatabase(10));//Toglie le gemme (10) dal database
            GemStatusUpdate();
           PlayerPrefs.SetInt(GameManager.Instance.AppName + "_BonusOpen_" + LevelNumber.ToString(),1);//Salva sul PlayerPref un dato (il numero è indifferente)


            MainMenu.UnlockBonusLEvelDialog.SetActive(false);
            MainMenu.UpdateAllSceneItems();
            //MainMenu.AllLevelsOpened.SetActive(true);
            //MainMenu.AcquistatoIcon.SetActive(WorldLevelsPanel.AllLevelsOpen);
            //if (MainMenu.AcquistatoIcon.GetComponentInParent<Button>())
            //    MainMenu.AcquistatoIcon.GetComponentInParent<Button>().interactable = !WorldLevelsPanel.AllLevelsOpen;
            return;
        }
        else
        {
            MainMenu.ShowNoGemsMessage();
        }


        GemStatusUpdate();

    }
}





