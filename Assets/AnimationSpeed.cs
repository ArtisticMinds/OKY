using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeed : MonoBehaviour {

    public float Speed = 1f;
    public float StarDelay;
    Animator anim;
    AudioSource source;
    Animation an;

    void Awake()
    {

        anim = GetComponent<Animator>();
        an = GetComponent<Animation>();

        source = GetComponent<AudioSource>();

        if(anim)
        anim.SetFloat("Speed", Speed);
        
       if (source)
           source.enabled = false;

    }



    void OnDisable () {
        if (source)
            source.enabled = false;
    }

    void OnEnable() {

        if (anim)
            anim.enabled = false;

        if (an)
            an.Stop();

        Invoke("Activate", StarDelay);

        if (source)
            source.enabled = true;

        if (anim)
            anim.SetFloat("Speed", Speed);
    }


    void Activate () {
        if (anim)
            anim.enabled = true;

        if (an)
            an.Play();

        if (source)
            source.enabled = true;
    }




    void Update() {

        if (source)
        {
            if (MainMenu.mainMenuIsActive)
                source.volume = 0;
            else
                source.volume = 1;
        }
    }
}
