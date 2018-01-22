using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02 : MonoBehaviour {

    public Animator animaMammut;
    public Animator animaNeanderthal;
    public GameObject NeandethalApiedi;
    public Animator animaApiedi;
    public float Energy = 10;
    float StartEnergy;
    AudioSource source;
    public GameObject[] DestroyAtDead;
    public GameObject[] ActivateAtDead;
    public float MyTime;
    public float PlayerDistance;
    public bool indietreggia;
    public bool neandertalindietreggia;
    float diss = 1;
    Material[] DissolveMat;
    bool mammuthIsDead;
    public ParticleSystem MammuthDeadEffect;
    public static bool EventsAdded;


    void Awake()
    {
        NeandethalApiedi.SetActive(false);
        animaApiedi = NeandethalApiedi.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        StartEnergy = Energy;
        InvokeRepeating("RecargeEnergy", 5, 5);
        DissolveMat = animaMammut.GetComponentInChildren<Renderer>().materials;

    }



    private void Start()
    {
        if (!EventsAdded) { 
        AddEvent(animaNeanderthal, 1, 0.35f, "NeanderthalShot", 0);
        AddEvent(animaMammut, 0, 0.1f, "CornaDeadTriggerDeactivate", 0);
        AddEvent(animaMammut, 3, 0.1f, "CornaDeadTriggerDeactivate", 0);
        AddEvent(animaMammut, 2, 0.1f, "PrecaricaEmit", 0);
        AddEvent(animaMammut, 2, 0.9f, "CaricaEmit", 0);
        AddEvent(animaMammut, 1, 0.5f, "IncorntaEmit", 0);
        EventsAdded = true;
    }
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





    public void RemoveEnergy(float value)
    {
        if (Energy > value)
        {
            Energy -= value;
            source.Play();
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

        if(animaMammut)
        if (value <= 0.4f)
        {  
            animaMammut.SetBool("Dead", true);
            animaMammut.GetComponent<CapsuleCollider>().enabled = false;
            animaMammut.GetComponent<Rigidbody>().isKinematic = true;
            animaMammut.GetComponent<Collider>().enabled = false;

                foreach (Collider col in animaMammut.GetComponentsInChildren<Collider>())
                    col.enabled = false;
                StartCoroutine(MammuthDead());
        }

        if (value <= 0.0f)
        {
            animaApiedi.SetBool("Dead", true);
            animaApiedi.SetBool("Parata", false);
            animaApiedi.SetBool("carica", false);


            StartCoroutine(Dead());
        }
    }


    void RestetGet()
    {
        GameManager.gameUI.BossEnergyAnimator.SetBool("Get", false);
    }


    void DissolveMammut()
    {

        if (animaMammut)
        {

            diss -= 0.005f * Time.deltaTime;
            foreach (Material mat in DissolveMat)
                mat.color *= diss;

            if (diss <= 0.985f) Destroy(animaMammut.gameObject);
        }
    }


    void RecargeEnergy()
    {
        if (Energy < StartEnergy)
            Energy += 0.1f;

        GameUI.Instance.BossEnergyBarImage.fillAmount = Energy / StartEnergy;
    }

    IEnumerator MammuthDead()
    {
        if (!mammuthIsDead)
        {

            GameObject.Instantiate(MammuthDeadEffect, animaNeanderthal.transform.position, Quaternion.identity);



            yield return new WaitForSeconds(1);

            //Attiva Boss A piedi
            NeandethalApiedi.transform.position = new Vector3(animaNeanderthal.transform.GetChild(0).position.x, animaNeanderthal.transform.GetChild(0).position.y, GameManager.m_Character.transform.position.z );

            animaNeanderthal.gameObject.SetActive(false);
            
            NeandethalApiedi.SetActive(true);
            yield return new WaitForSeconds(1);
            mammuthIsDead = true;
          
        }
    }



        IEnumerator Dead()
    {
        W_PlayerPoints.StarsComplete = true;

        foreach (GameObject gobj in DestroyAtDead)
            gobj.SetActive(false);

        foreach (GameObject gobj in ActivateAtDead)
            gobj.SetActive(true);

        GameUI.Instance.BossEnergyBarImage.transform.parent.gameObject.SetActive(false);


        yield return new WaitForSeconds(2);
        animaApiedi.GetComponent<Collider>().enabled = false;

        foreach (Collider col in animaApiedi.GetComponentsInChildren<Collider>())
            col.enabled = false;

        yield return new WaitForSeconds(5);
        Destroy(gameObject);

        GameManager.ThisLevelManager.endLevel.OpenPortalEffect();

    }




    private void Update()
    {



        if (neandertalindietreggia)
        {
            animaApiedi.SetBool("Parata", true);
            animaApiedi.SetBool("carica", false);

        }





        if (animaMammut)
        {
            if (mammuthIsDead)
            DissolveMammut();

        MyTime += (Time.deltaTime * Random.Range(0.5f, 1.5f));

       
            animaMammut.transform.LookAt(new Vector3(GameManager.m_Character.transform.position.x, animaMammut.transform.position.y,GameManager.m_Character.transform.position.z));
            PlayerDistance = Vector3.Distance(animaMammut.transform.position, GameManager.m_Character.transform.position);



            if (indietreggia)
            {
                animaMammut.SetBool("Indietreggia", true);

                animaMammut.SetBool("Carica", false);

            }
            else
            {
                animaMammut.SetBool("Indietreggia", false);
            }



            if (PlayerDistance < 15)
            {
                animaMammut.SetBool("Incornata", true);

            }
            else
            {
                animaMammut.SetBool("Incornata", false);

            }


            if (indietreggia) return;
            if (Random.Range(0, 100) > 95)
                if (PlayerDistance < 19 && PlayerDistance > 15)
                {
                    animaMammut.SetBool("Carica", true);

                }
                else
                {
                    animaMammut.SetBool("Carica", false);

                }

        }
    }
}
