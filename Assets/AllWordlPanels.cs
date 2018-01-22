using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllWordlPanels : MonoBehaviour {

   public static AllWordlPanels instance;
   public int WorldNumber = 5;
   public CanvasGroup NextArrow;
   public CanvasGroup PrevArrow;
   public Vector3 TargetPosition;
   public static int PanelOnScreen;


    void Awake () {
        instance = this;
        //Prendo il mondo su cui si stava giocando per poter riaprire il gioco direttamente su quella schermata
        SetStartWorld(PlayerPrefs.GetInt(GameManager.Instance.AppName + "LastWorld"));
        instance.ArrowUpdate();
    }

    public static void nextWordPanel()
    {

        instance.TargetPosition += (Vector3.left * MainMenu.Instance.LevelsPanelStep);

        PanelOnScreen++;

        instance.ArrowUpdate();
    }

   void OnEnable()
    {
 }

    public static void prevWordPanel()
    {
        instance.TargetPosition -= (Vector3.left * MainMenu.Instance.LevelsPanelStep);

        PanelOnScreen--;

        instance.ArrowUpdate();

    }

    void ArrowUpdate()
    {
        if (PanelOnScreen == 0)
            instance.PrevArrow.interactable=false;
        else
            instance.PrevArrow.interactable=(true);

        if (PanelOnScreen == WorldNumber-1)
            instance.NextArrow.interactable=(false);
        else
            instance.NextArrow.interactable=(true);


    }
   public void SetStartWorld(int ShowWorld) {

        if (ShowWorld == 0) return;
       
        instance.TargetPosition+=(Vector3.left * MainMenu.Instance.LevelsPanelStep)* (ShowWorld);

        instance.GetComponent<RectTransform>().localPosition = instance.TargetPosition;
        PanelOnScreen += ShowWorld;

        print("GetAndShowWorldPanel: " + ShowWorld);

    }


    void Update () {
        instance.GetComponent<RectTransform>().localPosition = Vector3.Lerp(instance.GetComponent<RectTransform>().localPosition, instance.TargetPosition,Time.unscaledDeltaTime*10);

    }
}
