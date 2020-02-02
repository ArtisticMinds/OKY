using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideInEditor : MonoBehaviour {

    public bool HideinBuild=true;
    public bool HideIfLogged = true;

    void Start () {
        if (HideinBuild)
            if (!Application.isEditor)
                gameObject.SetActive(false);

        Invoke("UpdateButtonState", 2);
    }

    public void UpdateButtonState() {

        if (HideIfLogged)
            if (Social.localUser.authenticated)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);

    }
}
