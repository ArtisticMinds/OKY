using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour {

    public string AppName = "Oky";
    public static float Diffic = 0.3f;
    public int NewUserGems = 10;
    public GameObject _buildVersion;
    public bool debugMode = false;
    public Vector3 WordGravity = new Vector3(0, -10f, 0);
    public static bool developmentMode;
    public static GameManager Instance;
    public static MainMenu mainMenu;
    public static GameUI gameUI;
    public static float ControlsUIScale = 1.2f;
    public static LevelManager ThisLevelManager;
    public static W_playerController m_Character;
    public static W_UserControl UserControl;
    public static Transform _sapwnPoint;
    public static CameraMovements cameraMovements;
    public static GameObject MiniMenu;
    public static GameObject MiniOptionsMenu;
    public static GameObject _DeadPanel;
    public static GameObject _EndTimePanel;
    public static bool PlayerIsDead;
    public static W_SceneTimer Timer;
    public float CameraDistance;
    public static AudioSource MasterAudioSource;
    public AudioMixer MasterMixer;
    public Slider SoundsVol_Slider;
    public Slider MusicVol_Slider;
    public Slider UIScale_Slider;
    // public Text SizeValue;
    public GameObject _noMusic;
    public GameObject _noSounds;
    public float AudioMultipler = 1;
    public static int Level;
    public static CameraShake cameraShake;
    public static CheckInternetConnection checkInternetConnection;
    public AudioClip ResumeSound;
    public AudioClip dropSound;
    public static bool Respawn;
    /// 
    public bool PrimoAvvio;
    public static bool LevelComplete;
    public static bool Lose;
    [Header("Game Options - (not at runtime)")]
    [Tooltip("La lingua del gioco - NB: non modificabile a runtime ma solo ad inizio scena")]
    public Lang lang = Lang.English;
    public enum Lang
    {
        Italian, English
    }
    public Quality quality = Quality.Hi;
    public enum Quality
    {
        Hi, Med, Low
    }
    [Header("Game State")]
    [Tooltip("Gioco in pausa")]
    public Game_State GameState;
    public static float TimeMultipler = 1;

    public static DateTime DataInizio = new DateTime(2017, 12, 1, 0, 0, 0);
    public static DateTime Oggi = System.DateTime.Now;
    public static int GiorniPassati;

    public enum Game_State
    {
        Pause, Running
    }


    public Texture2D SelectedRexTexture;
    public Texture2D[] RexTextures;

    public static int Star02Points = 1400;
    public static int Star03Points = 2700;
    public static int CrowPoints = 3600;
    public static Vector3 LastCheckPoint;
    public int OldFrameRate;
    public int FrameRate;
    public bool LowFrameRate;
    public bool disableLowFrameRateCheck;
    public bool UseAutoQuality;
    GameObject _PlayerStartPoint;

  

    void Awake() {
        transform.SetParent(null);



        if (Instance != null)
        {
            Destroy(transform.root.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(transform.root.gameObject);
            Instance = this;
        }

        //Nella build togli sempre il debugMode
        if (!Application.isEditor)
        {
            debugMode = false;
    }

        Level = SceneManager.GetActiveScene().buildIndex;

        checkInternetConnection = FindObjectOfType<CheckInternetConnection>();
        mainMenu = FindObjectOfType<MainMenu>();
        MasterAudioSource = GetComponent<AudioSource>();
        Screen.sleepTimeout = (int)0f;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        SceneManager.sceneLoaded += OnSceneWasLoaded;
        MasterAudioSource.priority = 256;
        ReadLanguage();

     

        //Questo awake viene eseguito solo all'inizio e se non si tratta del livello menu
        //vuol dire che è stato caricato un livello senza menu
        //dunque, siamo in editor, segno il developmentMode come vero
        if (!Level.Equals(1)) developmentMode = true;

    }



    void Start()
    {

        GiorniPassati = (int)(Oggi - DataInizio).TotalDays;
        print("GIORNI PASSATI: " + GiorniPassati);


        if (mainMenu)//Se non c'è il mainMenu - per far funzionare le scene anche da sole
        {
            GetSettingData();
        }

    }

    public void StopGlobalTime()
    {
        TimeMultipler = 0;
        MusicManager.PauseMusic();
        gameUI.InVisible();
        GetGameState();
    }

    public void ResumeGloabalTime()
    {
        TimeMultipler = 1;
        MusicManager.UnPauseMusic();
        gameUI.Visible();
        GetGameState();
    }


    public void SetGameState(Game_State gameState)
    {
        if (gameState.Equals(Game_State.Pause))
            Time.timeScale = 0f * TimeMultipler;
        else if (gameState.Equals(Game_State.Running))
            if (!LevelComplete && !GameManager.Lose)
                Time.timeScale = 1f * TimeMultipler;

        GameState = gameState;
    }
    public Game_State GetGameState()
    {
        if (GameState.Equals(Game_State.Pause))
            Time.timeScale = 0f * TimeMultipler;
        else if (GameState.Equals(Game_State.Running))
        {
            if (!LevelComplete && !GameManager.Lose)
                Time.timeScale = 1f * TimeMultipler;
        }
        return GameState;
    }




    void CheckSoundListening()
    {
        if (FindObjectOfType<AudioListener>()) return; //Se  c'è un AudioListener in scena non fare nulla
        else
        {
            Camera.main.gameObject.AddComponent<AudioListener>();
        }
    }


    void OnSceneWasLoaded(Scene previousScene, LoadSceneMode loadSceneMode)
    {

        _PlayerStartPoint = GameObject.Find("_PlayerStartPoint");

        //  print(PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_CameraDistance"));

        Level = SceneManager.GetActiveScene().buildIndex;
       // print("<b><color=withe>" + SceneManager.GetActiveScene().name + "</color></b>(index:" + Level + ") - ><color=green> loaded</color>");

        //Ad ogni livello cerca il text _buildVersion e scrivci la versione
        _buildVersion = GameObject.Find("_buildVersion");
        if (_buildVersion) _buildVersion.GetComponent<Text>().text = "v." + (Application.version);

        //All'apertura del livello, setta le ombre e i dettagli in base a quality
        SetQuality();

        CheckSoundListening();



        if (Level.Equals(1))//Se è il menu
        {
            OnLoadMenu();

            if (UseAutoQuality)
                InvokeRepeating("CheckLowFrameRate", 5, 3);
            else
                CancelInvoke("CheckLowFrameRate");

            //Da questa riga in poi lavora solo nei livelli e non nel menu iniziale
            return;
        }
        else {




            OnLoadLevel();
            SetRex();


            if (!debugMode)
                m_Character.transform.position = _PlayerStartPoint.transform.position;
            else
                GameManager.m_Character.PlayerEnergy = 100;//In debug, energia infinita (da 0 a 1)

            Invoke("Go", 1.5f);
        }




    }
    public static void OnLoadMenu()
    {
        if (PlayerPrefs.HasKey(GameManager.Instance.AppName + "_AllLevelsOpen"))
        {//Se esite il dato _AllLevelsOpen, è stato comprato
            WorldLevelsPanel.AllLevelsOpen = true;
            MainMenu.AcquistatoIcon.SetActive(true);
        }
        MainMenu.mainMenuIsActive = true;
        Instance.ReadLanguage();

    }

    public static void OnLoadLevel()
    {
        //Imposto qui il palyer, ad ogni caricamento di livello 
        m_Character = FindObjectOfType<W_playerController>();

        UserControl = FindObjectOfType<W_UserControl>();
        cameraShake = FindObjectOfType<CameraShake>();
        cameraMovements = FindObjectOfType<CameraMovements>();
        ThisLevelManager = FindObjectOfType<LevelManager>();  //Ad ogni caricamento di livello, trova il level manager
        gameUI = FindObjectOfType<GameUI>();  //Ad ogni caricamento di livello, trova il level manager//Lo trova ad ongi caricamento di livello
        gameUI.gameObject.GetComponent<CanvasGroup>().alpha = 1;//Se è un livello, al caricamento, visualizzalo
        MiniMenu = GameObject.Find("MiniMenu");
        MiniOptionsMenu = GameObject.Find("MiniOptionsMenu");
        Timer = FindObjectOfType<W_SceneTimer>();
        //Se non sono nel developmentMode
        if (!developmentMode)
            MainMenu.HideMainMenu();//Se è un livello, al caricamento, nascondilo
        m_Character.GetComponent<Rigidbody>().isKinematic = true;
        //Prendo i gameObjects da GameUI di questo livello
        MiniMenu = GameUI.Instance._MiniMenu;
        MiniOptionsMenu = GameUI.Instance._MiniOptionsMenu;
        _DeadPanel = GameUI.Instance._DeadPanel;
        _EndTimePanel = GameUI.Instance._EndTimePanel;
        MiniMenu.gameObject.SetActive(false);
        MiniOptionsMenu.gameObject.SetActive(false);
        _DeadPanel.gameObject.SetActive(false);
        _EndTimePanel.gameObject.SetActive(false);
        PlayerIsDead = false;
        m_Character.PlayerEnergy = 1;


        //Timer.PauseTimer = true; //Mette in pausa per i primi tot secondi, poi parte

        Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, GameManager.Instance.CameraDistance + ThisLevelManager.TowerSize);
    }


    //Imposta le scelte del Rex
    public void SetRex()
    {
        m_Character.MainRexMaterial.SetTexture("_MainTex", SelectedRexTexture);
    }

    //Attivo il Rex
    public void Go()
    {
        m_Character.GetComponent<Rigidbody>().isKinematic = false;
    }

    //Imposta la qualità in base a quality
    public static void SetQuality() {
        if (!developmentMode)
            QualitySettings.SetQualityLevel(MainMenu.Instance._QualityDropDown.value, true);
    }





    //Eseguito dai pulsanti delle opzioni
    public void SelectSkin(int skinValue) {

        SelectedRexTexture = RexTextures[skinValue];
        if (MainMenu.Instance)
        {
            MainMenu.Instance.SelectedIcon.position = MainMenu.Instance.SkinsButtons[skinValue].position;
            MainMenu.Instance.SelectedIcon.SetParent(MainMenu.Instance.SkinsButtons[skinValue]);
        }
        //Salvo qui la skin scelta (ad ogni cambiamento)
        PlayerPrefs.SetInt(GameManager.Instance.AppName + "_Skin", skinValue);

    }




    public void ReadLanguage()
    {


        if (Level.Equals(1))//Se è il menu
        {
            print("Default System Language: <color=withe>" + Application.systemLanguage + "</color>");

            W_Language.AllTexts = FindObjectsOfType<W_Language>();


            //Se è IL PRIMO AVVIO DEL GIOCO su questo dispositivo, se è un nuovo utente
            if (PlayerPrefs.GetInt(GameManager.Instance.AppName + "_PrimoAvvio", 0) == 0)
            {
                print("Apply default language: <color=withe>" + Application.systemLanguage + "</color>");

                //Al primo avvio usa sempre la lingua di sistema
                if (Application.systemLanguage.ToString() == "English")
                    lang = Lang.English;
                else if (Application.systemLanguage.ToString() == "Italian")
                    lang = Lang.Italian;

                PlayerPrefs.SetString(GameManager.Instance.AppName + "_Language", lang.ToString());

                if (GameManager.Instance.lang == GameManager.Lang.English)
                    MainMenu.LangDropDown.value = 0;
                else if (GameManager.Instance.lang == GameManager.Lang.Italian)
                    MainMenu.LangDropDown.value = 1;

                PrimoAvvio = true;

            }
            else
            {
                //Se non è il primo avvio legge dal PlayerPref la lingua scelta
                if (PlayerPrefs.GetString(GameManager.Instance.AppName + "_Language") == "English")
                {
                    lang = Lang.English;
                    MainMenu.Instance._LangDropDown.value = 0;
                }
                else if (PlayerPrefs.GetString(GameManager.Instance.AppName + "_Language") == "Italian")
                {
                    lang = Lang.Italian;
                    MainMenu.Instance._LangDropDown.value = 1;
                }

                if (PlayerPrefs.GetString(GameManager.Instance.AppName + "_Quality") == "Low")
                {
                    quality = Quality.Low;
                    MainMenu.Instance._QualityDropDown.value = 0;
                }
                else if (PlayerPrefs.GetString(GameManager.Instance.AppName + "_Quality") == "Med")
                {
                    quality = Quality.Med;
                    MainMenu.Instance._QualityDropDown.value = 1;
                }
                else if (PlayerPrefs.GetString(GameManager.Instance.AppName + "_Quality") == "Hi")
                {
                    quality = Quality.Hi;
                    MainMenu.Instance._QualityDropDown.value = 2;
                }


                MainMenu.UpdateData();



            }
            //Imposto _PrimoAvvio su true
            PlayerPrefs.SetInt(GameManager.Instance.AppName + "_PrimoAvvio", 1);
            PlayerPrefs.Save();

            Time.timeScale = 1 * TimeMultipler;

            print("PrimoAvvio:<color=#00FF00> " + PrimoAvvio + "</color>");

            return;
        }
        else
        {

            //Questo Else serve se si fa partire un livello non passando dal menu 
            if (PlayerPrefs.GetString(GameManager.Instance.AppName + "_Language") == "English")
                lang = Lang.English;
            else if (PlayerPrefs.GetString(GameManager.Instance.AppName + "_Language") == "Italian")
                lang = Lang.Italian;

            print("PrimoAvvio: " + PrimoAvvio);

        }

        W_Language.CheckLang();

    }



    //Eseguito all'apertura dell'App e quando si riapre il MainMenu (nel caso siano stati modificati i valori dal MiniMenu)
    public void GetSettingData()
    {


        if (!PrimoAvvio)
        {
            //Predo i dati salvati
            if (MusicVol_Slider) MusicVol_Slider.value = PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_MusicVolume");
            if (SoundsVol_Slider) SoundsVol_Slider.value = PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_SoundsVolume");
            // if (UIScale_Slider) UIScale_Slider.value = PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_UIScale");
            CameraDistance = PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_CameraDistance");
            GetUIScale.UIAlpha = PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_UITransparence");
            SelectSkin(PlayerPrefs.GetInt(GameManager.Instance.AppName + "_Skin"));
            UseAutoQuality = Convert.ToBoolean(PlayerPrefs.GetString(GameManager.Instance.AppName + "_autoQuality")) ;

            print("<color=green>Get saved SoundsVol:</color> " + PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_MusicVolume"));
            print("<color=green>Get saved MusicVol:</color> " + PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_SoundsVolume"));
            print("<color=green>Get saved _UIScale:</color> " + PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_UIScale"));
            print("<color=green>Get saved Language:</color> " + PlayerPrefs.GetString(GameManager.Instance.AppName + "_Language"));
            print("<color=green>Get saved Quality:</color> " + PlayerPrefs.GetString(GameManager.Instance.AppName + "_Quality"));
            print("<color=green>Get saved CameraDistance:</color> " + PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_CameraDistance"));
            print("<color=green>Get saved UITransparence:</color> " + PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_UITransparence"));
            print("<color=green>Get saved SelectSkin:</color> " + PlayerPrefs.GetInt(GameManager.Instance.AppName + "_Skin"));
        }
        else
        {
            if (MusicVol_Slider) MusicVol_Slider.value = 10f;
            if (SoundsVol_Slider) SoundsVol_Slider.value = 10f;
            CameraDistance = 22.5f;
            UseAutoQuality = false;
            quality = Quality.Med;
            GetUIScale.UIAlpha = 1f;
            MainMenu.Instance._QualityDropDown.value = 1;
            SelectSkin(0);

            PlayerPrefs.SetFloat(GameManager.Instance.AppName + "_CameraDistance", CameraDistance);
            PlayerPrefs.SetFloat(GameManager.Instance.AppName + "_UITransparence", GetUIScale.UIAlpha);
        }


        //Assegno i volori deli slider alle variabili (al loading dei valori salvati)
        if (MasterMixer)
        {
            if (SoundsVol_Slider) MasterMixer.SetFloat("SoundsVolume", (SoundsVol_Slider.value * AudioMultipler) - 20);
            if (MusicVol_Slider) MasterMixer.SetFloat("MusicVolume", (MusicVol_Slider.value * MusicManager.MusicAmplifer) - 20);
        }
        // if (UIScale_Slider) ControlsUIScale = UIScale_Slider.value;



        ////Limito il suono
        if (SoundsVol_Slider) if (SoundsVol_Slider.value <= -0.01f) MasterMixer.SetFloat("SoundsVolume", -100);
        if (MusicVol_Slider) if (MusicVol_Slider.value <= -0.01f) MasterMixer.SetFloat("MusicVolume", -100);

        W_Language.CheckLang();
    }

    //Eseguito in Update se aperto il menu opzioni
    void SettingDataUpdate()
    {

        if (!MainMenu.OptionsPanelIsOpen) return;
        //////Assegno i volori deli slider alle variabili (a runtime, mentri li modifica l'utente)
        MasterMixer.SetFloat("SoundsVolume", (SoundsVol_Slider.value * AudioMultipler) - 20);
        MasterMixer.SetFloat("MusicVolume", (MusicVol_Slider.value * MusicManager.MusicAmplifer) - 20);
        //  ControlsUIScale = UIScale_Slider.value;

        //  SizeValue.text ="x"+ System.Math.Round(ControlsUIScale, 2);

        ////Limito il suono e nel caso, visualizzo le icone NoSuond
        if (SoundsVol_Slider.value <= 0.01f) { MasterMixer.SetFloat("SoundsVolume", -100); _noSounds.SetActive(true); } else { _noSounds.SetActive(false); }
        if (MusicVol_Slider.value <= 0.01f) { MasterMixer.SetFloat("MusicVolume", -100); _noMusic.SetActive(true); } else { _noMusic.SetActive(false); }


    }

    public static void GoToNextScene()
    {


        if (ThisLevelManager.IsBonusLevel) //Se è un livello Bonus
        {
            MainMenu.BackToMainMenu();
            return;
        }

        if (ThisLevelManager.IsLastLevel || !SceneListCheck.Has(ThisLevelManager.NextSceneName)) //Se la scena non esiste, manda il messaggio
        {

            print("Called SCENE: " + ThisLevelManager.NextSceneName);

            print("Is LastLevel: " + ThisLevelManager.IsLastLevel);
            GameUI.Instance.EndTestingMessage.SetActive(true);
            GameManager.ShowMiniMenu();
            GameObject.Find("LevelCompleteMessageUI").SetActive(false);
            return;
        }


        if (!ThisLevelManager.IsLastLevel && ThisLevelManager.NextSceneName != "")
        {
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
            gameUI.ReloadingSceneUI.SetActive(true);
            print("LoadingNextScene: " + ThisLevelManager.NextSceneName);
            SceneManager.LoadScene(ThisLevelManager.NextSceneName);
        }
        else
        {
            print("Called SCENE: " + ThisLevelManager.NextSceneName);
            print("Is LastLevel: " + ThisLevelManager.IsLastLevel);
            Debug.LogError("OPS, NEXT LEVEL NON IMPOSTATO");
            Debug.LogError("SELEZIONARE IL LIVELLO SUL LEVEL MANAGER");
        }
    }


    public static void ReloadScene()
    {
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
        gameUI.ReloadingSceneUI.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Instance.SetGameState(GameManager.Game_State.Running);

    }

    public static void ShowMiniMenu()
    {

        ////Se il livello risulta già completato 
        //if (GameManager.LevelComplete) return;
        //O se il personaggio ha già perso
        if (GameManager.Lose) return;

        //Se non c'è il miniMenu
        if (!MiniMenu) return;

        //Mette in pausa (solo se non è attivo il MainMenu)
        if (!MainMenu.mainMenuIsActive)
            Instance.SetGameState(GameManager.Game_State.Pause);
        //Visualizza il MiniMenu
        MiniMenu.SetActive(true);
        print("Show MiniMenu");

    }
    public static void HideMiniMenu()
    {
        ////Se il livello risulta già completato 
        //if (GameManager.LevelComplete) return;
        //O se il personaggio ha già perso
        if (GameManager.Lose) return;


        // if(SaveSetting)
        // MiniOptionsMenu.GetComponent<MiniOptionsMenu>().SaveSetting();

        MiniMenu.SetActive(false);
        MiniOptionsMenu.SetActive(false);

        if (!MainMenu.mainMenuIsActive)
            Instance.SetGameState(GameManager.Game_State.Running);

        GetUIScale.UpdateAll();
    }


    public static void OpenMiniOptions() {
        MiniOptionsMenu.SetActive(true);

    }
    public static void CloseMiniOptions()
    {
        MiniOptionsMenu.SetActive(false);

    }


    void OnDestroy()
    {

        SceneManager.sceneLoaded -= OnSceneWasLoaded;

    }






    /// <summary>Reset All and clear from player prefs</summary>
    /// Delete All LevN_ player prefs keys
    public static void ResetAll()
    {
        GameManager.Instance.PrimoAvvio = false;

        SocialConnection.DeleteUserFormDatabase();

        //Cancella tutti i dati del setting
        PlayerPrefs.DeleteKey(GameManager.Instance.AppName + "_PrimoAvvio");
        PlayerPrefs.DeleteKey(GameManager.Instance.AppName + "_SoundsVolume");
        PlayerPrefs.DeleteKey(GameManager.Instance.AppName + "_MusicVolume");
        PlayerPrefs.DeleteKey(GameManager.Instance.AppName + "_Language");
        PlayerPrefs.DeleteKey(GameManager.Instance.AppName + "_UIScale");
        PlayerPrefs.DeleteKey(GameManager.Instance.AppName + "_Quality");
        PlayerPrefs.DeleteKey(GameManager.Instance.AppName + "_AllLevelsOpen");


        for (int i = 0; i < 100; i++)
        {
            PlayerPrefs.DeleteKey(GameManager.Instance.AppName + "_GemsIDGeted_" + i);
        }

        W_GemManager._istance.PlayerGems = Instance.NewUserGems;
        PlayerPrefs.DeleteKey(GameManager.Instance.AppName + "_Gems_");//Cancella le gemme da disco

        //Reimposta la lingua di sistema
        if (Application.systemLanguage.ToString() == "English")
            GameManager.Instance.lang = GameManager.Lang.English;
        else if (Application.systemLanguage.ToString() == "Italian")
            GameManager.Instance.lang = GameManager.Lang.Italian;

        print("Apply default language: <color=withe>" + Application.systemLanguage + "</color>");

        //Chiude il DialogBox01
        MainMenu.AreYourSureDialog.SetActive(false);


        //Per ogni livello
        foreach (W_SceneItem allLevels in MainMenu.Instance.AllLevels)
        {

            ////Cancella tutti i dati LevN_
            PlayerPrefs.DeleteKey(GameManager.Instance.AppName + "LevN_" + allLevels.LevelNumber);

        }


        PlayerPrefs.DeleteAll();//Cancella tutto il PlayerPrefsù
    }



        public static void QuitGame()
    {
        SocialConnection.instance.OnLogOut();
        print("QUIT GAME");
        Application.Quit();
    }


    public static void EnergyUpdate()
    {
        if (m_Character.PlayerEnergy <= 0.01f)
        {
            m_Character.PlayerEnergy = 0;
            PlayerDead();
        }

    }

    public static void PlayerDead()
    {
        if (PlayerIsDead) return;
        GameManager.m_Character.ResetOriginalMaterials();
        MusicManager.MusicFadeOut();
        m_Character.PlayerEnergy = 0;
        _DeadPanel.gameObject.SetActive(true);
        PlayerIsDead = true;
        print("Player IS DEAD");
        GameManager.MasterAudioSource.PlayOneShot(m_Character.DeadSound);
        GameManager.m_Character.CheckResumePossibility();
        


    }

    public static void EndTime()
    {

        if (PlayerIsDead) return;

        MusicManager.MusicFadeOut();
        _EndTimePanel.gameObject.SetActive(true);
        _DeadPanel.gameObject.SetActive(false);
        PlayerIsDead = true;
        GameManager.MasterAudioSource.PlayOneShot(m_Character.EndTimeSound);
        print("TIME OVER");

    }



    public void ReSpawnOky() {

        if (!m_Character.CheckResumePossibility()) return;
        GameManager.m_Character.ResetOriginalMaterials();

        PlayerIsDead = Lose = false; //Resucita
        Respawn = true;
        _EndTimePanel.gameObject.SetActive(false);//Rimuove la UI di morte
        _DeadPanel.gameObject.SetActive(false);//Rimuove la UI di morte
        m_Character.PlayerEnergy = 1;//Rprstina tutta l'energia di OKY
        m_Character.RemovePlayerEnergy(0);//Attiva l'invulnerabilità temporanea
        m_Character.m_Capsule.enabled = true; //Riattivo il collider del player
        m_Character.transform.position = LastCheckPoint;//Riposiziona OKY
        W_playerController.PlayerAudioSource.PlayOneShot(ResumeSound);
        Timer.sceneTimer = Timer.TimerAtStart;//Ripristino il tempo come dall'inizio
        m_Character.DeadEmitted = false;//Azzero
        if (ThisLevelManager.ReplaceObjects)
            foreach (GameObject obj in ThisLevelManager.ObjectToRespawnOnResume)//Riattiva tutti gli oggetti raccogliebili (a parte le stelle)
                obj.SetActive(true);
        StartCoroutine(ReActivateOKY());

        W_PlayerPoints._istance.RemovePoints(500);

    }


    IEnumerator ReActivateOKY() {
        yield return new WaitForSeconds(1);
        GameManager.cameraMovements.target = GameManager.cameraMovements.normalTarget;
        m_Character.m_Animator.SetBool("Dead", false);//Ripristina l'animazione
        m_Character.m_Animator.SetBool("Felice", true);
        MusicManager.MusicFadeIn();
        Respawn = false;
    }







    void Update() {


        //Aggiornamento dello stato di energia
        if (m_Character)
            EnergyUpdate();


        //Back Buttoon on mobile device
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu.BackToMainMenu();

        }

        //Menu Button on mobile device
        if (Input.GetKeyDown(KeyCode.Menu))
        {
            MainMenu.OpenQuitDialog();
        }
        //Home (central button) on mobile device
        if (Input.GetKeyDown(KeyCode.Home))
        {
            MainMenu.OpenQuitDialog();
        }

        if (mainMenu)//Se c'è il mainMenu - per far funzionare le scene anche da sole durante lo sviluppo del gioco
        {
                SettingDataUpdate(); //A Runtime prende i valori se si cambiano

                CameraDistance = Mathf.Clamp(CameraDistance, 18, 35);
            }



       
      
            
    }

    void CheckLowFrameRate(){

        if (Level <= 1) return; //Se è il menu o l'intro
        if (disableLowFrameRateCheck) return;
        if (!UseAutoQuality) return;
        if (Time.timeSinceLevelLoad < 2) return;
        if (Time.timeSinceLevelLoad > 25)
        {
            CancelInvoke("CheckLowFrameRate");
            return;
        }

        if (QualitySettings.GetQualityLevel() <= 0) return;

        GameUI.Instance._autoSettingUI.SetActive(false);//Nasconde la UI

        OldFrameRate = FPSCounter.OldFrameRate;

        FrameRate = FPSCounter.m_CurrentFps;



        if (quality == Quality.Hi) { FPSCounter.multipler = 1.6f; Time.fixedDeltaTime = 0.015f; }
        if (quality == Quality.Med) { FPSCounter.multipler = 1.9f; Time.fixedDeltaTime = 0.02f; }


        if (FrameRate < 25 && OldFrameRate < 30)
        {
            LowFrameRate = true;
            GameUI.Instance._autoSettingUI.SetActive(true);//Visualizza la UI
            StartCoroutine(RescaleQuality());
            
        }
        else
        {        
            LowFrameRate = false;
            GameUI.Instance._autoSettingUI.SetActive(false);//Visualizza la UI 
            if (FrameRate >= 25 && OldFrameRate >= 30)
            {
                disableLowFrameRateCheck = true;
                CancelInvoke("CheckLowFrameRate");
                Time.fixedDeltaTime = 0.01f;
                FPSCounter.multipler = 1.4f;
            }
        }
    }


    IEnumerator RescaleQuality() {
        yield return new WaitForSeconds(1);
        QualitySettings.DecreaseLevel();
        System.GC.Collect();

        foreach (QualityControl qual in FindObjectsOfType<QualityControl>())
            qual.ControllNow();


        if (quality == Quality.Hi) { quality = Quality.Med; FPSCounter.multipler = 1.6f; Time.fixedDeltaTime = 0.015f; }
        if (quality == Quality.Med) {quality = Quality.Low; FPSCounter.multipler = 1.9f; Time.fixedDeltaTime = 0.02f; CancelInvoke("CheckLowFrameRate"); }
        PlayerPrefs.SetString(GameManager.Instance.AppName + "_Quality", GameManager.Instance.quality.ToString());

    }
}
