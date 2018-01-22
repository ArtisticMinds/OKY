using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_LeaderBcrollablePanel : MonoBehaviour {


    public static W_LeaderBcrollablePanel instance;
    public int WorldNumber = 5;
    public CanvasGroup NextArrow;
    public CanvasGroup PrevArrow;
    public Vector3 TargetPosition;
    public static int PanelOnScreen;

    void Awake()
    {
        instance = this;
    }

    public static void nextPanel()
    {

        instance.TargetPosition += (Vector3.left * MainMenu.Instance.LevelsPanelStep);

        PanelOnScreen++;

        instance.ArrowUpdate();
    }

    void OnEnable()
    { instance.ArrowUpdate(); }

    public static void prevPanel()
    {
        instance.TargetPosition -= (Vector3.left * MainMenu.Instance.LevelsPanelStep);

        PanelOnScreen--;

        instance.ArrowUpdate();

    }

    void ArrowUpdate()
    {
        if (PanelOnScreen == 0)
            instance.PrevArrow.interactable = false;
        else
            instance.PrevArrow.interactable = (true);

        if (PanelOnScreen == WorldNumber - 1)
            instance.NextArrow.interactable = (false);
        else
            instance.NextArrow.interactable = (true);


        //Per inizio test, se c'è solo un mondo, non attivare le frecce
        if (WorldNumber == 1)
        {
            instance.NextArrow.interactable = (false);
            instance.PrevArrow.interactable = (false);
        }
    }

    void Update()
    {
        instance.GetComponent<RectTransform>().localPosition = Vector3.Lerp(instance.GetComponent<RectTransform>().localPosition, instance.TargetPosition, Time.unscaledDeltaTime * 10);


    }
}
