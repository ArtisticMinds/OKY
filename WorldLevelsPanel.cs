using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldLevelsPanel : MonoBehaviour
{

    public int WorldN;


    public List<W_SceneItem> W_Levels = new List<W_SceneItem>();
    public SceneField[] scenes;

    public GameObject PannelloLivelli;
    public GameObject Loading;


    public static bool AllLevelsOpen;//Solo per me

    void OnEnable()
    {


        MainMenu.LoadingBar.fillAmount = 0;
        MainMenu.textPourcentage.text = "";
        if (MainMenu.LoadingPanel.activeInHierarchy) MainMenu.LoadingPanel.SetActive(false);




        //All'inizio disattivo tutti BonusLevels in attesa che siano stati creati tutti gli items dei livelli normai
        foreach (W_SceneItem bItem in BonusItems)
            bItem.gameObject.SetActive(false);
    }




    public void DisableClick()
    {

        foreach (W_SceneItem lev in W_Levels)
        {
            if (lev.GetComponent<CanvasGroup>())
                lev.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        print("DisableClick");
    }

    public void AbilitaClick()
    {
        foreach (W_SceneItem lev in W_Levels)
        {
            if (lev.GetComponent<CanvasGroup>())
                lev.GetComponent<CanvasGroup>().blocksRaycasts = true;


        }
    }




  
    public void Reset()
    {
   


        Loading.SetActive(false);

        if (PannelloLivelli.transform.childCount > 0)//Se c'è almeno un children
            foreach (Transform item in PannelloLivelli.transform.GetComponentInChildren<Transform>())
                Destroy(item.gameObject);//Cancella le icone dei livelli


    }


    void LateUpdate()
    {

    }

}
