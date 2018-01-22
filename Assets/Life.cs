using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class Life : MonoBehaviour
{


    AutoMoveAndRotate rotateAndMove;
    public float RotatioDelay;
    public float LifePoints = 0.2f;
    public GameObject ParticleOnDestroy;
    public AudioClip sound;
    Renderer mainRender;

    void Awake()
    {

        rotateAndMove = GetComponent<AutoMoveAndRotate>();
        if (RotatioDelay > 0)
        {
            rotateAndMove.enabled = false;
            Invoke("ActivateRotation", RotatioDelay);
        }

        mainRender = GetComponent<Renderer>();
        if (!mainRender) mainRender = GetComponentInChildren<Renderer>(true);
        rotateAndMove.enabled = false;
        mainRender.enabled = false;

    }

    public void Delete()
    {
       // GameManager.ThisLevelManager.ObjectToRespawnOnResume.Add(gameObject);
        GameObject.Instantiate(ParticleOnDestroy, transform.position, transform.rotation);
        //Non distruggere ma disattiva solamente
        //Poi viene salvato tra gli oggetti da riattivare quando c'è un resume
        // if (respawnItemAtResume) gameObject.SetActive(false);
        // else

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
        }


    }
    void OnTriggerExit(Collider col)
    {
        if (!rotateAndMove) return;
        if (col.tag == "MainCamera")
        {
            rotateAndMove.enabled = false;
            mainRender.enabled = false;
        }
    }


    void ActivateRotation()
    {
        rotateAndMove.enabled = true;
        CancelInvoke("ActivateRotation");
    }


}
