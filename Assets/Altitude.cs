using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Altitude : MonoBehaviour {


    Text text;
    float alt;

    void Start () {
        text = GetComponent<Text>();

    }
	
	
	void Update () {
        
        alt = GameManager.m_Character.transform.position.y ;
       
        if (alt < -100) alt = -100;


        int finalData = Mathf.RoundToInt((alt+GameManager.ThisLevelManager.AddAltitude));

 


        text.text = finalData.ToString()+"m";
    }
}
