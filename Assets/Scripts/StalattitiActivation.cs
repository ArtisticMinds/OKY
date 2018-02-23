using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalattitiActivation : MonoBehaviour {

   public stalttite[] stal;


   static public bool InStay;


	void Start () {
        stal = GetComponentsInChildren<stalttite>();

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Player"))
        {

            foreach (stalttite st in stal)
                st.enabled = true;

            InStay = true;

        }
        }


    private void OnTriggerExit(Collider col)
    {
        if (col.tag.Equals("Player"))
        {

            foreach (stalttite st in stal)
                st.enabled = false;

            InStay = false;
        }
    }
}
