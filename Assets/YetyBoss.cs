using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetyBoss : MonoBehaviour {

    public float Energy = 10;
    float StartEnergy;
    bool shakecamera;
    public static bool EventsAdded;
    public ParticleSystem Puff;
    public ParticleSystem Puff2;
    public GameObject[] TrailLines;
    public bool LookPlayer;
    float YpositioN;
    public GameObject Shot;
    Animator anima;
    public float PlayerDistance;
    public float IndietreggiaDistance;
    public Transform IndietreggiaPoint;
    stalttite[] stalactiti;
    public GameObject DeadEffect;

    void Start () {

        stalactiti = FindObjectsOfType<stalttite>();
        InvokeRepeating("Rumble", 10, 5);
        InvokeRepeating("Indietreggia", 9, 8);
        InvokeRepeating("RecargeEnergy", 5, 5);
        InvokeRepeating("Walk", 10, 15);
        Shot.SetActive(false);
        YpositioN = transform.position.y;
        StartEnergy = Energy;
        anima = GetComponent<Animator>();
        DeadEffect.SetActive(false);
        if (!EventsAdded)
        {
            AddEvent(anima, 2, 1f, "ShakeCamera", 20);
            AddEvent(anima, 4, 0.3f, "ShakeCamera", 100);
            AddEvent(anima, 5, 0.2f, "TrailActivation", 0);
            AddEvent(anima, 5, 0.9f, "TrailHide", 0);
            AddEvent(anima, 2, 1.1f, "ShotNow", 0);
            EventsAdded = true;
        }
        TrailHide();
    }

     void Attacco01()
    {
        if (Shot.activeInHierarchy)
        {
            anima.SetBool("Attacco01", false);
            return;
        }

        if (Random.Range(0, 4) >= 1)
            return;


        anima.SetBool("Walk", false);
        anima.SetBool("Attacco01", true);
        anima.SetBool("Attacco02", false);
        anima.SetBool("Indietreggia", false);
        anima.SetBool("Rumble", false);

    }

    void Attacco02()
    {
        anima.SetBool("Walk", false);
        anima.SetBool("Attacco01", false);
        anima.SetBool("Attacco02", true);
        anima.SetBool("Indietreggia", false);
        anima.SetBool("Rumble", false);
    }



    void Walk()
    {

        if (IndietreggiaDistance < 20) return;

        anima.SetBool("Attacco01", false);
        anima.SetBool("Attacco02", false);
        anima.SetBool("Walk", true);
        anima.SetBool("Indietreggia", false);
        anima.SetBool("Rumble", false);
    }

    void Indietreggia()
    {
        if (IndietreggiaDistance > 60) return;

        anima.SetBool("Attacco01", false);
        anima.SetBool("Attacco02", false);
        anima.SetBool("Walk", false);
        anima.SetBool("Indietreggia", true);
        anima.SetBool("Rumble", false);
    }

    void Rumble()
    {


        if (!StalattitiActivation.InStay) return;

        anima.SetBool("Attacco01", false);
        anima.SetBool("Attacco02", false);
        anima.SetBool("Walk", false);
        anima.SetBool("Indietreggia", false);
        anima.SetBool("Rumble", true);
    }

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


    void ShotNow() {
        if (Shot.activeInHierarchy) return;

        TrailHide();
        Shot.transform.position= transform.position + transform.forward * 2f; ;
        Shot.SetActive(true);
        Shot.GetComponent<YetiShot>().GoNow();



    }


    void ShakeCamera(float PuffPartices) {

        if (PuffPartices > 30)
        {
            GameManager.cameraShake.shakecamera(1f, 10, 1f);
            MoveStalattiti(3);
        }
        else
        {
            GameManager.cameraShake.shakecamera(0.5f, 5, 1f);
        }

        Puff.Emit((int)PuffPartices);
        Puff2.Emit(((int)PuffPartices/2));

           
    }


    void MoveStalattiti(int ran)
    {


        foreach (stalttite stal in stalactiti)
            if(stal)stal.MoveStep(ran);
    }

    void TrailActivation() {
        TrailLines[0].SetActive(true);
        TrailLines[1].SetActive(true);
    }

    void TrailHide()
    {
        TrailLines[0].SetActive(false);
        TrailLines[1].SetActive(false);
    }




    public void RemoveEnergy(float value)
    {
        if (Energy > value)
        {
            Energy -= value;
           // source.Play();
        }
        else
        {
            Energy -= value;
            Dead();
        }

        BossBarUpdate(Energy / StartEnergy);
    }
    void BossBarUpdate(float value)
    {
        GameUI.Instance.BossEnergyBarImage.fillAmount = value;

        print("BossEnergy: " + value + " -  Energy" + Energy + " StartEnergy" + StartEnergy);

        GameManager.gameUI.BossEnergyAnimator.SetBool("Get", true);
        Invoke("RestetGet", 1f);


        if (value <= 0.2f && value > 0)
        {
               anima.SetBool("Attacco01", false);
            anima.SetBool("Attacco02", false);
            anima.SetBool("Walk", false);
            anima.SetBool("Indietreggia", true);
            anima.SetBool("Rumble", false);
        }

            if (value <= 0.0f)
        {
            anima.SetBool("Dead", true);
            anima.SetBool("Attacco01", false);
            anima.SetBool("Attacco02", false);
            anima.SetBool("Walk", false);
            anima.SetBool("Indietreggia", false);
            anima.SetBool("Rumble", false);

            StartCoroutine(Dead());
        }
    }

    void RestetGet()
    {
        GameManager.gameUI.BossEnergyAnimator.SetBool("Get", false);
    }
    IEnumerator Dead()
    {
        W_PlayerPoints.StarsComplete = true;

        //foreach (GameObject gobj in DestroyAtDead)
        //    gobj.SetActive(false);

        //foreach (GameObject gobj in ActivateAtDead)
        //    gobj.SetActive(true);

        GameUI.Instance.BossEnergyBarImage.transform.parent.gameObject.SetActive(false);
        DeadEffect.transform.SetParent(null);
        DeadEffect.SetActive(true);
        yield return new WaitForSeconds(2);
        GetComponent<Collider>().enabled = false;

        foreach (Collider col in GetComponentsInChildren<Collider>())
            col.enabled = false;

        yield return new WaitForSeconds(5);
        Destroy(gameObject);

        GameManager.ThisLevelManager.endLevel.OpenPortalEffect();

    }

    void RecargeEnergy()
    {
        if (Energy < StartEnergy)
            Energy += 0.1f;

        GameUI.Instance.BossEnergyBarImage.fillAmount = Energy / StartEnergy;
    }



    void Update () {
        PlayerDistance = Vector3.Distance(GameManager.m_Character.transform.position, transform.position);
        IndietreggiaDistance = Vector3.Distance(IndietreggiaPoint.position, transform.position);

        Vector3 look = new Vector3(GameManager.m_Character.transform.position.x, YpositioN, GameManager.m_Character.transform.position.z);
        if (LookPlayer)
            transform.LookAt(look);


        if (IndietreggiaDistance < 25) Indietreggia();
        if ( IndietreggiaDistance > 70) Walk();

        if (PlayerDistance < 30 && PlayerDistance >= 10)
        {
            Attacco01();
        }
        else { anima.SetBool("Attacco01", false); }


        if (PlayerDistance < 10)
        {
             Attacco02();
        }
        else { anima.SetBool("Attacco02", false); }

        if (PlayerDistance > 15 && (IndietreggiaDistance > 60)) Walk();
    }
}
