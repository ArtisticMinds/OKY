using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayerPrefData : MonoBehaviour {

    Text TextUI;
    public string PlayerPrefKey;


    void Start () {

        TextUI = GetComponent<Text>();
        GetData();
    }

   // Prende i dati dal PlayerPrefKey specificato e li mette sul testo
    public void GetData () {
        TextUI.text = PlayerPrefs.GetInt(PlayerPrefKey).ToString();
    }


}
