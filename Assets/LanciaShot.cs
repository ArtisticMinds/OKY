using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanciaShot : MonoBehaviour {

    Rigidbody _rigidbody;
    public float ForwardSpeed=10;
    public float UpSpeed=10;
    public float DownRation = 0.01f;
    bool Active;
    [HideInInspector]
    public float SpeedByDistance=1;
    public Transform massCenter;
    Material[] DissolveMat;
    public float GravityMultipler;
  
    public float AddGravity;
    public float diss = 1;
    public ParticleSystem PuffEffect;
    Animator anima;
    GameObject deadTrigger;



    void Awake () {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = massCenter.localPosition;
        Active = true;
        anima = GetComponent<Animator>();
        DissolveMat = GetComponentInChildren<Renderer>().materials;

        deadTrigger = GetComponentInChildren<DeadTrigger>().gameObject;
    }

    private void Start()
    {
      
        Move();
    }

    void Move () {


     
        _rigidbody.AddForce((((transform.forward * ForwardSpeed)+(Vector3.up* UpSpeed) * SpeedByDistance) + (Vector3.down * AddGravity)), ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Terrain"))
        {
            ForwardSpeed = UpSpeed = AddGravity = 0; 
            if (Active)
            {
                GetComponent<CapsuleCollider>().enabled = false;
                _rigidbody.isKinematic = true;
                Active = false;
                
                anima.SetBool("Hit", true);
                PuffEmit();
            }
        }
    }

    void Dissolve() {

        diss -= 0.005f * Time.deltaTime;
        foreach (Material mat in DissolveMat)
            mat.color *= diss;

        if (diss < 0.999) deadTrigger.SetActive(false);
        if (diss <= 0.985f) Destroy(gameObject);
    }

    public void PuffEmit()
    {

        PuffEffect.Emit(5);

    }

    void FixedUpdate()
    {
        if (Active)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + DownRation, transform.localEulerAngles.y, transform.localEulerAngles.z);
            AddGravity += GravityMultipler;
            _rigidbody.AddForce((Vector3.down * AddGravity), ForceMode.Acceleration);

        }
        else
        {
            Dissolve();
        }
    }
}
