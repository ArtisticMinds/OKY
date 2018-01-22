using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RestoreCanvasAplha : MonoBehaviour {

    public float Delay;

	void Awake () { //28/8 da Star ad Awake

        Invoke("AlphaCanvasTo1",Delay);
    }
	

	void AlphaCanvasTo1 () {
        GetComponent<CanvasGroup>().alpha = 1;
    }
}
