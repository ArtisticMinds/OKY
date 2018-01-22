using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeandertalBossApiedi : MonoBehaviour {

    public float GravityMultipler;
    public float AddGravity;
    Rigidbody _rigidbody;
    Animator anima;
    public ParticleSystem ShotEffect;
    public GameObject LanciaPrefab;
    public Transform ShotPoint;
    float SpeedByDistance;
    public Transform LanciaStaticaPerCarica;
    bool NoShot;
    public GameObject ShotArea;
    public BoxCollider ShieldCollider;
    float time;
    public static bool EventsAdded;


    void AddEvent(Animator animator, int Clip, float time, string functionName, float floatParameter)
    {
        AnimationClip clip1 = animator.runtimeAnimatorController.animationClips[Clip];

        foreach (AnimationEvent ev in clip1.events)
        {
            if (ev.time == time) { return; }

        }


        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.functionName = functionName;
        animationEvent.floatParameter = floatParameter;
        animationEvent.time = time;


        clip1.AddEvent(animationEvent);


    }







    void Start () {
        _rigidbody = GetComponent<Rigidbody>();
        anima = GetComponent<Animator>();

        if (!EventsAdded)
        {
            AddEvent(GetComponent<Animator>(), 14, 0.95f, "NeanderthalShot", 0);//Shot
            AddEvent(GetComponent<Animator>(), 14, 0.7f, "DeactivateScudo", 0); //Shot
            AddEvent(GetComponent<Animator>(), 15, 0.1f, "ActivateScudo", 0); //Parata
            AddEvent(GetComponent<Animator>(), 15, 1.45f, "ActivateScudo", 0); //Parata
            AddEvent(GetComponent<Animator>(), 15, 0.5f, "ActivateScudo", 0); //Parata
            AddEvent(GetComponent<Animator>(), 16, 0.5f, "ActivateScudo", 0); //Carica
            AddEvent(GetComponent<Animator>(), 16, 1.2f, "DeactivateScudo", 0); //Carica
            AddEvent(GetComponent<Animator>(), 16, 1.5f, "StopCarica", 0); //Carica
            AddEvent(GetComponent<Animator>(), 0, 0.1f, "DeactivateScudo", 0); //Idle
            EventsAdded = true;
        }
    }




    void Gravity()
    {
        if (_rigidbody.velocity.y > 0.01f)
        {
            AddGravity += GravityMultipler;
            _rigidbody.AddForce((Vector3.down * AddGravity), ForceMode.Acceleration);
        }
        else { AddGravity = 0; }
    }



    public void ActivateScudo()
    {
        ShieldCollider.enabled = true;
        transform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z));


    }
    public void DeactivateScudo()
    {
        ShieldCollider.enabled = false;
        anima.SetBool("Parata", false);
    }

    public void ShotLancia() {
        anima.SetBool("ShotLancia", true);
        anima.SetBool("Parata", false);
    }

    public void StopSHotLancia() {
        anima.SetBool("ShotLancia", false);
    }

    public void Carica()
    {
        anima.SetBool("ShotLancia", false);
        anima.SetBool("Carica", true);
        ActivateScudo();
       
    }


    public void StopCarica()
    {
     
        anima.SetBool("Carica", false);
       
    }

    void Update () {





    }



    //Chiamato dall'animazione
    public void NeanderthalShot()
    {

        ShotEffect.Emit(5);

        SpeedByDistance = Vector3.Distance(ShotPoint.position, GameManager.m_Character.transform.position) * 0.85f;

        GameObject lancia = GameObject.Instantiate(LanciaPrefab, ShotPoint.position, ShotPoint.rotation);
        lancia.GetComponent<LanciaShot>().SpeedByDistance = SpeedByDistance + Random.Range(-10f, 15);


    }







}
