using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.ImageEffects;


//LevelManager
public class LevelManager : MonoBehaviour {



    public int Word = 0;
    public float SceneTime = 160;
    public int StarNeeded=100;
    public int WinGemAtEnd = 2;
    public static int StarsInTheScene;
    public int HiddenStarsInScene;//Le stelle nascose (tipo che vengono droppate dai nemici) che non vengono contate all'inizio, le aggiungo manualmente qui
    public string LevelNumber;
    public Terrain terrain;
    public Renderer[] HideAtStart;
    public W_EndLevel endLevel;
    [Tooltip("Nome della scena successiva se questa viene portata a termine")]
    [Space(10)]
  //  public SceneField NextScena;
    public float TowerSize = 0;
    public bool FogOff;
    public bool IsBonusLevel; //Necessario per nascondere/disabilitare il pulsante Next Level
    Camera mainCam;
    [Multiline]
    public string LevelName_ITA;
    [Multiline]
    public string LevelName_ENG;
    public List<GameObject> ObjectToRespawnOnResume ;// IN CASO DI RESUME CON GEMME, RIATTIVARE QUESTI OGGETTI
    public GameObject DefaultREsumePOint;
    public bool CaduteListering=true;
    public bool ReplaceObjects = true;
    public GameObject[] HideGameObjectsAtStart;
    public float AddLifeToShot;
    public bool IsLastLevel;
    public bool UseIntro =false;
    public int SecretAreasInThisLevel;
    public string NextSceneName;
    public int FixedDetailObjectDistance;
    public int ShadowDistanceOverride;
    public bool StartUseHidden = false;
    [Space(10)]
    public float AddCadutaMultipler;
    public int AddAltitude=1 ;
    public int AddRemovePointsAtEnd = 0;
    public float AddRemoveGravity = 0;



    void Awake()
    {
        terrain = FindObjectOfType<Terrain>();
        StarsInTheScene = FindObjectsOfType<Star>().Length + HiddenStarsInScene;
        endLevel = FindObjectOfType<W_EndLevel>();
        

        mainCam = Camera.main;

        //Azzero le variabili statica per riaggiungere gli eventi sulle animazioni
        Alien01.EventsAdded = false;
        Neanderthal.EventsAdded = false;
        NeandertalBossApiedi.EventsAdded = false;
        Boss02.EventsAdded = false;
        Boss01.EventsAdded = false;
        W_playerController.EventsAdded = false;
        /////////

        //print("Found StarsInTheScene:" + StarsInTheScene);
        //foreach (Star st in FindObjectsOfType<Star>())
        //    print(st.name);

        foreach (Renderer ren in HideAtStart)
            ren.enabled = false;

        foreach (GameObject gObj in HideGameObjectsAtStart)
            if (gObj) gObj.SetActive(false);

        if (SceneManager.GetActiveScene().name.EndsWith("b"))
        { IsBonusLevel = true; }




    }
   
    void Start()
    {

        //Se il numero del livello appena iniziato è maggiore del numero del livello salvato  
        if (PlayerPrefs.GetInt(GameManager.Instance.AppName + "_LastLevel") < int.Parse(LevelNumber))
            PlayerPrefs.SetInt(GameManager.Instance.AppName + "_LastLevel", int.Parse(LevelNumber));


        System.GC.Collect();
        if (UseIntro)
        {
            GameManager.Instance.StopGlobalTime();
        }
     
       GameManager.Instance.GetSettingData();//Riprendo i dati dal PlayerPref

        if (StartUseHidden)
            GameUI.Instance.HideUseButton();
        else
            GameUI.Instance.ShowUseButton();

        ObjectToRespawnOnResume = new List<GameObject>();// IN CASO DI RESUME CON GEMME, RIATTIVARE QUESTI OGGETTI
        GameManager.LastCheckPoint = Vector3.zero;//Ad inizio livello azzero il punto di respawn

        if (DefaultREsumePOint)
            GameManager.LastCheckPoint = DefaultREsumePOint.transform.position;//Se c'è un punto di default di ripristino

        //Se si è caricato un livello Bonus, disabilita il pulsante Nex Level
        if (IsBonusLevel) {
            //  GameUI.Instance.NextLevelButton.interactable = false;
            GameUI.Instance.NextLevelButton.gameObject.SetActive(false);
        }

        //  Controllo la qualità salvata
        if (PlayerPrefs.GetString(GameManager.Instance.AppName + "_Quality").Equals("Low")){
            GameManager.Instance.quality = GameManager.Quality.Low;
            QualitySettings.SetQualityLevel(0);
        }else if (PlayerPrefs.GetString(GameManager.Instance.AppName + "_Quality").Equals("Med"))
        {
            GameManager.Instance.quality = GameManager.Quality.Med;
            QualitySettings.SetQualityLevel(1);
        }
       else if (PlayerPrefs.GetString(GameManager.Instance.AppName + "_Quality").Equals("Hi"))
        {
            GameManager.Instance.quality = GameManager.Quality.Hi;
            QualitySettings.SetQualityLevel(2);
        }



        if (QualitySettings.GetQualityLevel() == 2) //Hi
        {
            if(terrain) terrain.detailObjectDistance = 50;
          // RenderSettings.fog = true;
        }
        else if (QualitySettings.GetQualityLevel() == 1) //Med
        {
            if (terrain) terrain.detailObjectDistance = 20;
            // RenderSettings.fog = false;
            if (mainCam.GetComponent<Antialiasing>())
                mainCam.GetComponent<Antialiasing>().enabled = false;
        }
        else if (QualitySettings.GetQualityLevel() == 0) //Low
        {
            if (terrain) terrain.detailObjectDistance = 10;
            if (mainCam.GetComponent<Antialiasing>())
                mainCam.GetComponent<Antialiasing>().enabled = false;
            // RenderSettings.fog = false;
        }
        //Cose da azzerare allo start di ogni livello
        GameManager.PlayerIsDead = GameManager.LevelComplete = GameManager.Lose = false;
        GameManager.Instance.SetGameState(GameManager.Game_State.Running);
        MusicManager.StopFade();

        //Per sicurezza, disattivo l'invulnerabilità (potrei aver dimenticato la spunta attiva nei test in qualche livello)
        //Ma solo se esiste il menu, vuol dire che è la build o che almeno si viene dal menu
        if (MainMenu.Instance)
            GameManager.m_Character.IsInvulnerabile = false;

        if (FogOff) RenderSettings.fog = false;
        if (terrain&&FixedDetailObjectDistance != 0) terrain.detailObjectDistance = FixedDetailObjectDistance;

        print("<color=FFFFFF>Level</color>: " + (GameManager.Instance.AppName + "LevN_" + GameManager.ThisLevelManager.LevelNumber)+
           "<color=FFFFFF>ThisOldLevelPoint</color>:" +
           PlayerPrefs.GetInt(GameManager.Instance.AppName + "LevN_" + GameManager.ThisLevelManager.LevelNumber));



        if (GameManager.Instance.lang == GameManager.Lang.English)
            GameUI.Instance.LevelNameOnUI.text = LevelName_ENG.ToString();
        else if (GameManager.Instance.lang == GameManager.Lang.Italian)
            GameUI.Instance.LevelNameOnUI.text = LevelName_ITA.ToString();

       

        if (ShadowDistanceOverride != 0) QualitySettings.shadowDistance = ShadowDistanceOverride;

        GameManager.MiniOptionsMenu.GetComponent<MiniOptionsMenu>().GetSettingData();
        GameManager.MiniOptionsMenu.GetComponent<MiniOptionsMenu>().SettingDataUpdate();


        W_WorldScores.enableUpdate = true;





    }

}
