using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01 : MonoBehaviour {

    public Animator[] anima;
    public int tentacle;
    public bool InAttacking;
    [Range (3,10)]
    public int AttackDelay = 8;
    public float Energy = 10;
    float StartEnergy;
    public GameObject[] DestroyAtDead;
    public GameObject[] ActivateAtDead;
    public GameObject AttackStartEffect;
    public GameObject AttackColpoEffect;
    public Transform[] LastBone;
    AudioSource source;
    int effNum;
    public static bool EventsAdded;

    void Awake () {
        StartEnergy = Energy;
        InvokeRepeating("ChangeTentacle", 3, AttackDelay);
        InvokeRepeating("RecargeEnergy", 5, 5);


        foreach (GameObject gobj in ActivateAtDead)
            gobj.SetActive(false);
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Animator anima = GetComponent<Animator>();
        if (!EventsAdded)
        {
            AddEvent(anima, 2, 0.95f, "StopAttack01", 0);
            AddEvent(anima, 2, 0.2f, "EmitStartAttackEffect", 0);
            AddEvent(anima, 2, 0.8f, "EmitColpoAttackEffect", 0);
            EventsAdded = true;
        }
    }


    void AddEvent(Animator animator, int Clip, float time, string functionName, float floatParameter)
    {
        AnimationClip clip1 = anima[0].runtimeAnimatorController.animationClips[Clip];
        AnimationClip clip2 = anima[1].runtimeAnimatorController.animationClips[Clip];
        AnimationClip clip3 = anima[2].runtimeAnimatorController.animationClips[Clip];

        foreach (AnimationEvent ev in clip1.events)
        {
            if (ev.time == time) { return; }

        }
        foreach (AnimationEvent ev in clip2.events)
        {
            if (ev.time == time) { return; }

        }
        foreach (AnimationEvent ev in clip3.events)
        {
            if (ev.time == time) { return; }

        }


        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.functionName = functionName;
        animationEvent.floatParameter = floatParameter;
        animationEvent.time = time;

        clip1.AddEvent(animationEvent);
        clip2.AddEvent(animationEvent);
        clip3.AddEvent(animationEvent);

    }



    void OnTriggerEnter(Collider col)
    {

        if (!col.tag.Equals("Player") || GameManager.PlayerIsDead || InAttacking|| tentacle > 2)
        {

            return;
        }


            if (col.tag.Equals("Player")&& !InAttacking)
            {
            Attack01(tentacle);
            }
        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag.Equals("Player"))
        {
            StopAttack01();
        }
    }

    public void EmitColpoAttackEffect()
    {
        Instantiate(AttackColpoEffect, LastBone[effNum].position, Quaternion.identity);
    }
    public void EmitStartAttackEffect()
    {
        Instantiate(AttackStartEffect, LastBone[effNum].position, Quaternion.identity);
    }

   public void Attack01(int tentacle)
    {
        if (tentacle > anima.Length-1) return;

        if (anima[tentacle].GetBool("Dead")) {
            tentacle = 2;
            AttackDelay = 4;
             }
        if (anima[tentacle].GetBool("Dead"))
        {
            tentacle = 1;
            AttackDelay = 2;
            CancelInvoke("ChangeTentacle");
        }
        if (anima[tentacle].GetBool("Dead"))
        {
            return;
        }

        InAttacking = true;
        anima[tentacle].SetBool("Attack", true);
        
        effNum = tentacle;
    }

    public void StopAttack01() {
            InAttacking = false;
            anima[0].SetBool("Attack", false);
            anima[1].SetBool("Attack", false);
            anima[2].SetBool("Attack", false);
    }

    public void ChangeTentacle()
    {

        if (anima[2].GetBool("Dead")&& anima[0].GetBool("Dead"))
        {
            tentacle = 1;
            AttackDelay = 2;
            CancelInvoke("ChangeTentacle");
            return;
        }
        tentacle = Random.Range(0, AttackDelay);
        
    }

    public void RemoveEnergy(float value) {
        if (Energy > value)
        {
            Energy -= value;
            source.Play();
        }
        else {
            Energy -= value;
            Dead();
        }

        BossBarUpdate(Energy / StartEnergy);
    }
    void BossBarUpdate(float value) {
        GameUI.Instance.BossEnergyBarImage.fillAmount=value;

        print("BossEnergy: "+value +" -  Energy"+Energy + " StartEnergy" + StartEnergy);

        GameManager.gameUI.BossEnergyAnimator.SetBool("Get", true);
        Invoke("RestetGet", 1f);
        if (value <= 0.75f)
        {
            anima[0].SetBool("Dead", true);
        }

        if (value <= 0.35f)
        {
            anima[2].SetBool("Dead", true);
           
        }
        if (value <= 0.05f)
        {
            anima[1].SetBool("Dead", true);
           StartCoroutine(Dead());
        }
    }
    void RestetGet()
    {
        GameManager.gameUI.BossEnergyAnimator.SetBool("Get", false);
    }

    void RecargeEnergy()
    {
        if (Energy< StartEnergy)
        Energy+=0.1f;

        GameUI.Instance.BossEnergyBarImage.fillAmount = Energy / StartEnergy;
    }

    IEnumerator Dead() {
        W_PlayerPoints.StarsComplete = true;

        foreach (GameObject gobj in DestroyAtDead)
           if(gobj) gobj.SetActive(false);

        foreach (GameObject gobj in ActivateAtDead)
            gobj.SetActive(true); 

        GameUI.Instance.BossEnergyBarImage.transform.parent.gameObject.SetActive(false);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        
        GameManager.ThisLevelManager.endLevel.OpenPortalEffect();

    }

}
