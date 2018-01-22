using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachAndFollow : MonoBehaviour {

    Rigidbody m_parent;
	void Start () {
        m_parent = transform.parent.GetComponent<Rigidbody>();
        transform.SetParent(null);
        transform.eulerAngles = new Vector3(90, 0, 0);
    }

    void Update() {

        if (m_parent) {
            transform.position = m_parent.position;
            

        } else{ Destroy(gameObject);
}


    }
}
