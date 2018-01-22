using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideTrigger : MonoBehaviour {

    public string Message;

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.root.tag.Equals("Player"))
            Guide.Istance.gameObject.SendMessage(Message);
    }
}
