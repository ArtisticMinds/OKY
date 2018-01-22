using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addGravity : MonoBehaviour {

    Rigidbody _rigidbody;
    public float AddGravity = 100;
    public float grav;
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();

    }


    void AddGr()
    {
        grav += AddGravity;
        _rigidbody.AddForce(Vector3.down * grav, ForceMode.Force);

    }
    void Update () {
        if (_rigidbody.velocity.y < -0.1f)
        {
            AddGr();
        }
        else
        {
            grav = 0;
        }

    }
}
