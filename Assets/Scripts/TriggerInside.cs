using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TriggerInside : MonoBehaviour {


    Transform ThisSapwnPoint;
    bool stay;
    public static Transform _sapwnPoint;//Cambia ad ogni spawn, viene inviato dal TriggerInside

    void Awake () {
        //Prendi il sapwnPoint di questo Trigger
        ThisSapwnPoint = transform.GetChild(0);

    }

    void OnTriggerEnter(Collider col) {


        if (GameManager.cameraMovements.ToRotation) return;

        if (col.tag.Equals("Player"))
        {
            //Entra nel trigger
            stay = true;
            GameManager._sapwnPoint = ThisSapwnPoint;
            BlinkUseButton.Active();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag.Equals("Player"))
        {
            //Esce dal trigger
            stay = false;
            BlinkUseButton.DeActive();
        }
    }


    void FixedUpdate() {

        if (GameManager.PlayerIsDead || GameManager.LevelComplete || GameManager.Lose) return;

        //Se sta sotto al trigger e non è già prenotata una rotazione
        if (stay&&!GameManager.cameraMovements.ToRotation)
        if (CrossPlatformInputManager.GetButton("Inside") || Input.GetKey(KeyCode.W))
        {
           GameManager.cameraMovements.ToRotation = true;//Segnala che una rotazione è stata "prenotata"
           StartCoroutine(GameManager.cameraMovements.StartRotation180()); //Prenota la rotazione
                stay = false;
        }
    }
}
