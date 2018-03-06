using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkUseButton : MonoBehaviour
{


    static Image UseActive;
    static Animation anim;
    static Image MainButton;
    static Text UseText;

    void OnEnable()
    {




    }
    private void Start()
    {
        UseActive = GetComponent<Image>();
        MainButton = transform.parent.GetComponent<Image>();
        UseText = transform.GetChild(0).GetComponent<Text>();
        DeActive();
    }

    public static void Active()
    {

        UseActive.enabled = true;
        MainButton.color = new Color(1f, 1f, 1f, 1f);
        UseText.color = new Color(0.6f, 1f, 0.5f,0.8f);
    }

    public static void DeActive()
    {

        UseActive.enabled = false;
        MainButton.color = new Color(0.6f, 0.6f, 0.6f, 0.6f);
        UseText.color = new Color(0.6f, 1f, 0.5f, 0.2f);

    }
}
