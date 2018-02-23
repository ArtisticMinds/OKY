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


    public bool DestroyOnHit = true;
    bool moveStep01, moveStep02;
    float addY;
    Vector3 OrPOsition;
    Transform OrParent;

    void Awake () {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
       if(DestroyOnHit) DestroyEffect.SetActive(false);
        OrPOsition = transform.position;
        OrParent = transform.parent;
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

    public void MoveStep(int ran) {

        if (Random.Range(0, ran) >= 1)
            return;

        if (!moveStep01)
        {
            moveStep01 = true;
            return;
        }


        if (moveStep01 && !moveStep02)
        {
            moveStep02 = true;
            return;
        }


        if (moveStep01 && moveStep02)
        {
            Detack();
            return;
        }

    }

    void Update()
    {
        if (!DestroyOnHit)
            if (transform.position.y < -10) DestroyObject();

        if (Active)
        {
            if (moveStep01)
            {
                if (addY < 10)
                {
                    addY += 3f * Time.deltaTime;
                    transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.down * addY, Time.deltaTime);
                }
            }

            if (moveStep02)
            {
                if (addY < 5)
                {
                    addY += 3f * Time.deltaTime;
                    transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.down * addY, Time.deltaTime);
                }
            }
        }

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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Active) return;
        if (TimeFromCreation < 1) return;

        DestroyObject();
    }

    private void DestroyObject()
    {


        if (DestroyOnHit)
        {
            if (DestroyEffect)
            {
                DestroyEffect.gameObject.SetActive(true);
                DestroyEffect.transform.SetParent(null);
            }
            Destroy(gameObject);
        }
        else
        {
            GameObject dest = GameObject.Instantiate(DestroyEffect.gameObject, null);
            dest.transform.position = transform.position;

            transform.SetParent(OrParent);
            transform.position = OrPOsition;
            Active = false;
            _rigidbody.isKinematic = true;
            grav = 0;
            moveStep01 = moveStep02 = false;
            TimeFromCreation = 0;
        }

    }


}
