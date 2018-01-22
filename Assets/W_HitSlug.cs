using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_HitSlug : MonoBehaviour {

    public float Duration = 5;
    public ParticleSystem DestroyEffect;
    public float Power = 0.2f;

    void Awake()
    {

    }

    void Start()
    {
        Destroy(gameObject, Duration);

        if (DestroyEffect) DestroyEffect.GetComponent<AutoDestruct>().enabled = false;
    }




    void OnDestroy()
    {
        if (DestroyEffect)
        {
            DestroyEffect.Emit(3);
            DestroyEffect.transform.SetParent(null);
            DestroyEffect.GetComponent<AutoDestruct>().enabled = true;
        }


    }
}
