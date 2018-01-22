using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neanderthal : MonoBehaviour {

    Animator anim;
    public Vector3 WayPoint;
    [HideInInspector]
    public WayPoints theWay;
    public Transform LastWayPoint;
    public bool FollowThePlayerActive;
    public Rigidbody m_Rigidbody;
    public float WalkAnimationSpeed = 0.5f;
    public float RunAnimationSpeed=1;
    [HideInInspector]
    public float NormalWalkAnimationSpeed;
    public bool WayPointIsPlayer;
    public bool UnderWalkPause;
    public bool FreezePosition;
    public bool LookPlayerAlways;
    int i;
    public float RotationSpeed = 1;
    public float Acceleration = 1;
    public float Deceleration = 1;
  //  public Renderer MainRenderer;
    float TimerFromCreation;
    Collider[] triggerAreas;
    float Acc;
    public Vector3 FinalLook;
    public SphereCollider ClavaTrigger;
    GameObject ClavaObject;
    GameObject ClavaTrailEffect;
    public int PointValue = 200;
    public ParticleSystem DeadEffect;
    public AudioClip Hu;
    public AudioClip Huhu;
    AudioSource source;
    public ParticleSystem SorpresaEffect;
    public GameObject WheelPrefab;
    public Transform WheelShotPoint;
    public float AddTorqueForce=-1f;
    public float AddForwardForce=4;
    public State state = State.WalkWithClava;
    public static bool EventsAdded;
    public float OkyMinDistanceAnimator=30;
    public enum State
    {
        Null,WalkWithClava, SpotWhells
    }
    public float GravityMultipler;
    public float AddGravity;

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

    void Awake() {
       
        m_Rigidbody = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        ClavaObject= ClavaTrigger.gameObject;
        ClavaTrailEffect = ClavaTrigger.transform.GetChild(0).gameObject;
        WheelShotPoint = transform.GetChild(1);
        NormalWalkAnimationSpeed = WalkAnimationSpeed;
        triggerAreas = GetComponentsInChildren<Collider>();
        
    }


void OnEnable()
    {
        if (!theWay) { theWay = GetComponentInChildren<WayPoints>(); }
        else
        {
            WayPoint = theWay.points[1].position;
        }
        

        TimerFromCreation = 0;
    }



    void Start() {

        anim = GetComponent<Animator>();

        if (!EventsAdded)
        {
            AddEvent(anim, 13, 0.2f, "ClavaTriggerActive", 0);
            AddEvent(anim, 13, 0.5f, "ClavaTriggerInActive", 0);
            AddEvent(anim, 15, 0.4f, "InstantiateWheel", 0);
            AddEvent(anim, 14, 0.5f, "DeleteObject", 0);
            EventsAdded = true;
        }
       
        anim.SetBool("Walk", true);
        WalkForward();
        ChangeState(state);
        FollowThePlayerActive = true;
        ClavaTrigger.enabled = false;
    }

    public void ClavaTriggerActive(){

        ClavaTrigger.enabled = true;
        ClavaObject.SetActive(true);
        source.PlayOneShot(Hu);
        SorpresaEffect.Emit(10);
        ClavaTrailEffect.SetActive(true);
    }
    public void ClavaTriggerInActive()
    {
        ClavaTrigger.enabled = false;
        ClavaTrailEffect.SetActive(false);

    }

    void WalkForward() {
        UnderWalkPause = false;
        ClavaTriggerInActive();
        anim.SetBool("Walk", true);
        ClavaTrailEffect.SetActive(false);
    }

    public void CheckWayPoints()
    {
        if (FreezePosition) return;

        if (UnderWalkPause) return;

        if (Vector3.Distance(transform.position, theWay.points[i].position) < 2f)
        {
            if (i < theWay.points.Length - 1)
            {
                i++;
            }
            else
            {
               // print("Reverse");
                i = 0;
                System.Array.Reverse(theWay.points);

                PauseWalk();
                return;
            }
        }

        if (!WayPointIsPlayer|| !FollowThePlayerActive)
        {
            WayPoint = Vector3.Lerp(WayPoint, new Vector3(theWay.points[i].position.x, transform.position.y, theWay.points[i].position.z), RotationSpeed * Time.deltaTime * GameManager.TimeMultipler);
            LastWayPoint = theWay.points[i];
        }
        else
        {
            if(FollowThePlayerActive)
            WayPoint = Vector3.Lerp(WayPoint, new Vector3(GameManager.m_Character.transform.position.x, transform.position.y, GameManager.m_Character.transform.position.z), RotationSpeed * Time.deltaTime * GameManager.TimeMultipler);
        }


         FinalLook = new Vector3(WayPoint.x, transform.position.y, WayPoint.z);

        
    }
    public void PauseWalk()
    {
        if (anim.GetBool("Walk"))
        {

            anim.SetBool("Walk", false);
         
            Invoke("WalkForward", 5);
            UnderWalkPause = true;

        }
    }
   public void StartAttack01() {
        if (!anim.GetBool("Attack01"))
        {
            anim.SetBool("Attack01", true);
            Acc = 0;
            LookPalyer();
            //Si gira istantaneamente verso il player (non per la Y)
            transform.LookAt(new Vector3 (GameManager.m_Character.transform.position.x, transform.position.y, GameManager.m_Character.transform.position.z));
        }
    }

    public void StopAllAttack()
    {
        if (anim.GetBool("Attack01")){
            StopAttack01();
            if (!source.isPlaying)
            {

                SorpresaEffect.Emit(5);
            } }
        anim.SetFloat("Speed", 0);
    }

    public void StopAttack01()
    {

        anim.SetBool("Attack01", false);
        WayPointIsPlayer = false;
        WalkAnimationSpeed = NormalWalkAnimationSpeed;
        ClavaTriggerInActive();

    }
    public void LookPalyer()
    {
        if (anim.GetBool("Dead") == true) return;

        if (WayPointIsPlayer|| !FollowThePlayerActive) return;

        WayPointIsPlayer = true;
        if (!source.isPlaying)
        {
            source.PlayOneShot(Huhu);
            SorpresaEffect.Emit(10);
        }
        WalkAnimationSpeed = RunAnimationSpeed;
    }



    void SmoothLookAt(Vector3 target)
    {
        if (anim.GetBool("Dead") == true) return;

        Vector3 relativePos = target - transform.position;
        relativePos.y = 0.0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(relativePos), (Time.deltaTime * GameManager.TimeMultipler * RotationSpeed)*10);
    }



    void WalkWithClava()
    {
      

        if (Time.timeSinceLevelLoad > 2)
        {
            CheckWayPoints();
            SmoothLookAt(FinalLook);
        }
        else
        {
            transform.LookAt(theWay.points[1]);
            PauseWalk();
        }


        if (anim.GetBool("Walk"))
        {
            Acc += Acceleration * Time.deltaTime;
        }
        else
        {
            Acc -= Deceleration * Time.deltaTime;

        }

        anim.SetFloat("Speed", Acc);
        Acc = Mathf.Clamp(Acc, 0, WalkAnimationSpeed);
    }

    public void SpotWhells() {

        anim.SetBool("SpotWheel", true);
       
    }


    //Richiamata dall'animazione
    public void InstantiateWheel()
    {

      GameObject LaunchObject=  GameObject.Instantiate(WheelPrefab, WheelShotPoint.position, WheelShotPoint.rotation);

        Ruota ruota = LaunchObject.GetComponent<Ruota>();
        DeadTrigger deadTrigger = LaunchObject.GetComponentInChildren<DeadTrigger>();

        if (ruota)
        {
            ruota.Torque += AddTorqueForce;
            ruota.ForwardForce += AddForwardForce;
        }

        if(deadTrigger)
            deadTrigger.FiredBy = this;
    }

    void Update() {



        if (TimerFromCreation < 2)
            TimerFromCreation += Time.deltaTime * GameManager.TimeMultipler;


        float dist = Vector3.Distance(GameManager.m_Character.transform.position, transform.position);
        // print(gameObject.name +" "+ dist);

        if(!GameManager.PlayerIsDead)
        if (dist < OkyMinDistanceAnimator)
        {
            anim.enabled = true;

                if (state != State.SpotWhells)
                {
                    m_Rigidbody.isKinematic = false;
                }
                else {
                    Acc = 0;
                    anim.SetFloat("Speed", 0);
                }



            if(!triggerAreas[1].gameObject.activeInHierarchy)
            foreach (Collider areas in triggerAreas)
            {
                if (areas)
                    if (!areas.transform.GetComponent<Rigidbody>())
                        areas.gameObject.SetActive(true);

            }
        }
        else
        {
                if (anim.enabled==true)
                {
                    m_Rigidbody.isKinematic = true;
                    anim.enabled = false;
                    if (triggerAreas[1].gameObject.activeInHierarchy)
                        foreach (Collider areas in triggerAreas)
                        {
                            if (areas)
                                if (!areas.transform.GetComponent<Rigidbody>())
                                    areas.gameObject.SetActive(false);

                        }
                }
            return;
        }






        if (state == State.WalkWithClava && theWay)
        {
            WalkWithClava();
        }
        else if (state == State.SpotWhells)
        {
            
            SpotWhells();
        }

        if(GravityMultipler>0)
        Gravity();

    }


    


    public void Dead()
    {
        
        if (anim.GetBool("Dead") == true) return;

        anim.SetBool("Dead", true);
        anim.Play("Dead");
        GetComponent<CapsuleCollider>().enabled = false;
        m_Rigidbody.isKinematic = true;
        if (DeadEffect)
        GameObject.Instantiate(DeadEffect.gameObject, transform.position, transform.rotation);

  
        W_PlayerPoints._istance.AddPoints(PointValue + Random.Range(0, 50));

        if (theWay) Destroy(theWay.gameObject, 1);

        Destroy(gameObject, 1f);
    }

    public void DeleteObject() {
        Destroy(gameObject, 1);
    }

    void Gravity()
    {
        if (m_Rigidbody.velocity.y > 0.1f)
        {
            AddGravity += GravityMultipler;
            m_Rigidbody.AddForce((Vector3.down * AddGravity), ForceMode.Acceleration);
        }
        else { AddGravity = 0; }
    }



    public void ChangeState(State NewState) {

        if(NewState!= State.Null) //Inviato Null solo per aggiornare
        state = NewState;


        if (state == State.WalkWithClava && theWay) //Cammina e clava
        {
            ClavaObject.SetActive(true);
            if (theWay) theWay.gameObject.SetActive(true);
            m_Rigidbody.isKinematic = false;
        }
        else if (state == State.SpotWhells) //Tira le ruote
        {
            ClavaObject.SetActive(false);
           if(theWay) theWay.gameObject.SetActive(false);
            m_Rigidbody.isKinematic = true;
        }
    }
}
