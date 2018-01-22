using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Questo script setta il testo in base alla lingua scelta
//In pratica mette nel componente TEXT di questo gameObject la stringa
//ITA_Text se sul GameManager è settato ITA
//ENG_Text se sul GameManager è settato ENG

[RequireComponent(typeof(Text))]
public class W_Language : MonoBehaviour
{

    [TextArea(3, 10)]
    public string ITA_Text;
    [TextArea(3, 10)]
    public string ENG_Text;
    public static W_Language[] AllTexts;//Lo trovo dal GameManager perchè viene eseguita prima
    public int ITA_fontSize;
    public int ENG_fontSize;

    void Awake()
    {

      

    }


        void SetSize()
    {


        if (GameManager.Instance.lang == GameManager.Lang.Italian && ITA_fontSize != 0)
            GetComponent<Text>().fontSize = ITA_fontSize;

        if (GameManager.Instance.lang == GameManager.Lang.English && ENG_fontSize != 0)
            GetComponent<Text>().fontSize = ENG_fontSize;
    }

    void Start()
    {


        CheckThisLang(false);


    }

   void OnEnable()
    {

        CheckThisLang(false);
    }

    public void CheckThisLang(bool FromPlayerPref)
    {

        if (FromPlayerPref) {

            if (PlayerPrefs.GetString("Oky" + "_Language") == "Italian")
                Set_ITA();

            else if (PlayerPrefs.GetString("Oky" + "_Language") == "English")
                Set_ENG();
        }
        else
        {
            if (!GameManager.Instance) return;
            if (GameManager.Instance.lang == GameManager.Lang.Italian)
                Set_ITA();

            if (GameManager.Instance.lang == GameManager.Lang.English)
                Set_ENG();
        }
    }


    //Metodo statico che esegue lo swithc su tutti i testi trovati
    static public void CheckLang()
    {
        AllTexts = FindObjectsOfType<W_Language>();

        foreach (W_Language lansw in AllTexts)
                lansw.CheckThisLang(false);
       
    }

    //Metodo statico che esegue lo swithc su tutti i testi trovati (se non c'è il GameManager legge dal PlayerPref)
    static public void CheckLangFromPref()
    {
        AllTexts = FindObjectsOfType<W_Language>();

        foreach (W_Language lansw in AllTexts)
            lansw.CheckThisLang(true);

    }

    public void Set_ITA()
    {

        if (GetComponent<Text>())
        {
            GetComponent<Text>().text = ITA_Text;
        }
        if (GameManager.Instance)
                SetSize();
    }

    public void Set_ENG()
    {

        if (GetComponent<Text>())
        {
            GetComponent<Text>().text = ENG_Text;
        }

        if (GameManager.Instance)
            SetSize();
    }


    // C#
    // returns "en" / "de" / ...
    public static string GetAndroidLanguage()
    {
#if UNITY_ANDROID
        try
        {
            var locale = new AndroidJavaClass("java.util.Locale");
            var localeInst = locale.CallStatic<AndroidJavaObject>("getDefault");
            var name = localeInst.Call<string>("getLanguage");
            return name;
        }
        catch (System.Exception e)
        {
            return "Error";
        }
#else
     return "Not supported";
#endif
    }

    // returns "eng" / "deu" / ...
    public static string GetAndoridISO3Language()
    {
#if UNITY_ANDROID
        try
        {
            var locale = new AndroidJavaClass("java.util.Locale");
            var localeInst = locale.CallStatic<AndroidJavaObject>("getDefault");
            var name = localeInst.Call<string>("getISO3Language");
            return name;
        }
        catch (System.Exception e)
        {
            return "Error";
        }
#else
     return "Not supported";
#endif
    }
    public void DeactivateGameObject()
    {

      gameObject.SetActive(false);
    }
}
