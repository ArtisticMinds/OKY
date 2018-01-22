using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrab : MonoBehaviour {

    public float TimeForAction = 1;
    public float TimeRewindAction = 1;
    Animator ThisAnimator;


    void Start() {

        ThisAnimator = GetComponent<Animator>();
    }

    public void PlayerEnter() {
        Invoke("Action", TimeForAction);
	}
	

	void Action() {
        Invoke("Rewind", TimeRewindAction);
        ThisAnimator.SetBool("Activate", true);
    }

    void Rewind()
    {
        ThisAnimator.SetBool("Activate", false);
        Invoke("Stop", TimeRewindAction*2);
    }

}
