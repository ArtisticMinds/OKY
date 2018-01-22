using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mammuth : MonoBehaviour {

    public ParticleSystem PrecaricaEffect;
    public ParticleSystem CaricaEffect;
    public ParticleSystem IncorntaEffect;

    public GameObject CornaDeadTrigger;

    void Start () {
        CornaDeadTrigger.SetActive(false);

    }


    public void PrecaricaEmit()
    {

        PrecaricaEffect.Emit(5);

    }

    public void CaricaEmit()
    {
        CornaDeadTrigger.SetActive(true);
        CaricaEffect.Emit(15);

    }

    public void IncorntaEmit()
    {
        CornaDeadTrigger.SetActive(true);
        IncorntaEffect.Emit(2);
        PrecaricaEmit();

    }

    public void CornaDeadTriggerDeactivate() {
        CornaDeadTrigger.SetActive(false);
    }
    
}
