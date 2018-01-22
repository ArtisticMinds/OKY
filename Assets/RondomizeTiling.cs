using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RondomizeTiling : MonoBehaviour {

     Renderer rend;
    public bool animated;
    public float MinRandmValue = 0.5f;
    public float MaxRandmValue = 0.9f;

    public bool RandomizeMainColor;
    public float MinColorValue = 0.7f;
    public float MaxColorValue = 1.4f;

    void Start()
    {
        rend = GetComponent<Renderer>();
        float rand = Random.Range(MinRandmValue, MaxRandmValue);
        float ColorRand = Random.Range(MinColorValue, MaxColorValue);
        rend.material.mainTextureScale *=rand;
        if(RandomizeMainColor)
            rend.material.color *= ColorRand;
    }

    void Animate()
    {
        float scaleX = Mathf.Cos(Time.time) * 0.5F + 1;
        float scaleY = Mathf.Sin(Time.time) * 0.5F + 1;
        rend.material.mainTextureScale = new Vector2(scaleX, scaleY);
    }


    void Update()
    {
        if(animated)
        Animate();
    }
}