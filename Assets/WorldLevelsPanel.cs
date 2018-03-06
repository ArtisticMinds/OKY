using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldLevelsPanel : MonoBehaviour
{

 
    public W_SceneItem[] AllLevels;

   // public GameObject PannelloLivelli;
    public GameObject Loading;

    private void Awake()
    {
        AllLevels = FindObjectsOfType<W_SceneItem>();
    }

    public static bool AllLevelsOpen;//Solo per me

    void OnEnable()
    {


        MainMenu.LoadingBar.fillAmount = 0;
        MainMenu.textPourcentage.text = "";
        if (MainMenu.LoadingPanel.activeInHierarchy)
            MainMenu.LoadingPanel.SetActive(false);


    }






    public void Reset()
    {

        Loading.SetActive(false);

    }




}
