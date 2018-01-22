using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class Star : MonoBehaviour {


   AutoMoveAndRotate rotateAndMove;
   public float RotatioDelay;
   public int Points = 100;
   public GameObject ParticleOnDestroy;
   public AudioClip sound;
   Renderer mainRender;
   ParticleSystem ParticleS;

    void Awake()
    {
        rotateAndMove = GetComponent<AutoMoveAndRotate>();
        if (RotatioDelay > 0) {
            if (rotateAndMove)
                rotateAndMove.enabled = false;
        }

        mainRender = GetComponent<Renderer>();
        if (!mainRender) mainRender = GetComponentInChildren<Renderer>(true);
        if (!ParticleS) ParticleS = GetComponentInChildren<ParticleSystem>(true);
        rotateAndMove.enabled = false;
        mainRender.enabled = false;
        ParticleS.gameObject.SetActive(false);
    }
    

    public void Delete() {

        GameObject.Instantiate(ParticleOnDestroy,transform.position,transform.rotation);
        Destroy(gameObject);

    }

    void OnTriggerEnter(Collider col)
    {
      //  print(col.tag);

        if (!rotateAndMove) return;
        if (col.tag == "MainCamera")
        {
            rotateAndMove.enabled = true;
            mainRender.enabled = true;
            ParticleS.gameObject.SetActive(true);
        }
   

    }
    void OnTriggerExit(Collider col)
    {
        if (!rotateAndMove) return;
        if (col.tag == "MainCamera")
        {
            rotateAndMove.enabled = false;
            mainRender.enabled = false;
            ParticleS.gameObject.SetActive(false);
        }
    }

    void ActivateRotation()
    {
        rotateAndMove.enabled = true;
        CancelInvoke("ActivateRotation");
    }


}
