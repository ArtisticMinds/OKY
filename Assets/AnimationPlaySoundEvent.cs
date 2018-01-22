using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AnimationPlaySoundEvent : MonoBehaviour {

    AudioSource source;


    void Start () {
        source = GetComponent<AudioSource>();
 
    }
	

	public void PlaySound (AudioClip clip) {
        if (Time.timeSinceLevelLoad > 2)
            if (source) source.PlayOneShot(clip);

    }
}
