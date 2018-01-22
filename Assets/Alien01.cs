using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Alien01 : MonoBehaviour {

    Animator anim;
    public Vector3 WayPoint;
    public ParticleSystem LampShotEffect;
    public ParticleSystem ProjectileShotEffect;
    public ParticleSystem DeadEffect;
    public ParticleSystem SlugShotEffect;
    public Transform SlugShotPoint;
    public GameObject ActivateAtSLug;
    public bool WayPointIsPlayer;
    bool UnderWalkPause;
    WayPoints theWay;
    public float WalkAnimationSpeed = 1.5f;
    public float ShotAnimationSpeed = 0.5f;
    public float IdleAnimationSpeed = 0.5f;
    public bool ShotEnabled=true;
    public bool ShotOnAir;
    public int PointValue = 100;
    DropObjects dropObject;
    public bool FreezePosition;
    public bool LookPlayerAlways;
    GameObject SlugShot;
    public Rigidbody m_Rigidbody;
    int i;
    public float RotationSpeed = 1;
    public Renderer MainRenderer;
    float TimerFromCreation;
    public bool NullParentAtStart = true;
    public ParticleSystem HappyParticle;
    public static bool EventsAdded;
    public float OkyMinDistanceAnimator = 15;
    Collider [] triggerAreas;

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

        if(NullParentAtStart)
        transform.SetParent(null);

        MainRenderer = GetComponentInChildren<Renderer>(true);
        m_Rigidbody = GetComponent<Rigidbody>();

        triggerAreas = GetComponentsInChildren<Collider>();
       


    }

    void OnEnable()
    {

       if(!theWay) theWay = GetComponentInChildren<WayPoints>();
       if(ActivateAtSLug)ActivateAtSLug.SetActive(false);
        TimerFromCreation = 0;

        if(theWay)
        WayPoint = theWay.points[1].position;
    }

    void Start () {
        WayPointIsPlayer = false;
        anim = GetComponent<Animator>();

        if (!EventsAdded)
        {
            
            AddEvent(anim, 1, 0.25f, "EmitProjectile", 0);
            AddEvent(anim, 3, 0.3f, "EmitSlug", 0);
            EventsAdded = true;
        }

        WalkForward();
        //InvokeRepeating("StopLookPalyer",2, 3);
        dropObject = GetComponent<DropObjects>();
        if(HappyParticle)HappyParticle.gameObject.SetActive(false);

        if (!ShotEnabled)
            LampShotEffect.transform.parent.gameObject.SetActive(false);
    }




    //Chiamato dall'animazione
    public void EmitProjectile()
    {
        if (TimerFromCreation < 2) return;

                LampShotEffect.Emit(1);
                GameObject Shot = GameObject.Instantiate(ProjectileShotEffect.gameObject, LampShotEffect.transform.position, transform.rotation);

        DeadTrigger deadTrigger = Shot.GetComponentInChildren<DeadTrigger>();
        if (deadTrigger)
            deadTrigger.FiredByA = this;

    }

    //Chiamato dall'animazione
    public void EmitSlug()
    {
        if (TimerFromCreation < 2) return;
        SlugShotEffect.Emit(15);
        if(!SlugShot) SlugShot = GameObject.Instantiate(SlugShotEffect.gameObject, SlugShotPoint.position, SlugShotPoint.rotation);
        if (ActivateAtSLug) ActivateAtSLug.SetActive(true);

    }


    public void StartSlug()
    {
        if (TimerFromCreation < 2) return;

        if (!anim) return;
        anim.SetFloat("Speed", ShotAnimationSpeed*10);
        anim.SetBool("Shot", false);
        anim.SetBool("Slug", true);
        LookPalyer();

    }

    public void StartShot() {
        if (TimerFromCreation < 2) return;

        if (!anim) return;
        anim.SetFloat("Speed", ShotAnimationSpeed);
        anim.SetBool("Shot", true);
        LookPalyer();

    }

    public void StopAllAttack()
    {
        StopSlug();
        StopShot();
    }



    public void IsHappy()
    {
        StopAllAttack();
        LookPalyer();
        if(HappyParticle) HappyParticle.gameObject.SetActive(true);
        anim.SetBool("Happy", true);
        Invoke("RemoveHappy", 10);
    }
    public void RemoveHappy()
    {
        anim.SetBool("Happy", false);
        if (HappyParticle) HappyParticle.gameObject.SetActive(false);
        StartCoroutine(StopLookPalyer());
    }

    public void Dead(bool Resaize)
    {
        GameObject.Instantiate(DeadEffect.gameObject, transform.position, transform.rotation);
        StopSlug();
        StopShot();
        if (Resaize)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
            GetComponent<CapsuleCollider>().radius /= 2;
        }

        W_PlayerPoints._istance.AddPoints(PointValue + Random.Range(0, 50));

        if (dropObject)
        {
            dropObject.DropNow();
        }

        if(theWay)Destroy(theWay.gameObject,1);

        if (Resaize)
        Destroy(gameObject, 0.2f);
        else
        Destroy(gameObject);

       

    }

    public void StopShot()
    {
        if (anim)
        {
            WayPointIsPlayer = false;
            anim.SetFloat("Speed", IdleAnimationSpeed);
            anim.SetBool("Shot", false);
        }
    }

    public void StopSlug()
    {
        if (anim)
        {
            WayPointIsPlayer = false;
            anim.SetFloat("Speed", IdleAnimationSpeed);
            anim.SetBool("Slug", false);
            if (ActivateAtSLug) ActivateAtSLug.SetActive(false);
        }
    }

    public void WalkForward()
    {
        if (FreezePosition) return;
        if (HappyParticle) HappyParticle.gameObject.SetActive(false);
        anim.SetFloat("Speed", WalkAnimationSpeed);
        anim.SetBool("Walk", true);
        UnderWalkPause = false;
        anim.SetBool("Happy", false);
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
                
                i = 0;
                System.Array.Reverse(theWay.points);
                PauseWalk();
                return;
            }
        }
        
        if(!WayPointIsPlayer)
        WayPoint = Vector3.Lerp(WayPoint, new Vector3(theWay.points[i].position.x, transform.position.y, theWay.points[i].position.z), RotationSpeed * Time.deltaTime * GameManager.TimeMultipler);
       else
         WayPoint = Vector3.Lerp(WayPoint, new Vector3(GameManager.m_Character.transform.position.x, transform.position.y, GameManager.m_Character.transform.position.z), RotationSpeed * Time.deltaTime * GameManager.TimeMultipler);

        if (Time.timeSinceLevelLoad <= 2)
            WayPoint = theWay.points[1].position;

        Vector3 FinalLook = new Vector3(WayPoint.x, transform.position.y, WayPoint.z);
        transform.LookAt(FinalLook);
       

    }

    public void PauseWalk()
    {
        if (anim.GetBool("Walk"))
        {
            anim.SetBool("Walk", false);
            anim.SetFloat("Speed", 0f);
            Invoke("WalkForward", 2);
            UnderWalkPause = true;
        }
    }

    public void LookPalyer()
    {
        WayPointIsPlayer = true;
    }
    public void _StopLookPalyer()
    { StartCoroutine(StopLookPalyer());
    }
         IEnumerator StopLookPalyer()
    {
        yield return new WaitForSeconds(2);
        WayPointIsPlayer = false;
       

    }


    
    void Update () {

        if (!GameManager.m_Character) return;
        if(TimerFromCreation<4)
        TimerFromCreation += Time.deltaTime * GameManager.TimeMultipler;

        float dist = Vector3.Distance(GameManager.m_Character.transform.position, transform.position);



        if (dist < OkyMinDistanceAnimator) {
            anim.enabled = true;
            m_Rigidbody.isKinematic = false;
            foreach (Collider areas in triggerAreas)
            {
                if (areas)
                    if (!areas.transform.GetComponent<Rigidbody>())
                        areas.gameObject.SetActive(true);

            }
        }
        else
        {
            m_Rigidbody.isKinematic = true;
            anim.enabled = false;
            foreach (Collider areas in triggerAreas)
            {
                if (areas)
                    if (!areas.transform.GetComponent<Rigidbody>())
                        areas.gameObject.SetActive(false);

            }
            return;
        }

        if (LookPlayerAlways) {
            transform.LookAt(GameManager.m_Character.transform);
            LookPalyer();

        }

        if (FreezePosition) return;



        if (Time.timeSinceLevelLoad > 2)
        {
            CheckWayPoints();
        }
        else
        {
            transform.LookAt(theWay.points[1]);
            PauseWalk();
        }
    }
}
