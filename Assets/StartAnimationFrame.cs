using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationFrame : MonoBehaviour
{

    Animator thisAnim;
    public string AnimatorState;
    [Range(0, 1)]
    public float StartPoint;
    public bool Randomize;
    [Range(0,1)]
    public float RandomMinRange=0.1f;
    [Range(0, 1)]
    public float RandomMaxRange=0.9f;
    void Start()
    {
        thisAnim = GetComponent<Animator>();
        if (Randomize)
        {
            thisAnim.Play(AnimatorState, -1, Random.Range(RandomMinRange, RandomMaxRange));
        }
        else { thisAnim.Play(AnimatorState, -1, StartPoint); }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
