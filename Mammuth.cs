using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mammuth : MonoBehaviour {

    public ParticleSystem PrecaricaEffect;


    void Start () {
		
	}


    public void PrecaricaEmit()
    {

        PrecaricaEffect.Emit(5);

    }

}
