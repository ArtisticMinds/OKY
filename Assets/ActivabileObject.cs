using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivabileObject : MonoBehaviour {
    [HideInInspector]
    public bool Used;
    public bool StartUsed;
    Animator anima;
    public bool UsePauseResumeAnimation;


    void Start () {
        anima = GetComponent<Animator>();

        if (!anima) return;

        if (StartUsed)
        {

            if (UsePauseResumeAnimation) {
                anima.SetFloat("Speed", 1);
            } else { 

            anima.SetBool("Activate", true);//Animator
                
            }
            Used = true;
        }
        else
        {
            if (UsePauseResumeAnimation)
            {
                anima.SetFloat("Speed", 0);
            }
            else
            {
                anima.SetBool("Activate", false);//Animator
            }
            Used = false;
        }
	}
}
	


