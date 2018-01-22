using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkUseButton : MonoBehaviour {


    static Image UseActive;


	void Awake () {

        UseActive = GetComponent<Image>();
    }
    private void Start()
    {
        UseActive.enabled = false;
    }

    public static void Active () {

        UseActive.enabled = true;
    }

    public static void DeActive()
    {

        UseActive.enabled = false;
    }
}
