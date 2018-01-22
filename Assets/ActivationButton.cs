using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ActivationButton : MonoBehaviour
{


    bool stay;
    public string ActivationString = "Activate";
    public W_platform ActivatePlatform;
    public Animator ThisAnimator;
    public  Animator ActivateAnimator;
    public Animator ActivateAnimator2;
    public bool UsePauseResumeAnimation;
    [Space(10)]
    public AudioClip ActivationSound;
    bool Used = false;
    public GameObject DeactivateGameObject;
    public AudioSource DeactivateAudioSource;
    float orSpeed1;
    float orSpeed2;
    public bool ChangeAnimationSpeed;
    public float NewSpeed = 2;

    void Awake()
    {
        stay = false;
        ThisAnimator = GetComponent<Animator>();



        if (ActivatePlatform) ActivatePlatform.Active = false;
    }

    private void Start()
    {
        if (ActivateAnimator) orSpeed1 = ActivateAnimator.GetFloat("Speed");
        if (ActivateAnimator2) orSpeed2 = ActivateAnimator2.GetFloat("Speed");
    }

    void OnTriggerEnter(Collider col)
    {
        if (GameManager.cameraMovements.ToRotation) return;
        //Entra nel trigger
        if (col.tag == "Player")
        {
            stay = true;
            BlinkUseButton.Active();
        }

    }

    void OnTriggerExit(Collider col)
    {

        //Esce dal trigger
        if (col.tag == "Player")
        {
            stay = false;
            BlinkUseButton.DeActive();
        }

    }


    void Update()
    {
        if (GameManager.PlayerIsDead || GameManager.LevelComplete || GameManager.Lose) return;

        //Se sta sotto al trigger
        if (stay)
            if (CrossPlatformInputManager.GetButtonDown("Inside") || Input.GetKey(KeyCode.W))
            {








                if (ActivateAnimator)
                {

                    if (ChangeAnimationSpeed)
                    {
                        if (ActivateAnimator.GetFloat("Speed") == orSpeed1)
                            ActivateAnimator.SetFloat("Speed", NewSpeed);
                        else
                            ActivateAnimator.SetFloat("Speed", orSpeed1);
                    }


                   else if (UsePauseResumeAnimation)
                    {
                        if (ActivateAnimator.GetFloat("Speed") >= 1)
                        {
                            ActivateAnimator.SetFloat("Speed", 0);
                        }
                        else
                        {
                            ActivateAnimator.SetFloat("Speed", 1);
                        }

                            if (ActivateAnimator.GetComponent<ActivabileObject>())
                            {
                                ActivateAnimator.GetComponent<ActivabileObject>().Used = !ActivateAnimator.GetComponent<ActivabileObject>().Used;
                            }
                        }
                    else
                    {


                        if (!ActivateAnimator.GetComponent<ActivabileObject>().Used)
                        {

                            ActivateAnimator.SetBool(ActivationString, true);//Animator1
                            ActivateAnimator.GetComponent<ActivabileObject>().Used = true;
                        }
                        else
                        {
                            ActivateAnimator.SetBool(ActivationString, false);//Animator1
                            ActivateAnimator.GetComponent<ActivabileObject>().Used = false;
                        }
                    }
                }


        if (ActivateAnimator2) {




                    if (ChangeAnimationSpeed)
                    {
                        if (ActivateAnimator2.GetFloat("Speed") == orSpeed2)
                            ActivateAnimator2.SetFloat("Speed", NewSpeed);
                        else
                            ActivateAnimator2.SetFloat("Speed", orSpeed2);
                    }

                   else if (UsePauseResumeAnimation)
                    {
                        if (ActivateAnimator2.GetFloat("Speed") >= 1)
                            ActivateAnimator2.SetFloat("Speed", 0);
                        else
                            ActivateAnimator2.SetFloat("Speed", 1);


                        if (ActivateAnimator2.GetComponent<ActivabileObject>())
                        {
                            ActivateAnimator2.GetComponent<ActivabileObject>().Used = !ActivateAnimator.GetComponent<ActivabileObject>().Used;
                        }

                    }
                    else
                    {

                        if (!ActivateAnimator2.GetComponent<ActivabileObject>().Used)
                        {

                            ActivateAnimator2.SetBool(ActivationString, true);//Animator2
                            ActivateAnimator2.GetComponent<ActivabileObject>().Used = true;
                        }
                        else
                        {
                            ActivateAnimator2.SetBool(ActivationString, false);//Animator2
                            ActivateAnimator2.GetComponent<ActivabileObject>().Used = false;
                        }
                    }
        }


                
                if (DeactivateGameObject)
                    DeactivateGameObject.SetActive(!DeactivateGameObject.activeInHierarchy);

                if (DeactivateAudioSource)
                    DeactivateAudioSource.enabled= !DeactivateAudioSource.enabled;

                

                ///Animazione Leva e piattaforma
                if (!Used)
                {
                    
                    if (ActivatePlatform) { ActivatePlatform.Active = true; }///Animazione piattaforma
                    if (ThisAnimator) { ThisAnimator.SetBool(ActivationString, true); }///Animazione Leva
                    Used = true;
                }
                else
                {

                    if (ActivatePlatform) { ActivatePlatform.Active = false; }///Animazione piattaforma
                    if (ThisAnimator) { ThisAnimator.SetBool(ActivationString, false); }///Animazione Leva
                    Used = false;

                }




                if (ActivationSound) GameManager.MasterAudioSource.PlayOneShot(ActivationSound);

            }
    }
}
