using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerShot : MonoBehaviour
{
    public Animator anim;
    public string ActiveBool;
    public GameObject ActivabileObject;
    [Range(0,1)]
    public float Probability=1;
    bool Enabled;
    BoxCollider coll;


    private void Start()
    {
        coll = GetComponent<BoxCollider>();
        ExitAction();
        InvokeRepeating("Randomize", 2, 2);
    }


    void Randomize() {

        if (Random.value <= Probability)
            coll.enabled = false;
        else
            coll.enabled = true;

    }

    void OnTriggerStay(Collider col)
    {
       
     
            if (col.tag.Equals("PlayerShot"))
            {
                Stay();

            }
    


    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag.Equals("PlayerShot"))
        {
            ExitAction();

        }


    }

    void Stay()
    {
        anim.SetBool(ActiveBool, true);
       if(ActivabileObject) ActivabileObject.SetActive(true);
    }

    void ExitAction()
    {
        anim.SetBool(ActiveBool, false);
        if (ActivabileObject) ActivabileObject.SetActive(false);
    }



}
