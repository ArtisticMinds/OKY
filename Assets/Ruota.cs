using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruota : MonoBehaviour {

    Rigidbody rigid;
    GameObject deadTrigger;
    public float GravityMultipler;
    float AddGravity;
    float Speed;
    public float Torque = 10;
    public float ForwardForce = 0;
    public bool AddTorque;
    public float TorqueTime = 5;
    float ran;
    public GameObject DestroyEffect;
    TrailRenderer effect;
    public bool isSnow;
    public float maxScale = 0.75f;

    void Start () {
        rigid = GetComponent<Rigidbody>();
  
        deadTrigger = GetComponentInChildren<DeadTrigger>().gameObject;
        effect = GetComponentInChildren<TrailRenderer>();
        if (ForwardForce > 0) AddForce();
    }

    private void OnEnable()
    {
        ran = Random.Range(0.1f, 1f);
        Invoke("RemoveTorque", TorqueTime+ ran);
        DestroyEffect.SetActive(false);
    }


    void AddSpeed() {
        rigid.AddRelativeTorque(Torque+ ran, 0, 0,ForceMode.VelocityChange);
        
    }

    void RemoveTorque() {
        AddTorque = false;
    }

    void AddForce() {
        rigid.velocity += transform.forward * ForwardForce;
    }

    void Rescale() {

        float scaleMultipler= 1.002f;

        if(Speed>1)
        if(transform.localScale.x < maxScale)
        transform.localScale *= scaleMultipler;
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
    void Gravity()
    {
        AddGravity += GravityMultipler;
        rigid.AddForce((Vector3.down * AddGravity), ForceMode.Acceleration);
    }

    void FixedUpdate () {
        Speed = rigid.velocity.magnitude;
        if (Speed > 2f)
        {
            deadTrigger.SetActive(true);
            if (effect) effect.enabled = true;
            if (isSnow) Rescale();
        }
        else
        {
            deadTrigger.SetActive(false);
           if(effect) effect.enabled = false;
        }

        if(AddTorque)
        AddSpeed();

        if(transform.parent==null)
        if (Speed <= 0.1f)
            DestroyObject();

        if (GravityMultipler != 0) Gravity();
    }
}
