using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideInEditor : MonoBehaviour {

    public bool HideinBuild=true;

	void Start () {
        if (HideinBuild)
            if (!Application.isEditor)
                gameObject.SetActive(false);
        

	}
	

}
