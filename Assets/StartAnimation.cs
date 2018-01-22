using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartAnimation : MonoBehaviour {
    
	void Awake() {
        Screen.sleepTimeout = (int)0f;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //Check if PD_PrimoAvvio key exist. 
        if (PlayerPrefs.GetInt("Oky" + "_PrimoAvvio", 0) == 0)
        {
            print("Apply default language: <color=withe>" + Application.systemLanguage + "</color>");

            //Al primo avvio usa sempre la lingua di sistema
            if (Application.systemLanguage.ToString() == "English")
                PlayerPrefs.SetString("Oky" + "_Language", "English");

            else if (Application.systemLanguage.ToString() == "Italian")
                PlayerPrefs.SetString("Oky" + "_Language", "Italian");
        }

            W_Language.CheckLangFromPref();
    }




    void SceneJump()
    {

        //Qualunque tocco a schermo
        if (Input.touchCount > 0 || (Input.GetKeyDown(KeyCode.Escape)) || Input.GetKeyDown(KeyCode.Menu) || Input.GetKeyDown(KeyCode.Home))
            SceneManager.LoadScene(1);//Carica il menu

    }


    void Update() {

        if (PlayerPrefs.GetInt("Oky" + "_PrimoAvvio", 0) == 0) return; //Non se è il primo avvio

        SceneJump();

    }

     
}
