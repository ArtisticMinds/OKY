using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationTrigger : MonoBehaviour {

    public float Delay = 0;
    public float RandomDealay = 1;
    public Animator anim;
    public bool EnableDisableAnim;
    public string BoolStringActivation;
    public GameObject TargetMessage;
    public string FunctionStringMessage;
    public GameObject[] gObject;
    bool ObjectsHidded;
    public Behaviour component;
    public AudioClip SoundOnEnter;
    public AudioClip SoundOnExit;
    public bool ActivateBossBar = false;
    [Header("ShakeCamera Parameters")]
    public bool shakecamera;
    public float _shakeDuration=1;
    public float _shakeAmount=1;
    public float _decreaseFactor=1;
    public bool DestroyOnActivation = false;
    public bool IsActive;
    bool MessageAlreadyShowed;
    [Space(10)]
    public bool IsSecretArea;
    public bool OnlyOneActivation = false;
    public bool OnlyOneSecretAreaMessage = true;
    public int AddPointsOnEnter = 200;
    public static EndLevelSecretsAreaUI endLevelSecretsAreaUI;
    public bool AddToSecretsAreaCount = true;
    public bool RandomActivation;
    [Range(3,6)]
    public int randomRange = 3;
    public bool ActiveOnEnemy;
    [Space(10)]
    public GameObject DetackObject;
    public GameObject ActivateObject;
    public GameObject SendMessageTo;
    public string message;

    void Awake ()
    {



          if(!endLevelSecretsAreaUI)
        endLevelSecretsAreaUI = FindObjectOfType<EndLevelSecretsAreaUI>();

    }

    void Start() {


        if (component)
            component.enabled = false;

        if (anim && EnableDisableAnim) anim.enabled = false;

    }

    void HideObjects()
    {
        if (gObject.Length > 0)
            foreach (GameObject gobj in gObject)
               if(gobj) gobj.SetActive(false);

        ObjectsHidded = true;
    }

        void OnTriggerEnter(Collider col)
    {

        if (RandomActivation)
            if (Random.Range(0, randomRange) != 2) return;

        if (OnlyOneActivation)
        {
            if (col.transform.root.tag.Equals("Player") && !IsActive)
            {
                if (Delay > 0)
                    Invoke("Activate", Delay + Random.Range(0, RandomDealay));
                else
                    Activate();

                IsActive = true;





                if (IsSecretArea)
                {
                    if (OnlyOneSecretAreaMessage)
                    {
                        if (!MessageAlreadyShowed)
                        {
                            GameUI.Instance.SecretAreaFoundUI.SetActive(true);//Visualizza la UI
                            if (AddToSecretsAreaCount)
                                endLevelSecretsAreaUI.AddDiscoveredArea();
                        }

                        MessageAlreadyShowed = true;



                        return;
                    }
                    else
                    {
                        GameUI.Instance.SecretAreaFoundUI.SetActive(true);//Visualizza la UI
                    }


                }

                        if (ActivateBossBar && GameUI.Instance.BossEnergyBarImage)
                        GameUI.Instance.BossEnergyBarImage.transform.parent.gameObject.SetActive(true);


                if (AddPointsOnEnter > 0)
                {
                    W_PlayerPoints._istance.AddPoints(AddPointsOnEnter);
                    AddPointsOnEnter = 0;
                }
            }

        }
        else
        {
            
            if (col.transform.root.tag.Equals("Player")||(ActiveOnEnemy && col.transform.tag.Equals("Enemy")))
            {
                if (Delay > 0)
                    Invoke("Activate", Delay + Random.Range(0, RandomDealay));
                else
                    Activate();

                if (IsSecretArea)
                {
                    if (OnlyOneSecretAreaMessage)
                    {
                        if (!MessageAlreadyShowed)
                        {
                            GameUI.Instance.SecretAreaFoundUI.SetActive(true);//Visualizza la UI

                            if (AddToSecretsAreaCount)
                                endLevelSecretsAreaUI.AddDiscoveredArea();
                        }

                        MessageAlreadyShowed = true;
                        return;
                    }
                    else
                    {
                        GameUI.Instance.SecretAreaFoundUI.SetActive(true);//Visualizza la UI
                    }
                }

                IsActive = true;

            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.transform.root.tag.Equals("Player"))
        {
            if (anim)
                anim.SetBool("Activate", false);

            if (SoundOnExit)
                GameManager.MasterAudioSource.PlayOneShot(SoundOnExit);


            if (IsSecretArea)
                GameUI.Instance.SecretAreaFoundUI.SetActive(false);//Nasconde la UI


            if (BoolStringActivation != "")
                anim.SetBool(BoolStringActivation, false);
        }
    }

    void Activate() {


        if (anim) {
            if (EnableDisableAnim) anim.enabled = true;

                 anim.SetBool("Activate", true);

        }


        if (DetackObject) DetackObject.transform.SetParent(null);
        if (ActivateObject) ActivateObject.SetActive(true);

        if (SendMessageTo)
            SendMessageTo.SendMessage(message);

        if (BoolStringActivation!="")
            anim.SetBool(BoolStringActivation, true);

        if (FunctionStringMessage != "")
            TargetMessage.SendMessage(FunctionStringMessage);



        if (gObject.Length > 0)
            {
                foreach (GameObject gobj in gObject)
                   if(gobj) gobj.SetActive(true);
            }
            if (shakecamera)
                GameManager.cameraShake.shakecamera(_shakeDuration, _shakeAmount, _decreaseFactor);
           if (component)
            component.enabled=true;



        if (DestroyOnActivation) Destroy(gameObject);

        if (IsSecretArea && OnlyOneSecretAreaMessage)
        {

            if (MessageAlreadyShowed)
            {
                return;
            }
            
        }
       
            if (SoundOnEnter)
                GameManager.MasterAudioSource.PlayOneShot(SoundOnEnter);

 

    }



    private void LateUpdate()
    {

        if (!ObjectsHidded)
        if (W_GemManager.GetedGemsDeleted)
            HideObjects();
    }
}
