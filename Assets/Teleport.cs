using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Teleport : MonoBehaviour {

    public Teleport TeleportTo;
    bool stay;
    public ParticleSystem Normal;
    public ParticleSystem Active;
    Color OrColor;
    public Color TargetColor;
    [HideInInspector]
    public Renderer rend;
    public AudioClip sound;
    public bool RespawnIsPossibile=true;
    Renderer mainRender;
    public bool OccludeAtStart = true;
    public bool SwithcVisualOnTeleport=false;
    static bool InUse;
 

    void Awake() {
        Normal.Play();
        Active.Stop();
        rend = GetComponent<Renderer>();
        OrColor = rend.materials[1].color;

        mainRender = GetComponent<Renderer>();
        if (!mainRender) mainRender = GetComponentInChildren<Renderer>(true);
        if(OccludeAtStart)
        mainRender.enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.tag == "MainCamera")
        {
            mainRender.enabled = true;
        }

        if (col.transform.root.tag.Equals("Player"))
        {

            if (GameManager.cameraMovements.ToRotation) return;
            //Entra nel trigger
            stay = true;
            Normal.Stop();
            ActiveColors();
            BlinkUseButton.Active();
        }
    }


    public void  ActiveColors() {
        rend.materials[1].color = TargetColor;
        TeleportTo.rend.materials[1].color = TargetColor;
    }

    public void  NormalColors()
    {
        rend.materials[1].color = OrColor;
        TeleportTo.rend.materials[1].color = OrColor;
    }


    void OnTriggerExit(Collider col)
    {

        if (col.tag == "MainCamera")
        {
            mainRender.enabled = false;
        }

        if (col.transform.root.tag.Equals("Player"))
        {
            //Esce dal trigger
            stay = false;
            Normal.Play();
            NormalColors();
            BlinkUseButton.DeActive();
        }
    }

    void TeleportNow()
    {


        GameManager.m_Character.transform.position = TeleportTo.transform.position;
        if (RespawnIsPossibile) GameManager.LastCheckPoint = TeleportTo.transform.position;

        if (SwithcVisualOnTeleport)
        {
            GameManager.cameraMovements.SwitchVisual();
        }
    }

    IEnumerator Inuso() {
        InUse = true;
        //Riattiva tutto
        GameManager.m_Character.m_Animator.SetFloat("Forward", 0, 0.5f, Time.deltaTime * GameManager.TimeMultipler);
        float tmpSpeedMultipler = GameManager.m_Character.m_AnimSpeedMultiplier;
        GameManager.m_Character.m_AnimSpeedMultiplier = 0.05f;
        GameManager.UserControl.m_Rigidbody.isKinematic = true;
        //GameManager.UserControl.enabled = false;
       // GameManager.m_Character.enabled = false;

        yield return new WaitForSeconds(1f);
        InUse = false;
        //Riattiva tutto
        GameManager.UserControl.m_Rigidbody.isKinematic = false;
       // GameManager.UserControl.enabled = true;
       // GameManager.m_Character.enabled = true;
        GameManager.m_Character.m_AnimSpeedMultiplier = tmpSpeedMultipler;

    }

    void Update()
    {
        if (GameManager.PlayerIsDead || GameManager.LevelComplete || GameManager.Lose) return;

        //Se sta sotto al trigger 
        if (stay)
            if (CrossPlatformInputManager.GetButton("Inside") || Input.GetKey(KeyCode.W))
            {

                if (InUse) return;
                StartCoroutine(Inuso());

                if (Active.isEmitting) return; //Per farlo fare una volta sola

                Active.Play();
                Normal.Stop();
                GameManager.MasterAudioSource.PlayOneShot(sound);
                Invoke("TeleportNow", 1);
            }
    }
}
