using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_platform : MonoBehaviour {

    public Transform movingPlatform;
    Vector3 OrPosition;
    public Transform position01;
    public Transform position02;
    public Transform newPosition;
    public float OkyMinDistanceAnimator = 30;
    float  dist;
    public float smooth;
    public bool Active = true;
    public int ChangePosTime=2;
    float TimerFromCreation;
    public bool isKinematic;

    void Start () {

        if (isKinematic) return;

        position01.SetParent(null);
        position02.SetParent(null);
        position01.GetComponent<Renderer>().enabled = false;
        position02.GetComponent<Renderer>().enabled = false;
        newPosition = position02;
        TimerFromCreation = 0;


        InvokeRepeating("ChangeTarget", ChangePosTime, ChangePosTime);

    }


    void ChangeTarget() {
        if (dist < OkyMinDistanceAnimator)
        {
            if (!Active) { return; }

            if (newPosition == position01)
            {
                newPosition = position02;
                return;
            }
            if (newPosition == position02)
            {

                newPosition = position01;
                return;
            }
        }
    }


    void FixedUpdate()
    {
        if (!GameManager.m_Character) return;
        if (isKinematic) return;

        if (TimerFromCreation < 2)
            TimerFromCreation += Time.deltaTime * GameManager.TimeMultipler;


        dist = Vector3.Distance(GameManager.m_Character.transform.position, transform.position);
        if (dist < OkyMinDistanceAnimator)
  
        {
            if (!Active) { return; }
            movingPlatform.position = Vector3.Lerp(movingPlatform.position, newPosition.position, smooth * Time.deltaTime * GameManager.TimeMultipler);
            movingPlatform.rotation = Quaternion.Lerp(movingPlatform.rotation, newPosition.rotation, smooth * Time.deltaTime * GameManager.TimeMultipler);
        }
    }

}
