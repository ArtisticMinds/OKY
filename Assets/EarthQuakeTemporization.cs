using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuakeTemporization : MonoBehaviour {

    public float _shakeDuration = 5;
    public float _shakeAmount = 4;
    public float _decreaseFactor = 4;
    public float TimeRepeating = 15;
    float randomization;

    void Start()
    {
        InvokeRepeating("QuakeNow", TimeRepeating, TimeRepeating + randomization);
    }

    void QuakeNow () {
        if(GameManager.cameraShake)
        GameManager.cameraShake.shakecamera(_shakeDuration+ randomization, _shakeAmount, _decreaseFactor);
        randomization = Random.Range(1, 10);
    }



}
