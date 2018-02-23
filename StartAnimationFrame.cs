using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationFrame : MonoBehaviour {

    Animator thisAnim;
    public string AnimatorState;
    [Range(0,1)]
    public float StartPoint;
    public bool Randomize;

    void Start()
    {
        thisAnim = GetComponent<Animator>();
        if (Randomize)
        {
            thisAnim.Play(AnimatorState, -1, Random.Range(0.0f, 1.0f));
        }
        else { thisAnim.Play(AnimatorState, -1, StartPoint); }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
