using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimation : MonoBehaviour {

    Animator anim;
	void Awake () {
        anim = GetComponent<Animator>();
       
    }
	
	// Update is called once per frame
	void Start () {
        if(anim)anim.Play(0);
        if (GameManager.Instance.debugMode)
        {
            Resume();
            GameManager.ThisLevelManager.UseIntro = false;
        }
    }

     public void Resume() {
        GameManager.Instance.ResumeGloabalTime();
        gameObject.SetActive(false);
            }


  

}
