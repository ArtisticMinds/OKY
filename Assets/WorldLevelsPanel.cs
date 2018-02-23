using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldLevelsPanel : MonoBehaviour
{

 
   // public SceneField[] scenes;

   // public GameObject PannelloLivelli;
    public GameObject Loading;


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

        //if (PannelloLivelli.transform.childCount > 0)//Se c'è almeno un children
        //    foreach (Transform item in PannelloLivelli.transform.GetComponentInChildren<Transform>())
        //        Destroy(item.gameObject);//Cancella le icone dei livelli


    }


    void LateUpdate()
    {

    }

}
