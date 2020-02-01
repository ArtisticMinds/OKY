
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
[RequireComponent(typeof(ObjectNote))]
public class GemItem : MonoBehaviour
{


    AutoMoveAndRotate rotateAndMove;
    public float RotatioDelay;
    public int Value = 1;
    public GameObject ParticleOnDestroy;
    public AudioClip sound;
    public int GemID;

    void Awake()
    {
        if (GemID == 0) Destroy(gameObject);
        if (RotatioDelay > 0)
        {
            rotateAndMove = GetComponent<AutoMoveAndRotate>();

            rotateAndMove.enabled = false;
            Invoke("ActivateRotation", RotatioDelay);
        }
        GetComponent<ObjectNote>().Text = GemID.ToString();
    }


    //Dopo la raccolta della gemma
    public void Delete()
    {

        //Solo se c'è la connessione
        if (Social.localUser.authenticated && //Autenticato
            Application.internetReachability != NetworkReachability.NotReachable)
        { 
            PlayerPrefs.SetInt(GameManager.Instance.AppName + "_GemsIDGeted_" + GemID, 1); //Salva subito disco l'ID di questa gemma, se al caricamento risulta giù raccolta, cancellala
        }
        GameObject.Instantiate(ParticleOnDestroy, transform.position, transform.rotation);
        Destroy(gameObject);

    }

    void ActivateRotation()
    {
        rotateAndMove.enabled = true;
    }


}
