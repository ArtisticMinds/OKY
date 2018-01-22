using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkUseButton : MonoBehaviour
{


    static Image UseActive;
    static Animation anim;


    void Awake()
    {

        UseActive = GetComponent<Image>();

    }
    private void Start()
    {
        DeActive();
    }

    public static void Active()
    {

        UseActive.enabled = true;

    }

    public static void DeActive()
    {

        UseActive.enabled = false;


    }
}
