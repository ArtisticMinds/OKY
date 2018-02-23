using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrecciaInizio : MonoBehaviour {
    
	void OnEnable () {

       if(PlayerPrefs.GetInt(GameManager.Instance.AppName + "LevN_" + 1) > 0)
            gameObject.SetActive(false);
       else
            gameObject.SetActive(true);
    }
	

}
