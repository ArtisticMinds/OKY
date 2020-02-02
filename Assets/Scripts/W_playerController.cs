using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
[SelectionBase]
public class W_playerController : MonoBehaviour
{
    [SerializeField]
    float m_MovingTurnSpeed = 360;
    [SerializeField]
    float m_StationaryTurnSpeed = 180;
    [SerializeField]
    public float m_JumpPower = 12f;
    [Range(1, 100)]
    [SerializeField]
    float m_HorizontalJump = 2f;
    float Or_m_HorizontalJump;
    [Range(1f, 10f)]
    [SerializeField]
    float m_GravityMultiplier = 3.5f;
    [SerializeField]
    float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
    [SerializeField]
    public float m_MoveSpeedMultiplier = 1f;
    [SerializeField]
    public float m_AnimSpeedMultiplier = 1f;
    [SerializeField]
    public float Crouchingcenter = 0.1f;
    public float NormalDrag = 1;
    public float OnIceDrag = .8f;
    public float NormalMass = 0.7f;
    public float OnIceMass = 0.5f;
    public LayerMask GroundLayerMask;
    public LayerMask CrouchLayers;
    public bool AutoBouce;
    public Rigidbody m_Rigidbody;
    public Animator m_Animator;
    public bool m_IsGrounded;
    public bool m_IsOnIce;
    public bool old_IsGrounded;
    public Material MainRexMaterial;
    [Header("RayGraound")]
    [SerializeField]
    float m_GroundCheckDistance = 0.1f;
    [SerializeField]
    public bool UseRayGroundCheck = true;
    [SerializeField]
    public Vector3  RayStartCenter ;
    [SerializeField]
    public float RayAngle = 1;
    [Space(5)]
    public float MinimumVelocity = 0.5f;
    public float CadutaMultipler = 1;
    float m_OrigGroundCheckDistance;
    const float k_Half = 0.5f;
    float m_TurnAmount;
    public float m_ForwardAmount;
    Vector3 m_GroundNormal;
    float m_CapsuleHeight;
    Vector3 m_CapsuleCenter;
    [HideInInspector]
    public CapsuleCollider m_Capsule;
    bool m_Crouching;
    W_UserControl userContol;
    public float OnAirTime;
    float StoreOnAirTime;
   
    bool dissolve;
    bool HairEnabled;
    public float iceFriction;
    public float FrozenAnimSpeed = 0.3f;
    public float FrozenJumpPower = 10;
    bool UnFrozen;
    public float FrozenDissolveSpeed = 0.05f;


    public RaycastHit RexHitInfo;
    public AudioListener OkyListering;

    [SerializeField]
    [Header("PlayerEnergy")]
    public float PlayerEnergy = 1;
    [Space(10)]


    //Effects
    public ParticleSystem JumpLandingEffect;
    public ParticleSystem OuchEffect;
    int OuchEffectParticleNumbers = 1;
    public ParticleSystem DeadEffect;
    public ParticleSystem SplashEffect;
    public ParticleSystem SplashInLavaEffect;
    public GameObject SuperSpeedEffect;
    public GameObject SuperJumpEffect;
    public GameObject FrozenEffect;
    Material FrozenMaetrial;
    public float diss = 0;
    public ParticleSystem DissolveEffect;
    public static AudioSource PlayerAudioSource;
    public AudioClip OuchSound;
    public AudioClip JumpSound;
    public AudioClip DeadSound;
    public AudioClip EndTimeSound;
    public bool DeadEmitted;
   // [HideInInspector]
    public float OrSpeedMultiplier;
    [HideInInspector]
    public float OrMoveSpeedMultiplier = 1f;
    public GameObject[] ShotTipes;
    public GameObject[] LampShotEffect;
    public bool ShotIsActive;
    [Header("Invulnerability Features")]
    public bool IsInvulnerabile;
    public float InvulrableTime = 3;
    public Renderer[] ObjectToLamp;
    public Material InvulnerableMaterial;
    public static bool EventsAdded;
    public  float PlayerYVelocity;
    public Material[] OriginalsMaterials;
    GameObject _fullEnergyMessage;

    void Start()
        {
            Or_m_HorizontalJump = m_HorizontalJump;
            m_Animator = GetComponent<Animator>();
            m_Rigidbody = GetComponent<Rigidbody>();
            m_Capsule = GetComponent<CapsuleCollider>();
            m_CapsuleHeight = m_Capsule.height;
            m_CapsuleCenter = m_Capsule.center;
            userContol = GetComponent<W_UserControl>();
             m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            m_OrigGroundCheckDistance = m_GroundCheckDistance;
        PlayerAudioSource = GetComponent<AudioSource>();
        SplashEffect.gameObject.SetActive(false);
        FrozenEffect.gameObject.SetActive(false);
        SplashInLavaEffect.gameObject.SetActive(false);
        SuperJumpEffect.gameObject.SetActive(false);
        SuperSpeedEffect.gameObject.SetActive(false);
        JumpItem.Instance.normalJumpPower = m_JumpPower;
        OkyListering = GetComponent<AudioListener>();
        OrSpeedMultiplier = m_AnimSpeedMultiplier;
        OrMoveSpeedMultiplier = m_MoveSpeedMultiplier;
        FrozenMaetrial = FrozenEffect.transform.GetChild(0).GetComponent<Renderer>().material;
        _fullEnergyMessage = GameObject.Find("_fullEnergyMessage");
        _fullEnergyMessage.SetActive(false);
        //Crea l'array dei  materiali originali
        OriginalsMaterials = new Material[ObjectToLamp.Length];

        for (int i = 0; i < ObjectToLamp.Length; i++)
        {
            //Salvo i materiali originali
            OriginalsMaterials[i] = ObjectToLamp[i].material;
        }

        foreach (GameObject LampShotEffect in LampShotEffect)
            LampShotEffect.SetActive(false);

        if (!EventsAdded)
        {
            AddEvent(m_Animator,7, 0.25f, "EmitProjectile", 0);
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


    public bool CheckResumePossibility() {

        //Visualizza o nasconde i pulsanti per fare il resume con gemme e ritorna un bool true se possibile
        if (!GameUI.Instance) return false;

        //Ci deve essere almeno 1 gemma (modificare qui e dentro RemoveGemsFromDatabase del GemManager se servono più gemme per fare il resume)
        if (W_GemManager._istance.PlayerGems <= 0 ||
            GameManager.LastCheckPoint == Vector3.zero)//Se no esiste un punto di Respawn 
            {
                GameUI.Instance.ResumeUseGems1.interactable = GameUI.Instance.ResumeUseGems2.interactable = false;
                return false;
            }
            else
            {
                GameUI.Instance.ResumeUseGems1.interactable = GameUI.Instance.ResumeUseGems2.interactable = true;
                return true;
            }

    }
  







    public void DissolveRex() {

     //   transform.localScale *= 0.8f;
        GameObject.Instantiate(DissolveEffect, GameManager.ThisLevelManager.endLevel.transform.position, transform.rotation);
        dissolve = true;
    }


        public void Move(Vector3 move, bool crouch, bool jump, bool shotInput)
        {

        // convert the world relative moveInput vector into a local-relative
        // turn amount and forward amount required to head in the desired
        // direction.
        if (move.magnitude > 1f) move.Normalize();

            move = transform.InverseTransformDirection(move);
            CheckGroundStatus();
            move = Vector3.ProjectOnPlane(move, m_GroundNormal);
            m_TurnAmount = Mathf.Atan2(move.x, move.z);
            m_ForwardAmount = Mathf.Clamp01(move.z);

            ClampForwardAmmount();
            ApplyExtraTurnRotation();

            // control and velocity handling is different when grounded and airborne:
            if (m_IsGrounded)
            {
             HandleGroundedMovement(crouch, jump);
            OnAirTime = 0;
            HairEnabled = false;
            }
            else
        {
            HairEnabled = true;
               
            OnAirTime++;
            StoreOnAirTime = OnAirTime;
        }

            ScaleCapsuleForCrouching(crouch);
            PreventStandingInLowHeadroom();

        if (GameManager.PlayerIsDead || GameManager.Lose)
        {
            move = Vector3.zero;
            crouch = false;
            jump = false;
            m_Animator.SetBool("Dead", true);
            DeadEffectEmit();
            return;
        }


        //Se il livello risulta completato 
        if (GameManager.LevelComplete || GameManager.Lose)
        {
            move = Vector3.zero;
            crouch = false;
            jump = false;
        }

        // send input and other state parameters to the animator
        UpdateAnimator(move);

        if (shotInput)
        {

            m_Animator.SetTrigger("Shot");

            //print("PlayerShot");
           
        }



        if (m_IsGrounded && !old_IsGrounded) 
            AtterraEffectEmit();

            old_IsGrounded = m_IsGrounded; 
    }

    //Spara - Chiamato dall'animazione
    public void EmitProjectile(int ShotType)
    {

        if (Time.timeSinceLevelLoad < 3) return;

            GameObject Shot = GameObject.Instantiate(ShotTipes[ShotType], LampShotEffect[ShotType].transform.position, transform.rotation);
            LampShotEffect[ShotType].SetActive(true);

    }


    void ClampForwardAmmount() {
      

        if (m_ForwardAmount!=0)
        {

                m_ForwardAmount = Mathf.Clamp(m_ForwardAmount, MinimumVelocity, 1);

        }

    }

    void DeadEffectEmit() {

        if (!DeadEmitted) //Per farlo emettere una sola volta
            DeadEffect.Emit(1);
            GameManager.m_Character.PlayerEnergy = 0;
            DeadEmitted = true;
        } 

    void AtterraEffectEmit()
    {
        float quantCaduta = Mathf.Abs((GameManager.m_Character.PlayerYVelocity) * (CadutaMultipler + GameManager.ThisLevelManager.AddCadutaMultipler));

        //print(quantCaduta);


        if (RexHitInfo.collider) {
           if( RexHitInfo.collider.tag == "Soft" || RexHitInfo.collider.tag == "Tower") {
                quantCaduta = 0;
            }


            
        }

      



        //Solo Puff effect
        if (quantCaduta > 10f)
                {
                    JumpLandingEffect.Emit((int)(quantCaduta / 4));
                }


        if (!m_IsGrounded) return;

                //Toglie energia
                if(!IsInvulnerabile && GameManager.ThisLevelManager.CaduteListering)
                if (quantCaduta > 28f)
                {
                OnAirTime = StoreOnAirTime;
                CalcolaCaduta(quantCaduta + (StoreOnAirTime) / 100);
                
            }
          
                quantCaduta = 0;
                StoreOnAirTime = 0;
    }

    void EmitOuchEffect() {
        OuchEffect.gameObject.SetActive(true);

    }


    void CalcolaCaduta(float quant)
    {
        if (Time.timeSinceLevelLoad < 2) return;


        EmitOuchEffect();
        RemovePlayerEnergy(quant / 100);
        PlayerAudioSource.PlayOneShot(OuchSound);
        print("<color=#ff0000>Forte Caduta</color>:" + quant +"+OnAir: "+ OnAirTime + " Energy:" +GameManager.m_Character.PlayerEnergy);

        if(RexHitInfo.collider)
        print("Contatto caduta: " + RexHitInfo.collider.name );
    }




    void ScaleCapsuleForCrouching(bool crouch)
        {
            if (m_IsGrounded && crouch)
            {
                if (m_Crouching) return;
                m_Capsule.height = m_Capsule.height / 2f;
                m_Capsule.center = m_Capsule.center / 2f* Crouchingcenter;
                m_Crouching = true;
            }
            else
            {
                Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
                float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
                if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, CrouchLayers, QueryTriggerInteraction.Ignore))
                {
                    m_Crouching = true;
                //m_Capsule.height = m_Capsule.height / 2f;
                //m_Capsule.center = m_Capsule.center / 2f* Crouchingcenter;
                return;
                }
                m_Capsule.height = m_CapsuleHeight;
                m_Capsule.center = m_CapsuleCenter;
                m_Crouching = false;
            }
        }

        void PreventStandingInLowHeadroom()
        {
            // prevent standing up in crouch-only zones
            if (!m_Crouching)
            {
                Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
                float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
                if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, CrouchLayers, QueryTriggerInteraction.Ignore))
                {
                    m_Crouching = true;
                }
            }
        }


        void UpdateAnimator(Vector3 move)
        {


        if (dissolve) {
            transform.localScale *= 0.95f;
            transform.LookAt(GameManager.ThisLevelManager.endLevel.transform);
            m_ForwardAmount = 0.6f;
        }
        //Player Morto
        if (GameManager.PlayerIsDead)
        {
            
            m_ForwardAmount = 0;
            m_TurnAmount = 0;
            m_Crouching = false;

            return;
        }


        // update the animator parameters
            m_Animator.SetFloat("Forward", m_ForwardAmount, 0.01f, Time.deltaTime * GameManager.TimeMultipler);
            m_Animator.SetFloat("Turn", m_TurnAmount, 0.01f, Time.deltaTime * GameManager.TimeMultipler);
            m_Animator.SetBool("Crouch", m_Crouching);
            m_Animator.SetBool("OnGround", m_IsGrounded);
            m_Animator.SetBool("Dead", GameManager.PlayerIsDead);
            m_Animator.SetBool("Felice", GameManager.LevelComplete|| GameManager.Respawn);
        if (!m_IsGrounded)
            {
                m_Animator.SetFloat("Jump", m_Rigidbody.velocity.y);
            }

            // calculate which leg is behind, so as to leave that leg trailing in the jump animation
            // (This code is reliant on the specific run cycle offset in our animations,
            // and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
            float runCycle =
                Mathf.Repeat(
                    m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + m_RunCycleLegOffset, 1);
            float jumpLeg = (runCycle < k_Half ? 1 : -1) * m_ForwardAmount;
            if (m_IsGrounded)
            {
                m_Animator.SetFloat("JumpLeg", jumpLeg);
            }

            // the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
            // which affects the movement speed because of the root motion.
            if (m_IsGrounded && move.magnitude > 0)
            {
                m_Animator.speed = m_AnimSpeedMultiplier;
            }
            else
            {
                // don't use that while airborne
                m_Animator.speed = 1;
            }


        
        }


        void HandleAirborneMovement()
        {
            
        // apply extra gravity from multiplier:
        Vector3 extraGravityForce = ((Physics.gravity * (m_GravityMultiplier+GameManager.ThisLevelManager.AddRemoveGravity)) - Physics.gravity);
        Vector3 v = (transform.forward * m_HorizontalJump *  (m_ForwardAmount));
        m_Rigidbody.AddForce(extraGravityForce+(v));

 
        }

    //JUMP
        void HandleGroundedMovement(bool crouch, bool jump)
        {

        // check whether conditions are right to allow a jump:
        if (jump && !crouch && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
        {

            PlayerAudioSource.PlayOneShot(JumpSound);
            Vector3 v = (transform.forward * m_HorizontalJump * (m_ForwardAmount));
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_JumpPower, m_Rigidbody.velocity.z)+(v/10);
            m_IsGrounded = false;

            }
        }




    void ApplyExtraTurnRotation()
        {

            // help the character turn faster (this is in addition to root rotation in the animation)
            float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
            transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime * GameManager.TimeMultipler, 0);
        }


    public void OnAnimatorMove()
    {
        // we implement this function to override the default root motion.
        // this allows us to modify the positional speed before it's applied.



        if (m_IsGrounded)
        {
            if (Time.deltaTime * GameManager.TimeMultipler > 0)
            {
                //Normale
                if (!m_IsOnIce)
                {
                    m_Rigidbody.drag = NormalDrag;
                    m_Rigidbody.mass = NormalMass;

                    Vector3 v = (m_Animator.deltaPosition * m_MoveSpeedMultiplier) / Time.deltaTime * GameManager.TimeMultipler;


                    v.x = Mathf.Clamp(v.x, -10f, 10f);
                    v.z = Mathf.Clamp(v.z, -10f, 10f);

                    // we preserve the existing y part of the current velocity.
                    v.y = m_Rigidbody.velocity.y;
                    m_Rigidbody.velocity = v;
                }
                //Su Ghiaccio
                else
                {
                    m_Rigidbody.drag = OnIceDrag;
                    m_Rigidbody.mass = OnIceMass;

                    SwithcIceFriction();
                    Vector3 v =( (m_Animator.deltaPosition * m_MoveSpeedMultiplier/iceFriction) / Time.deltaTime * GameManager.TimeMultipler);


                    // we preserve the existing y part of the current velocity.
                    v.y = m_Rigidbody.velocity.y;
                    v.x += m_Rigidbody.velocity.x;
                    v.z += m_Rigidbody.velocity.z ;

                    //Limit velocity on Ice
                    v.x = Mathf.Clamp(v.x, -6f, 6f);
                    v.z = Mathf.Clamp(v.z, -6f, 6f);

                    m_Rigidbody.velocity =  v;

                 

                }
            }

        }
 
    }

    void SwithcIceFriction()
    {
        if (FPSCounter.m_CurrentFps < 30)
        {
            iceFriction = 25;
            if (FPSCounter.m_CurrentFps < 23)
                iceFriction = 15;
            if (FPSCounter.m_CurrentFps < 20)
                iceFriction = 5;
        }
        else
        {
            iceFriction = 70;
        }
    }

    bool GroundRays() {
        RaycastHit hitInfo;
        Vector3 RayCenter = transform.position + RayStartCenter;
#if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(RayCenter, transform.position + (Vector3.down + (Vector3.forward * RayAngle)) * m_GroundCheckDistance);
        Debug.DrawLine(RayCenter, transform.position + (Vector3.down + (Vector3.back * RayAngle)) * m_GroundCheckDistance);
        Debug.DrawLine(RayCenter, transform.position + (Vector3.down + (Vector3.left * RayAngle)) * m_GroundCheckDistance);
        Debug.DrawLine(RayCenter, transform.position + (Vector3.down + (Vector3.right * RayAngle)) * m_GroundCheckDistance);
#endif

       
        bool rayHit2 = Physics.Linecast(RayCenter, transform.position + (Vector3.down + (Vector3.forward * RayAngle)) * m_GroundCheckDistance, out hitInfo,  GroundLayerMask, QueryTriggerInteraction.Ignore);
        bool rayHit3 = Physics.Linecast(RayCenter, transform.position + (Vector3.down + (Vector3.back * RayAngle)) * m_GroundCheckDistance, out hitInfo, GroundLayerMask, QueryTriggerInteraction.Ignore);
        bool rayHit4 = Physics.Linecast(RayCenter, transform.position + (Vector3.down + (Vector3.left * RayAngle)) * m_GroundCheckDistance, out hitInfo, GroundLayerMask, QueryTriggerInteraction.Ignore);
        bool rayHit5 = Physics.Linecast(RayCenter, transform.position + (Vector3.down + (Vector3.right * RayAngle)) * m_GroundCheckDistance, out hitInfo, GroundLayerMask, QueryTriggerInteraction.Ignore);



        RexHitInfo = hitInfo;
        return rayHit2 || rayHit3|| rayHit4 || rayHit5;
    }

        void CheckGroundStatus()
        {

        if (!UseRayGroundCheck) return;
            

            // 0.1f is a small offset to start the ray from inside the character
            // it is also good to note that the transform position in the sample assets is at the base of the character
            if (GroundRays())
            {
               
                m_IsGrounded = true;
            if(RexHitInfo.transform)
            if (RexHitInfo.transform.tag.Equals("Ice"))
                m_IsOnIce = true;
            else
                m_IsOnIce = false;
            }
            else
            {
                m_IsGrounded = false;
                m_GroundNormal = Vector3.up;
                m_IsOnIce = false;
        }
        if (RexHitInfo.transform)
        {
            if (RexHitInfo.collider.tag!= "Ice") m_IsOnIce = false;
        }
        else { m_IsOnIce = false; }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.transform.parent)
        {
            if (col.transform.parent.GetComponent<W_platform>()) //Collision with mobile Platform
            {

                if (!CrossPlatformInputManager.GetButtonDown("Jump") && !Input.GetKey(KeyCode.Space))
                    transform.parent = col.transform.parent;
                return;
            }
        }

         if (col.transform.tag.Equals("AttackParent")) //Collision with mobile Platform2
        {

            if (!CrossPlatformInputManager.GetButtonDown("Jump") && !Input.GetKey(KeyCode.Space))
                transform.SetParent(col.transform);
            return;
        }

        else if (col.transform.tag.Equals("GelidWaters"))//Entrata e staziona in acque gelide
        {
            UnFrozen = false;
            FrozenEffect.gameObject.SetActive(true);
            ShowFrozenMaterial();
            SpeedItem.RemoveScreenIcons();
            JumpItem.RemoveScreenIcons();
            m_AnimSpeedMultiplier = FrozenAnimSpeed;
            m_JumpPower = FrozenJumpPower;
        }

    }



    void OnTriggerEnter(Collider col)
    {

        if (GameManager.PlayerIsDead || GameManager.Lose) return;


        if (col.transform.parent)
        {
            if (col.transform.parent.GetComponent<W_platform>()) //Collision with mobile Platform
            {

                if (!CrossPlatformInputManager.GetButtonDown("Jump") && !Input.GetKey(KeyCode.Space))
                    transform.parent = col.transform.parent;
                return;
            }
        }

        if (col.transform.tag.Equals("AttackParent")) //Collision with mobile Platform2
        {

            if (!CrossPlatformInputManager.GetButtonDown("Jump") && !Input.GetKey(KeyCode.Space))
                transform.SetParent(col.transform);
            return;
        }



        if (col.transform.parent)
            if (col.transform.parent.GetComponent<TimeTrab>()) //Collision trabocchetto a tempo
            {
                col.transform.parent.GetComponent<TimeTrab>().PlayerEnter();

                return;
            }


        if (col.transform.GetComponent<Star>()) //Collect Star
        {
            W_PlayerPoints._istance.AddPoints(5);
            W_PlayerPoints._istance.AddStars(col.transform.GetComponent<Star>().Points);
            PlayerAudioSource.PlayOneShot(col.transform.GetComponent<Star>().sound);
            col.transform.GetComponent<Star>().Delete();
            return;
        }

        if (col.transform.GetComponent<Life>())//Collect Life
            {

            if (PlayerEnergy < 1)
            {
                PlayerEnergy += col.transform.GetComponent<Life>().LifePoints;
                W_PlayerPoints._istance.AddPoints(50);
                PlayerAudioSource.PlayOneShot(col.transform.GetComponent<Life>().sound);
                col.transform.GetComponent<Life>().Delete();
                GameManager.gameUI.EnergyHeartAnimator.SetBool("Get", true);
                Invoke("RestetGetEnergy", 1f);
                PlayerEnergy = Mathf.Clamp01(PlayerEnergy);
                return;
            }
            else { ShowFullEnergyMessage(); }
            }
        if (col.transform.GetComponent<GemItem>())//Collect Gem
        {
            W_PlayerPoints._istance.AddPoints(400);
            W_GemManager._istance.AddGems(col.transform.GetComponent<GemItem>().Value);
            PlayerAudioSource.PlayOneShot(col.transform.GetComponent<GemItem>().sound);
            col.transform.GetComponent<GemItem>().Delete();
            return;

        }
        if (col.transform.GetComponent<Cronometer>())//Collect Time
        {
                W_PlayerPoints._istance.AddPoints(50);
                GameManager.Timer.sceneTimer += col.transform.GetComponent<Cronometer>().AddTime;
                PlayerAudioSource.PlayOneShot(col.transform.GetComponent<Cronometer>().sound);
                GameManager.Timer.UIAnimator.SetBool("Get", true);
                GameManager.Timer.UIAnimator.SetBool("Low", false);
                col.transform.GetComponent<Cronometer>().Delete();
                Invoke("RestetGetTime",1f);
                return;
        }

        if (col.transform.GetComponent<Shoes3DItem>())//Collect Items
        {
               W_PlayerPoints._istance.AddPoints(50);
            if (col.transform.GetComponent<Shoes3DItem>().itemType.Equals(Shoes3DItem.ItemType.Speed))//Collect Velocità
            {
                m_AnimSpeedMultiplier += col.transform.GetComponent<Shoes3DItem>().AddValue;
                m_MoveSpeedMultiplier += col.transform.GetComponent<Shoes3DItem>().AddValue;
                PlayerAudioSource.PlayOneShot(col.transform.GetComponent<Shoes3DItem>().sound);
                col.transform.GetComponent<Shoes3DItem>().Delete();
                m_AnimSpeedMultiplier = Mathf.Clamp(m_AnimSpeedMultiplier, 0, 2);
                GameUI.Instance.SpeedItem.SetActive(true);
                GameManager.m_Character.SuperSpeedEffect.SetActive(true);
                SpeedItem.timer = col.transform.GetComponent<Shoes3DItem>().TimeDuration; }
            else if (col.transform.GetComponent<Shoes3DItem>().itemType.Equals(Shoes3DItem.ItemType.Jump))//Collect Jump
            {
                m_JumpPower  += col.transform.GetComponent<Shoes3DItem>().AddValue;
                PlayerAudioSource.PlayOneShot(col.transform.GetComponent<Shoes3DItem>().sound);
                col.transform.GetComponent<Shoes3DItem>().Delete();
                m_JumpPower = Mathf.Clamp(m_JumpPower, 0, 16);
                GameUI.Instance.JumpItem.SetActive(true);
                GameManager.m_Character.SuperJumpEffect.SetActive(true);
                JumpItem.timer = col.transform.GetComponent<Shoes3DItem>().TimeDuration;
            }

            return;
        }



        if (col.transform.GetComponent<FireShot3DItem>())//Collect Shot Item
        {
            W_PlayerPoints._istance.AddPoints(50);
            col.transform.GetComponent<FireShot3DItem>().Delete();
            PlayerAudioSource.PlayOneShot(col.transform.GetComponent<FireShot3DItem>().sound);
            FireUIItem.timer += col.transform.GetComponent<FireShot3DItem>().TimeDuration;
            GameUI.Instance.FireShotItem.SetActive(true);
            GameUI.Instance.FireButton.SetActive(true);
            ShotIsActive = true;

        }



            if (col.transform.GetComponent<W_Projectile>())//Collisione con Proiettile
        {

            if (PlayerEnergy > 0)
            {
                if (!IsInvulnerabile)
                {
                    RemovePlayerEnergy(col.transform.GetComponent<W_Projectile>().Power);
                    EmitOuchEffect();
                    PlayerAudioSource.PlayOneShot(OuchSound);
                    GameManager.m_Character.AutoBounceNow(0.4f);
                    W_PlayerPoints._istance.RemovePoints(50);
                }
                Destroy(col.gameObject);

                return;
            }
        }
        if (col.transform.GetComponent<W_HitSlug>())//ShotHitSlug
        {

            if (PlayerEnergy > 0)
            {

                col.enabled = false;

           if (!IsInvulnerabile)
                {
                RemovePlayerEnergy(col.transform.GetComponent<W_HitSlug>().Power);
                    EmitOuchEffect();
                    PlayerAudioSource.PlayOneShot(OuchSound);
                GameManager.m_Character.AutoBounceNow(0.4f);
                    W_PlayerPoints._istance.RemovePoints(100);
                }
                Destroy(col);
                return;
            }
        }

        if (col.transform.GetComponent<Meteora>())//CollisioneMeteore
        {

            if (PlayerEnergy > 0)
            {
                col.enabled = false;
                if (!IsInvulnerabile)
                {
                    RemovePlayerEnergy(col.transform.GetComponent<Meteora>().Power);
                    EmitOuchEffect();
                    PlayerAudioSource.PlayOneShot(OuchSound);
                    GameManager.m_Character.AutoBounceNow(0.4f);
                    W_PlayerPoints._istance.RemovePoints(50);
                }
                Destroy(col.gameObject);
                return;
            }
        }

        if (col.transform.tag == "Ice")//CollisioneGhiaccio
        {

            if (PlayerEnergy > 0)
            {
                m_Animator.SetBool("Scivola", true);

            }
        }





        if (col.transform.GetComponent<DeadTrigger>())//Collisione con DeadTrigger
        {
            DeadTrigger deadTrigger = col.transform.GetComponent<DeadTrigger>();
            if (!deadTrigger.ActiveOnPlayer) return;

                if (PlayerEnergy > 0)
            {
                
                if (deadTrigger.IsWater)
                {
                    RemovePlayerEnergy(100); //Morte istantanea
                    m_Capsule.enabled = false; //Disattivo il collider del player
                    SplashEffect.transform.SetParent(null);//Stacco l'effetto Splash in acqua
                    SplashEffect.gameObject.SetActive(true);//Attivo l'effetto Splash in acqua
                    GameManager.cameraMovements.target = SplashEffect.transform;//Stacco il follow della telecamera dal player e lo metto sull'effetto Splash
                    W_PlayerPoints._istance.RemovePoints(200);
                    GameManager.ForceDead();
                }
                else if (deadTrigger.IsLava)
                {
                    RemovePlayerEnergy(100); //Morte istantanea
                    m_Capsule.enabled = false; //Disattivo il collider del player
                    SplashInLavaEffect.transform.SetParent(null);//Stacco l'effetto Splash in acqua
                    SplashInLavaEffect.gameObject.SetActive(true);//Attivo l'effetto Splash in acqua
                    GameManager.cameraMovements.target = SplashInLavaEffect.transform;//Stacco il follow della telecamera dal player e lo metto sull'effetto Splash
                    W_PlayerPoints._istance.RemovePoints(200);
                    GameManager.ForceDead();
                }


                else
                {
                    
                        if (!IsInvulnerabile)
                    {
                        GameManager.m_Character.AutoBounceNow(0.6f);
                        RemovePlayerEnergy(deadTrigger.RemoveEnergy);
                        EmitOuchEffect();
                        PlayerAudioSource.PlayOneShot(OuchSound);
                        W_PlayerPoints._istance.RemovePoints(50);
                    }
                    }

                

                return;
            }
        }

    }

    public void ShowFullEnergyMessage() {

        _fullEnergyMessage.SetActive(true);
    }





    public void RemovePlayerEnergy(float quant) {
        PlayerEnergy -= quant*GameManager.Diffic;
        W_PlayerPoints._istance.RemovePoints(10);
        StartCoroutine(Invulnerability());
    }

    public void UnFrozenPlayer() {

        if (m_AnimSpeedMultiplier < OrSpeedMultiplier)
        {
            m_AnimSpeedMultiplier += FrozenDissolveSpeed * Time.deltaTime;
            DissolveFrozenMaterial();

        }
        else
        {
            //Fine Congelamento
            UnFrozen = false;
            FrozenEffect.gameObject.SetActive(false);
            //Ripristino i valori Jump e Speed normali
            m_JumpPower= JumpItem.Instance.normalJumpPower;
            m_AnimSpeedMultiplier = OrSpeedMultiplier;
            W_PlayerPoints._istance.RemovePoints(20);
        }
    }

    void DissolveFrozenMaterial()
    {
        if(diss>0)
        diss -= FrozenDissolveSpeed * Time.deltaTime;
        
        FrozenMaetrial.color = new Color(FrozenMaetrial.color.r, FrozenMaetrial.color.g, FrozenMaetrial.color.b, diss);

    }

    void ShowFrozenMaterial()
    {
        if (diss < 0.6f)
        diss += 0.5f * Time.deltaTime;
        FrozenMaetrial.color = new Color(FrozenMaetrial.color.r, FrozenMaetrial.color.g, FrozenMaetrial.color.b, diss);
      

    }

    Material[] OldMaterials;

 


    IEnumerator Invulnerability()
    {
        IsInvulnerabile = true;

        //Crea l'array dei vecchi materiali
        OldMaterials = new Material[ObjectToLamp.Length];

        for (int i = 0; i < ObjectToLamp.Length; i++)
        {
            //Salva il vecchio materiale
            OldMaterials[i] = ObjectToLamp[i].material;
        }

        yield return new WaitForSeconds(InvulrableTime);
        IsInvulnerabile = false;

        for (int i = 0; i < ObjectToLamp.Length; i++)
        {
            //Applica il vecchio materiale
            ObjectToLamp[i].material = OldMaterials[i];
        }
    }


    float LampTimer;
    void InvulnerabilityLampOky() {

        if (GameManager.PlayerIsDead || GameManager.Lose)
        {
            ResetOriginalMaterials();
            return;
        }


            LampTimer += Time.fixedDeltaTime;

        if (LampTimer > 0.15f)
        {
            for (int i = 0; i < ObjectToLamp.Length; i++)
            {
                //Applica il vecchio materiale
                ObjectToLamp[i].material = OldMaterials[i];
            }
           
        }
        else
        {
            for (int i = 0; i < ObjectToLamp.Length; i++)
            {
                //Applica il vecchio materiale
                ObjectToLamp[i].material = InvulnerableMaterial;
            }

        }

       if(LampTimer>=0.3f) LampTimer = 0;

    }


    public void ResetOriginalMaterials() {


        for (int i = 0; i < ObjectToLamp.Length; i++)
        {
            //Applica i materiali originali
            ObjectToLamp[i].material = OriginalsMaterials[i];
        }
    }



    void OnTriggerExit(Collider col)
    {
        if (col.transform.parent)
            if (col.transform.parent.GetComponent<W_platform>())
        {

            transform.parent = null;
                
            }


            else if (col.transform.tag.Equals("AttackParent")) //Collision with mobile Platform2
            {

                transform.parent = null;
            }

        if (col.transform.tag == "Ice")//UscitaGhiaccio
        {

            if (PlayerEnergy > 0)
            {
                m_Animator.SetBool("Scivola", false);

            }
        }
        else if (col.transform.tag.Equals("GelidWaters"))//Esce da acque gelide
        {
            UnFrozen = true;

        }

    }




    void RestetGetTime()
    {
        GameManager.Timer.UIAnimator.SetBool("Time", false);
    }
    void RestetGetEnergy()
    {
        GameManager.gameUI.EnergyHeartAnimator.SetBool("Get", true);
    }


    public void AutoBounceNow(float Multipler)
    {
        m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_JumpPower* Multipler, m_Rigidbody.velocity.z);
        m_IsGrounded = false;

        print("AutoBouce");

    }

    Vector3 previousPosition;

    float forwardVelocity()
    {
        return transform.InverseTransformDirection(m_Rigidbody.velocity).z;
    }

    void AddOnAirSpeed() {
        if (!m_IsGrounded) {
            Vector3 v = (transform.forward * m_HorizontalJump * (m_ForwardAmount*2));
           if(forwardVelocity() < 4) m_Rigidbody.AddForce(v/25,ForceMode.VelocityChange);
           
        }
    }


    void FixedUpdate() {

        if (Time.timeSinceLevelLoad < 2) return;

        if (HairEnabled) {
            HandleAirborneMovement();
            AddOnAirSpeed();
        }

        PlayerYVelocity = transform.InverseTransformDirection(GameManager.m_Character.m_Rigidbody.velocity).y;
        //Nel caso ci metta il casco
        //aggiungo if(IsInvulnerabile&&!PortaIlCasco)
        if (IsInvulnerabile)
        InvulnerabilityLampOky();

        if (UnFrozen)
            UnFrozenPlayer();

    }


}

