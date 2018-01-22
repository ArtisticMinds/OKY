using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stalttite : MonoBehaviour {


    Rigidbody _rigidbody;
    public float AddGravity = 100;
    public float grav;
    bool Active;
    public GameObject DestroyEffect;
    float Speed;
    float TimeFromCreation;
    public AudioClip EmitOnAction;


    void Awake () {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        DestroyEffect.SetActive(false);
    }

   public void Detack() {
        transform.SetParent(null);
        _rigidbody.isKinematic = false;
        Active = true;
        TimeFromCreation = 0;
        if(EmitOnAction)
        GameManager.MasterAudioSource.PlayOneShot(EmitOnAction);
    }

    void AddGr()
    {
        grav += AddGravity;
        _rigidbody.AddForce(Vector3.down * grav, ForceMode.Force);

    }


    void Update()
    {
        if (!Active) return;

        TimeFromCreation += Time.deltaTime * GameManager.TimeMultipler;

        if (TimeFromCreation < 2) return;

        Speed = _rigidbody.velocity.magnitude;

        if (_rigidbody.velocity.y < -0.1f)
        {
            AddGr();
        }
        else
        {
            grav = 0;
        }


        //if (Speed <= 0.1f)
        //    DestroyObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Active) return;
        if (TimeFromCreation < 1) return;

        DestroyObject();
    }

    private void DestroyObject()
    {

        if (DestroyEffect)
        {
            DestroyEffect.gameObject.SetActive(true);
            DestroyEffect.transform.SetParent(null);
        }
        Destroy(gameObject);

    }
}
