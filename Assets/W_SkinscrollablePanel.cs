
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_SkinscrollablePanel : MonoBehaviour
{

    public static W_SkinscrollablePanel instance;
    public int PagesNumber = 5;
    public CanvasGroup NextArrow;
    public CanvasGroup PrevArrow;
    public Vector3 TargetPosition;
    public static int PanelOnScreen;
    public int ScrollStep=650;
    static int _ScrollStep;
    public RectTransform ScrollContent;

    void Awake()
    {
        instance = this;
        _ScrollStep = ScrollStep;
    }

    public static void nextPanel()
    {

        instance.TargetPosition += (Vector3.left * _ScrollStep);

        PanelOnScreen++;

        instance.ArrowUpdate();
    }

    void OnEnable()
    { instance.ArrowUpdate(); }

    public static void prevPanel()
    {
        instance.TargetPosition -= (Vector3.left * _ScrollStep);

        PanelOnScreen--;

        instance.ArrowUpdate();

    }

    void ArrowUpdate()
    {
        if (PanelOnScreen == 0)
            instance.PrevArrow.interactable = false;
        else
            instance.PrevArrow.interactable = (true);

        if (PanelOnScreen == PagesNumber - 1)
            instance.NextArrow.interactable = (false);
        else
            instance.NextArrow.interactable = (true);


        //Per inizio test, se c'è solo un mondo, non attivare le frecce
        if (PagesNumber == 1)
        {
            instance.NextArrow.interactable = (false);
            instance.PrevArrow.interactable = (false);
        }
    }



    //Pulsante YES sul pannello di sblocco Skin
    public void BuySkin(int SkinID,int Cost)
    {

        
        W_GemManager._istance.BuySkin(SkinID,Cost);
        MainMenu.BuySkinDialog.SetActive(false);
        foreach (OkySkinButton but in FindObjectsOfType<OkySkinButton>())
            but.UpdateStatus();

    }






    void Update()
    {
        ScrollContent.localPosition = Vector3.Lerp(ScrollContent.localPosition, instance.TargetPosition, Time.unscaledDeltaTime * 10);


    }
}
