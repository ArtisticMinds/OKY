using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeandertalOnMammuth : MonoBehaviour {

    public ParticleSystem ShotEffect;
    public GameObject LanciaPrefab;
    void Start () {
		
	}

    public void NeanderthalShot()
    {
        ShotEffect.Emit(5);

    }

}
