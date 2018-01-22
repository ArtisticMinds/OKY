using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour {

    public void GoToNextScene()
    {

            SceneManager.LoadScene(1);//Carica il menu

    }
}
