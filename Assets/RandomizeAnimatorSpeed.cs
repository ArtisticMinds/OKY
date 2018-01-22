using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAnimatorSpeed : MonoBehaviour {

    public float Min=0.8f;
    public float Max=1.2f;

    void Start () {
       
        GetComponent<Animator>().SetFloat("Speed", GetComponent<Animator>().GetFloat("Speed")* Random.Range(Min, Max));
	}
	

}
