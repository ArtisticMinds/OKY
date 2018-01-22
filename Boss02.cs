using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02 : MonoBehaviour {

    public Animator animaMammut;
    public Animator animaNeanderthal;
    public ParticleSystem ShotEffect;


void Awake()
    {

        AddEvent(animaNeanderthal, 1, 0.5f, "NeanderthalShot", 0);


    }
    void AddEvent(Animator animator, int Clip, float time, string functionName, float floatParameter)
    {

        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.functionName = functionName;
        animationEvent.floatParameter = floatParameter;
        animationEvent.time = time;
        AnimationClip clip1 = animator.runtimeAnimatorController.animationClips[Clip];
        clip1.AddEvent(animationEvent);

    }



   public void NeanderthalShot() {
		
	}
	
	
	void Update () {
		
	}
}
