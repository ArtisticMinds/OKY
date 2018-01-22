using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MammuthArea : MonoBehaviour {

    public Transform Mammuth;
    public Boss02 boss2;
    public Transform neandertalBossApiedi;



	void Start () {
		
	}


    private void OnTriggerStay(Collider other)
    {
        if (other.transform == Mammuth)
        {
            boss2.indietreggia = true;
        }
        else if(other.transform == neandertalBossApiedi)
        { boss2.neandertalindietreggia = true; }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == Mammuth)
        {
            boss2.indietreggia = false;
        }
        else if (other.transform == neandertalBossApiedi)
        { boss2.neandertalindietreggia = false; }
    }


    void Update () {
		
	}
}
