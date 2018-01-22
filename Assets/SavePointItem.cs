using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SavePointItem : MonoBehaviour {

    public GameObject Normal;
    public GameObject Over;
    public GameObject Activated;

    void Start () {
        Normal.SetActive(true);
        Over.SetActive(false);
        Activated.SetActive(false);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.transform.root.tag.Equals("Player"))
        {
            Normal.SetActive(false);
            Over.SetActive(true);
        }


        if (GameManager.PlayerIsDead || GameManager.LevelComplete || GameManager.Lose) return;

        //Se sta sotto al trigger 
            if (CrossPlatformInputManager.GetButton("Inside") || Input.GetKey(KeyCode.W))
            {
            Normal.SetActive(false);
            Over.SetActive(false);
            Activated.SetActive(true);
            GetComponent<SphereCollider>().enabled = false;
             
       //Activate here



            }

    }


    void OnTriggerExit(Collider col)
    {
        if (col.transform.root.tag.Equals("Player"))
        {
            Normal.SetActive(true);
            Over.SetActive(false);
        }

    }
    void Update () {
		
	}
}
