using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniOptionsMenu : MonoBehaviour {

    static public MiniOptionsMenu Instance;

    public Slider SoundsVol_Slider;
    public Slider MusicVol_Slider;
    public Slider UIScale_Slider;
    public Slider CameraDistance_Slider;
    public Slider UITransparence_Slider;
    public Text SizeValue;
    public GameObject _noMusic;
    public GameObject _noSounds;


    void Awake()
    {
        Instance = this;
    }


        void Start () {

        GetSettingData();

    }

    //Eseguito all'apertura del MiniMenu
   public void GetSettingData()
    {

        //Setto le posizioni degli Slider in base a ciò che è salvato sul PlayerPref
        if (!GameManager.Instance.PrimoAvvio)
        {
            //Predo i dati salvati
            MusicVol_Slider.value = PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_MusicVolume");
            SoundsVol_Slider.value = PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_SoundsVolume");
            UIScale_Slider.value = PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_UIScale");
            CameraDistance_Slider.value = PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_CameraDistance");
            UITransparence_Slider.value= PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_UITransparence");
        }
        else
        {
            MusicVol_Slider.value = 10f;
            SoundsVol_Slider.value = 10f;
            CameraDistance_Slider.value = 22.5f;
            UITransparence_Slider.value = 1f;
            UIScale_Slider.value = 1.3f;
        }


        //Assegno i volori deli slider alle variabili (al loading dei valori salvati)
        GameManager.Instance.MasterMixer.SetFloat("SoundsVolume", (SoundsVol_Slider.value * GameManager.Instance.AudioMultipler) - 20);
        GameManager.Instance.MasterMixer.SetFloat("MusicVolume", (MusicVol_Slider.value * MusicManager.MusicAmplifer) - 20);
        GameManager.ControlsUIScale = UIScale_Slider.value;
        GameManager.Instance.CameraDistance = CameraDistance_Slider.value;

        print("<color=green>Get saved SoundsVol:</color> " + PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_MusicVolume"));
        print("<color=green>Get saved MusicVol:</color> " + PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_SoundsVolume"));
        print("<color=green>Get saved _UIScale:</color> " + PlayerPrefs.GetString(GameManager.Instance.AppName + "_UIScale"));
        print("<color=green>Get saved CameraDistance:</color> " + PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_CameraDistance"));
        print("<color=green>Get saved UITransparence:</color> " + PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_UITransparence"));

        ////Limito il suono
        if (SoundsVol_Slider.value <= -0.01f) GameManager.Instance.MasterMixer.SetFloat("SoundsVolume", -100);
        if (MusicVol_Slider.value <= -0.01f) GameManager.Instance.MasterMixer.SetFloat("MusicVolume", -100);

       // W_Language.CheckLang();
    }

    //Eseguito in Update se aperto il MiniMenu opzioni
   public void SettingDataUpdate()
    {


        //////Assegno i volori deli slider alle variabili (a runtime, mentre li modifica l'utente)
       GameManager.Instance.MasterMixer.SetFloat("SoundsVolume", (SoundsVol_Slider.value * GameManager.Instance.AudioMultipler) - 20);
       GameManager.Instance.MasterMixer.SetFloat("MusicVolume", (MusicVol_Slider.value * MusicManager.MusicAmplifer) - 20);
       GameManager.ControlsUIScale = UIScale_Slider.value;
       GameManager.Instance.CameraDistance = CameraDistance_Slider.value;
       GetUIScale.UIAlpha = UITransparence_Slider.value;

        SizeValue.text = "x" + System.Math.Round(GameManager.ControlsUIScale, 2);

        ////Limito il suono e nel caso, visualizzo le icone NoSuond
        if (SoundsVol_Slider.value <= 0.01f) { GameManager.Instance.MasterMixer.SetFloat("SoundsVolume", -100); _noSounds.SetActive(true); } else { _noSounds.SetActive(false); }
        if (MusicVol_Slider.value <= 0.01f) { GameManager.Instance.MasterMixer.SetFloat("MusicVolume", -100); _noMusic.SetActive(true); } else { _noMusic.SetActive(false); }


        Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, GameManager.Instance.CameraDistance + GameManager.ThisLevelManager.TowerSize);
        GetUIScale.UpdateAll();
    }


    public void SaveSetting()
    {
        if (!GameManager.Instance.SoundsVol_Slider)
        {
            print("No Saving - No MainMenu");
            return;
        }
        PlayerPrefs.SetFloat(GameManager.Instance.AppName + "_SoundsVolume", SoundsVol_Slider.value);
        PlayerPrefs.SetFloat(GameManager.Instance.AppName + "_MusicVolume", MusicVol_Slider.value);
        PlayerPrefs.SetFloat(GameManager.Instance.AppName + "_UIScale",UIScale_Slider.value);
        PlayerPrefs.SetFloat(GameManager.Instance.AppName + "_CameraDistance", CameraDistance_Slider.value);
        PlayerPrefs.SetFloat(GameManager.Instance.AppName + "_UITransparence", UITransparence_Slider.value);

        PlayerPrefs.Save();

     //   GameManager.Instance.UIScale_Slider.value = UIScale_Slider.value;
        GameManager.Instance.MusicVol_Slider.value = MusicVol_Slider.value;
        GameManager.Instance.SoundsVol_Slider.value = SoundsVol_Slider.value;
        GameManager.Instance.CameraDistance = CameraDistance_Slider.value;
        GetUIScale.UIAlpha = UITransparence_Slider.value;

        print("<color=magenta>Saving (formMiniMenu) UIScale:</color> " + UIScale_Slider.value);
        print("<color=magenta>Saving (formMiniMenu) SoundsVol:</color> " + SoundsVol_Slider.value);
        print("<color=magenta>Saving (formMiniMenu) MusicVol:</color> " + MusicVol_Slider.value);
        print("<color=magenta>Saving (formMiniMenu) CameraDistance:</color> " + CameraDistance_Slider.value);
        print("<color=magenta>Saving (formMiniMenu) CameraDistance:</color> " + UITransparence_Slider.value);

        //Ad ogni cambiamento nelle opzioni devo ristabilire la posizione originale della telecamera con ls CameraDistance scelta dal player
        if (GameManager.cameraShake)
        GameManager.cameraShake.originalPos = new Vector3(GameManager.cameraShake.originalPos.x, GameManager.cameraShake.originalPos.y, GameManager.Instance.CameraDistance);

    }

    void OnDisable() {
        
        SaveSetting();
    }



    void Update() {
        W_Joystik.Instance.UpdatePosition();
        SettingDataUpdate();
    }
}
