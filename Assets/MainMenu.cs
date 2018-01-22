using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


//CLIBREX
public class MainMenu : MonoBehaviour
{

    static public MainMenu Instance;
    static public GameObject MenuMusic;
    static public GameObject LevelSelectionPanel;
    static public GameObject HighScorePanel;
    static public GameObject CreditsPanel;
    static public GameObject OptionsPanel;
    static public GameObject GadgetsPanel;
    static public GameObject SkinPanel;
    static public GameObject GuidePanel;
    static public GameObject BuyGemsPanel;
    static public GameObject OpenAllLevelsPanel;
    static public GameObject AllLevelsOpened;
    static public GameObject AreYourSureDialog;
    static public GameObject QuitDialog;
    static public GameObject BuySkinDialog;
    static public GameObject UnlockBonusLEvelDialog;
    static public GameObject AcquistatoIcon;
    static public GameObject WorldLeaders;
    static Toggle autoQuality;
    static public GameObject NoGems;
    static public Image LoadingBar;
    static public Dropdown LangDropDown;
    static public Dropdown QualityDropDown;
    static public GameObject LoadingPanel;
    static public  Text textPourcentage; //The text with the percentage increasing
    static public GameObject ResumeButton;
    static public GameObject MenuCam;
    static List<GameObject> ObjectInScene;
    

    public int LevelsPanelStep = 953;
    

    public GameObject _MenuCam;
    public GameObject _MenuMusic;
    public GameObject _LevelSelectionPanel;
    public GameObject _HighScorePanel;
    public GameObject _CreditsPanel;
    public GameObject _OptionsPanel;
    public GameObject _GadgetsPanel;
    public GameObject _SkinPanel;
    public GameObject _GuidePanel;
    public GameObject _BuyGemsPanel;
    public GameObject _UnlockBonusLEvelDialog;
    public GameObject _OpenAllLevelsPanel;
    public GameObject _AllLevelsOpened;
    public GameObject _AcquistatoIcon;
    public GameObject _WorldLeaders;
    public GameObject _NoGems;
    public GameObject _AreYourSureDialog;
    public GameObject _QuitDialog;
    public GameObject _BuySkinDialog;
    public Toggle _autoQuality;
    public GameObject ScoreBoardInfosPanel;
    public GameObject GemsInfosPanel;
    

    public Image _LoadingBar;
    public Dropdown _LangDropDown;
    public Dropdown _QualityDropDown;
    public  GameObject _LoadingPanel;
    public Text _textPourcentage; 
    public Transform SelectedIcon;
    public Transform[] SkinsButtons;
    public GameObject _ResumeButton;
    public GameObject NoConnectedMessage;
    public W_WorldScores[] allWorldScoresPanel;



    static public bool OptionsPanelIsOpen;
    static public bool AllPanelsColsed;
    static public CanvasGroup MainCanvasGroup;
    static public bool mainMenuIsActive;


    public WorldLevelsPanel[] allLevelsPanels;
    static public W_SceneItem[] allSceneItems;

    void Awake()
    {
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



        FindPanels();



    }
    public void ShowNoConnectedMessage()
    {
        NoConnectedMessage.SetActive(true);
    }


    public void ShowScoreBoardInfosPanel() {
        ScoreBoardInfosPanel.SetActive(true);
    }

    public void ShowGemsInfosPanel()
    {
        GemsInfosPanel.SetActive(true);
    }



    void Start()
    {
       
        HideAllPanels();
        ResumeButton.SetActive(false);
        UpdateAllWorldsWebData();
        MainMenu.AcquistatoIcon.SetActive(WorldLevelsPanel.AllLevelsOpen);
        if(MainMenu.AcquistatoIcon.GetComponentInParent<Button>())
            MainMenu.AcquistatoIcon.GetComponentInParent<Button>().interactable = !WorldLevelsPanel.AllLevelsOpen;

        
    }

    public void FindPanels()
    {
        MainCanvasGroup = Instance.GetComponentInChildren<CanvasGroup>();
        LevelSelectionPanel = _LevelSelectionPanel.gameObject;

        MenuCam = _MenuCam;
        MenuMusic = _MenuMusic;
        HighScorePanel = _HighScorePanel;
        CreditsPanel = _CreditsPanel;
        OptionsPanel = _OptionsPanel;
        GadgetsPanel = _GadgetsPanel;
        SkinPanel = _SkinPanel;
        GuidePanel=_GuidePanel;
        BuyGemsPanel = _BuyGemsPanel;
        UnlockBonusLEvelDialog = _UnlockBonusLEvelDialog;
        OpenAllLevelsPanel = _OpenAllLevelsPanel;
        AllLevelsOpened = _AllLevelsOpened;
        NoGems = _NoGems;
        AreYourSureDialog = _AreYourSureDialog;
        QuitDialog = _QuitDialog;
        BuySkinDialog = _BuySkinDialog;
        WorldLeaders = _WorldLeaders;
        autoQuality = _autoQuality;
        LoadingBar = _LoadingBar;
        LangDropDown = _LangDropDown;
        QualityDropDown = _QualityDropDown;
        LoadingPanel = _LoadingPanel;
        textPourcentage = _textPourcentage;
        ResumeButton = _ResumeButton;
        AcquistatoIcon = _AcquistatoIcon;

    }

    public static void ShowCredits()
    {
        AllPanelsColsed = false;
        AreYourSureDialog.SetActive(false);
        LevelSelectionPanel.SetActive(false);
        QuitDialog.SetActive(false);
        BuySkinDialog.SetActive(false);
        HighScorePanel.SetActive(false);
        CreditsPanel.SetActive(true);
        OptionsPanel.SetActive(false);
        AllLevelsOpened.SetActive(false);
        GadgetsPanel.SetActive(false);
        SkinPanel.SetActive(false);
        OpenAllLevelsPanel.SetActive(false);
        BuyGemsPanel.SetActive(false);
        OptionsPanelIsOpen = false;
        GuidePanel.SetActive(false);
        NoGems.SetActive(false);
        W_Language.CheckLang();

    }

    public static void ShowLevels()
    {
        AllPanelsColsed = false;
        AreYourSureDialog.SetActive(false);
        LevelSelectionPanel.SetActive(true);
        QuitDialog.SetActive(false);
        BuySkinDialog.SetActive(false);
        HighScorePanel.SetActive(false);
        CreditsPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        AllLevelsOpened.SetActive(false);
        GadgetsPanel.SetActive(false);
        SkinPanel.SetActive(false);
        OpenAllLevelsPanel.SetActive(false);
        BuyGemsPanel.SetActive(false);
        GuidePanel.SetActive(false);
        OptionsPanelIsOpen = false;
        UnlockBonusLEvelDialog.SetActive(false);
        NoGems.SetActive(false);
        W_Language.CheckLang();
        allSceneItems = FindObjectsOfType<W_SceneItem>();
        print("W_SceneItem trovati: "+allSceneItems.Length);
    }

    public static void ShowHigScore()
    {

        //Aggiorna tutti i dati
        foreach (GetPlayerPrefData getData in FindObjectsOfType<GetPlayerPrefData>())
            getData.GetData();

        AllPanelsColsed = false;
        AreYourSureDialog.SetActive(false);
        LevelSelectionPanel.SetActive(false);
        QuitDialog.SetActive(false);
        BuySkinDialog.SetActive(false);
        HighScorePanel.SetActive(true);
        CreditsPanel.SetActive(false);
        OpenAllLevelsPanel.SetActive(false);
        AllLevelsOpened.SetActive(false);
        OptionsPanel.SetActive(false);
        OptionsPanelIsOpen = false;
        GadgetsPanel.SetActive(false);
        SkinPanel.SetActive(false);
        BuyGemsPanel.SetActive(false);
        GuidePanel.SetActive(false);
        NoGems.SetActive(false);
        W_Language.CheckLang();


    }
    public static void ShowGadgetsPanel()
    {


        AllPanelsColsed = false;
        AreYourSureDialog.SetActive(false);
        LevelSelectionPanel.SetActive(false);
        QuitDialog.SetActive(false);
        BuySkinDialog.SetActive(false);
        OpenAllLevelsPanel.SetActive(false);
        AllLevelsOpened.SetActive(false);
        HighScorePanel.SetActive(false);
        CreditsPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        OptionsPanelIsOpen = false;
        GadgetsPanel.SetActive(true);
        BuyGemsPanel.SetActive(false);
        SkinPanel.SetActive(false);
        GuidePanel.SetActive(false);
        NoGems.SetActive(false);
        MainMenu.AcquistatoIcon.SetActive(WorldLevelsPanel.AllLevelsOpen);
        if (MainMenu.AcquistatoIcon.GetComponentInParent<Button>())
            MainMenu.AcquistatoIcon.GetComponentInParent<Button>().interactable = !WorldLevelsPanel.AllLevelsOpen;
        W_Language.CheckLang();

    }
    

    public static void OpenBuyGemsPanel()
    {

        AllPanelsColsed = false;
        AreYourSureDialog.SetActive(false);
        LevelSelectionPanel.SetActive(false);
        QuitDialog.SetActive(false);
        BuySkinDialog.SetActive(false);
        HighScorePanel.SetActive(false);
        OpenAllLevelsPanel.SetActive(false);
        AllLevelsOpened.SetActive(false);
        CreditsPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        OptionsPanelIsOpen = false;
        GadgetsPanel.SetActive(false);
        BuyGemsPanel.SetActive(true);
        SkinPanel.SetActive(false);
        GuidePanel.SetActive(false);
        NoGems.SetActive(false);
        W_Language.CheckLang();

    }
    public static void OpenUnlockAllLevels()
    {
        if (WorldLevelsPanel.AllLevelsOpen) return;

        AllPanelsColsed = false;
        AreYourSureDialog.SetActive(false);
        LevelSelectionPanel.SetActive(false);
        QuitDialog.SetActive(false);
        BuySkinDialog.SetActive(false);
        HighScorePanel.SetActive(false);
        CreditsPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        OptionsPanelIsOpen = false;
        GadgetsPanel.SetActive(true); //Mantiene aperto
        BuyGemsPanel.SetActive(false);
        OpenAllLevelsPanel.SetActive(true);
        AllLevelsOpened.SetActive(false);
        SkinPanel.SetActive(false);
        GuidePanel.SetActive(false);
        NoGems.SetActive(false);
        W_Language.CheckLang();
        MainMenu.AcquistatoIcon.SetActive(WorldLevelsPanel.AllLevelsOpen);
        if (MainMenu.AcquistatoIcon.GetComponentInParent<Button>())
            MainMenu.AcquistatoIcon.GetComponentInParent<Button>().interactable = !WorldLevelsPanel.AllLevelsOpen;
    }
    

    public static void ShowSkinPanel()
    {


        AllPanelsColsed = false;
        AreYourSureDialog.SetActive(false);
        LevelSelectionPanel.SetActive(false);
        QuitDialog.SetActive(false);
        OpenAllLevelsPanel.SetActive(false);
        BuySkinDialog.SetActive(false);
        HighScorePanel.SetActive(false);
        CreditsPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        AllLevelsOpened.SetActive(false);
        SkinPanel.SetActive(true);
        BuyGemsPanel.SetActive(false);
        OptionsPanelIsOpen = false;
        GadgetsPanel.SetActive(false);
        GuidePanel.SetActive(false);
        NoGems.SetActive(false);
        W_Language.CheckLang();

    }


    public static void OpenGuidePanel() {

        AllPanelsColsed = false;
        AreYourSureDialog.SetActive(false);
        LevelSelectionPanel.SetActive(false);
        QuitDialog.SetActive(false);
        BuySkinDialog.SetActive(false);
        HighScorePanel.SetActive(false);
        CreditsPanel.SetActive(false);
        AllLevelsOpened.SetActive(false);
        OptionsPanel.SetActive(false);
        OptionsPanelIsOpen = false;
        BuyGemsPanel.SetActive(false);
        OpenAllLevelsPanel.SetActive(false);
        GadgetsPanel.SetActive(false);
        SkinPanel.SetActive(false);
        GuidePanel.SetActive(true);
        NoGems.SetActive(false);
        W_Language.CheckLang();

    }





    public  void ShowUnlockThisBonusLevel(W_SceneItem sceneItem)
    {
        int LevelNumber = 0;
        int.TryParse(sceneItem.LevelNumber, out LevelNumber); 
        AllPanelsColsed = false;
        UnlockBonusLEvelDialog.SetActive(true);
        UnlockBonusLEvelDialog.GetComponentInChildren<W_Button>().parameter = LevelNumber;
        W_Language.CheckLang();

    }

    public static void UpdateAllSceneItems() {
        foreach (W_SceneItem sceneItem in allSceneItems)
            sceneItem.UpdateStatus();
    }

    public static void ShowNoGemsMessage()
    {

        AllPanelsColsed = false;
        NoGems.SetActive(true);
        W_Language.CheckLang();

    }

    public static void ShowOptions()
    {


        AllPanelsColsed = false;
        AreYourSureDialog.SetActive(false);
        QuitDialog.SetActive(false);
        BuySkinDialog.SetActive(false);
        LevelSelectionPanel.SetActive(false);
        HighScorePanel.SetActive(false);
        CreditsPanel.SetActive(false);
        OptionsPanel.SetActive(true);
        AllLevelsOpened.SetActive(false);
        GadgetsPanel.SetActive(false);
        BuyGemsPanel.SetActive(false);
        OpenAllLevelsPanel.SetActive(false);
        SkinPanel.SetActive(false);
        GuidePanel.SetActive(false);
        NoGems.SetActive(false);
        W_Language.CheckLang();


        //  Imposta il dropMenu in base al GameManager
        if (GameManager.Instance.lang == GameManager.Lang.English)
            LangDropDown.value = 0;
        else if (GameManager.Instance.lang == GameManager.Lang.Italian)
            LangDropDown.value = 1;

        //  Imposta il dropMenu in base al GameManager
        if (GameManager.Instance.quality == GameManager.Quality.Low)
            QualityDropDown.value = 0;
        else if (GameManager.Instance.quality == GameManager.Quality.Med)
            QualityDropDown.value = 1;
        else if (GameManager.Instance.quality == GameManager.Quality.Hi)
            QualityDropDown.value = 2;


        autoQuality.isOn = GameManager.Instance.UseAutoQuality;

        OptionsPanelIsOpen = true;
    }

    public static void OpenDialog01()
    {
        
        AreYourSureDialog.SetActive(true);
    }
    public static void OpenQuitDialog()
    {


        if (!QuitDialog) { print("QUIT GAME WINDOW NOT PRESENT"); return; }
        if (!mainMenuIsActive) {
            QuitDialog.transform.SetParent(GameManager.gameUI.transform); //Sposta la finestra sotto la UI del gioco
        }
        else { 
            QuitDialog.transform.SetParent(GameManager.mainMenu.transform); //Sposta la finestra sotto la UI del gioco
            }
        QuitDialog.SetActive(true);
    }
    public static void NoSure()
    {
        AreYourSureDialog.SetActive(false);
    }
    public static void NoQuit()
    {
        
        QuitDialog.transform.SetParent(GameManager.mainMenu.transform); //Sposta la finestra sotto la UI del gioco
        QuitDialog.SetActive(false);
    }
    public static void QuitGame()
    {
        Instance.UpdateAllWorldsWebData();
        SaveSetting();
        QuitDialog.transform.SetParent(GameManager.mainMenu.transform); //Sposta la finestra sotto la UI del gioco
        HideAllPanels();
        print("QUIT GAME");
        Application.Quit();
    }

    public static void SaveSetting()
    {
    

        PlayerPrefs.SetFloat(GameManager.Instance.AppName + "_SoundsVolume", GameManager.Instance.SoundsVol_Slider.value);
        PlayerPrefs.SetFloat(GameManager.Instance.AppName + "_MusicVolume", GameManager.Instance.MusicVol_Slider.value);
        PlayerPrefs.SetString(GameManager.Instance.AppName + "_Language", GameManager.Instance.lang.ToString());
      //  PlayerPrefs.SetFloat(GameManager.Instance.AppName + "_UIScale", GameManager.Instance.UIScale_Slider.value);
        PlayerPrefs.SetString(GameManager.Instance.AppName + "_Quality", GameManager.Instance.quality.ToString());
        PlayerPrefs.SetString(GameManager.Instance.AppName + "_autoQuality", GameManager.Instance.UseAutoQuality.ToString());
        PlayerPrefs.Save();

      //  print("<color=magenta>Saving UIScale:</color> " + GameManager.Instance.UIScale_Slider.value);
        print("<color=magenta>Saving SoundsVol:</color> " + GameManager.Instance.SoundsVol_Slider.value);
        print("<color=magenta>Saving MusicVol:</color> " + GameManager.Instance.MusicVol_Slider.value);
        print("<color=magenta>Saving Language:</color> " + GameManager.Instance.lang.ToString());
        print("<color=magenta>Saving Quality:</color> " + GameManager.Instance.quality.ToString());
        print("<color=magenta>Saving AutoQuality:</color> " + GameManager.Instance.UseAutoQuality.ToString());
    }



    public static void UpdateData()
    {

        if (LangDropDown.value.Equals(0))
            GameManager.Instance.lang = GameManager.Lang.English;
        else if (LangDropDown.value.Equals(1))
            GameManager.Instance.lang = GameManager.Lang.Italian;

        //  Imposta il dropMenu in base al GameManager
        if (QualityDropDown.value.Equals(0))
            GameManager.Instance.quality = GameManager.Quality.Low;
        if (QualityDropDown.value.Equals(1))
            GameManager.Instance.quality = GameManager.Quality.Med;
        if (QualityDropDown.value.Equals(2))
            GameManager.Instance.quality = GameManager.Quality.Hi;

        GameManager.Instance.UseAutoQuality= autoQuality.isOn;

        W_Language.CheckLang();

        print("UpdateData - " + " Quality"+ GameManager.Instance.quality +" Lang:"+ GameManager.Instance.lang);
    }


    public static void HideAllPanels()
    {

        UpdateData();
        //Per evitare che avvenga il salvataggio appena aperta l'app
        //all'apertura esegue HideAllPanels perchè gli dico di chiudere tutti i pannelli 
        if (Time.timeSinceLevelLoad>2)
        {
            SaveSetting();
        }

        
        LevelSelectionPanel.SetActive(false);
        HighScorePanel.SetActive(false);
        CreditsPanel.SetActive(false);
        AreYourSureDialog.SetActive(false);
        QuitDialog.SetActive(false);
        BuySkinDialog.SetActive(false);
        OptionsPanel.SetActive(false);
        GadgetsPanel.SetActive(false);
        OptionsPanelIsOpen = false;
        AllLevelsOpened.SetActive(false);
        SkinPanel.SetActive(false);
        OpenAllLevelsPanel.SetActive(false);
        GuidePanel.SetActive(false);
        BuyGemsPanel.SetActive(false);
        Instance.ScoreBoardInfosPanel.SetActive(false);
        Instance.GemsInfosPanel.SetActive(false);
        NoGems.SetActive(false);
        UnlockBonusLEvelDialog.SetActive(false);
        AllPanelsColsed = true;

        SocialConnection.instance.CheckIfLogged();

    }

    public static void HideMainMenu()
    {
        WorldLeaders.SetActive(false);
        MenuCam.SetActive(false);
        MainCanvasGroup.alpha = 0;
        MainCanvasGroup.interactable = false;
        MainCanvasGroup.blocksRaycasts = false;
        HideAllPanels();
        MenuMusic.SetActive(false);
        mainMenuIsActive = false;
        if(GameManager.m_Character)
            GameManager.m_Character.OkyListering.enabled = true;
    }

    //Qui si chiude il livello in corso e si trona al menu iniziale
    public static void BackToMainMenu()
    {
        
        if (!MainCanvasGroup|| mainMenuIsActive)
        {
            return;
        }


        WorldLeaders.SetActive(true);
        MenuCam.SetActive(true);
        GameManager.m_Character.OkyListering.enabled = false;

        W_GemManager._istance.AddGems(0);

        ResumeButton.SetActive(true);

        if(GameManager.LevelComplete)
        ResumeButton.SetActive(false);

        if (GameManager.PlayerIsDead)
            ResumeButton.SetActive(false);

        if (GameManager.Lose)
            ResumeButton.SetActive(false);

        GameManager.MasterAudioSource.Stop();

        GameManager.HideMiniMenu();
        GameManager.MiniOptionsMenu.GetComponent<MiniOptionsMenu>().GetSettingData(); 
        GameManager.PlayerIsDead = GameManager.LevelComplete = GameManager.Lose = false;
        GameManager.Instance.SetGameState(GameManager.Game_State.Pause);//Rmetto la pausa perchè chiudendo il MiniMenu si toglie


        MainCanvasGroup.alpha = 1;
        MainCanvasGroup.interactable = true;
        MainCanvasGroup.blocksRaycasts = true;
        HideAllPanels();
        mainMenuIsActive = true;
        MenuMusic.SetActive(true);

        ObjectInScene = new List<GameObject>();

        //Nascondo la UI del gioco, senza disattivare il gameObject
        GameManager.gameUI.InVisible();

        //Popolo la lista dei gameObjcts disattivati
        foreach (GameObject g in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            if(!g.GetComponent<LevelManager>() && !g.GetComponent<W_playerController>() && !g.GetComponent<GameUI>())
            ObjectInScene.Add(g);
        }

        foreach (GameObject g in ObjectInScene)
        {
            g.SetActive(false);
        }

      GameUI.Instance.OpenSceneUI.SetActive(false);


   

            //Prende i dati dal PlayerPrefKey specificato e li mette sul testo
            foreach (GetPlayerPrefData getData in FindObjectsOfType<GetPlayerPrefData>())
            getData.GetData();
       
        GameManager.Instance.GetSettingData();//Riprendo i dati dal PlayerPref


        SocialConnection.instance.CheckIfLogged();
        if (!Social.localUser.authenticated && Application.internetReachability != NetworkReachability.NotReachable)
            SocialConnection.instance.LogIn();

        Instance.UpdateAllWorldsWebData();

        GameManager.Instance.PrimoAvvio = false;
        //Imposto _PrimoAvvio su true
        PlayerPrefs.SetInt(GameManager.Instance.AppName + "_PrimoAvvio", 1);
        PlayerPrefs.Save();

    }


    public void UpdateAllWorldsWebData() {

        // Aggiorna i dati dei punteggi di tutti i mondi
        foreach (W_WorldScores W_panel in allWorldScoresPanel)
        {
            W_panel.UpdateAllWebData(true);
            print(W_panel.name+"  "+W_panel.WorldPoints);
        }

    }

    public void ResumeGame() {
        foreach (GameObject g in ObjectInScene)
        {
            g.SetActive(true);
        }
        HideMainMenu();
        mainMenuIsActive = false;
        MenuMusic.SetActive(false);
        GameManager.gameUI.Visible();
        GameManager.Instance.SetRex();
        GameManager.Instance.SetGameState(GameManager.Game_State.Running);//Rimuovo la pausa
        
    }




}
