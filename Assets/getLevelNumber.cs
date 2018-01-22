using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getLevelNumber : MonoBehaviour {

	
	void Start () {
        //  Imposta il dropMenu in base al GameManager
        if (GameManager.Instance.lang == GameManager.Lang.English)
            GetComponent<Text>().text = GameManager.ThisLevelManager.LevelName_ENG.ToString();
        else if (GameManager.Instance.lang == GameManager.Lang.Italian)
            GetComponent<Text>().text = GameManager.ThisLevelManager.LevelName_ITA.ToString();

    }
	

}
