using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoActivation : MonoBehaviour {


    public bool AutoActivate = true;
    public float ActivationTime;
    public float RandomRange;
    public bool DeactivateAtAwake=true;
    public bool DeactivateAtStart;
    public bool AutoDeactivate ;
    public float DeactivationTime;
    public bool UseOnEnable = false;

    void Awake () {
        RandomRange = Random.Range(0, RandomRange);

        if(AutoActivate)
        Invoke("Activation", ActivationTime+ RandomRange);

        if(DeactivateAtAwake)
        gameObject.SetActive(false);


	}

    void Start()
    {
        if (UseOnEnable) return;
        if (DeactivateAtStart)
            gameObject.SetActive(false);

        if (AutoDeactivate)
            Invoke("DeActivation", DeactivationTime);
    }


    void OnEnable()
    {
        if (!UseOnEnable) return;
        if (DeactivateAtStart)
            gameObject.SetActive(false);

        if (AutoDeactivate)
            Invoke("DeActivation", DeactivationTime);
    }


    void Activation () {
        gameObject.SetActive(true);
    }


    void DeActivation()
    {
        gameObject.SetActive(false);
    }
}
