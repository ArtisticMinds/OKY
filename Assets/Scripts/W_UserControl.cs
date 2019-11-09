using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityStandardAssets.CrossPlatformInput;



    [RequireComponent(typeof(W_playerController))]
    public class W_UserControl : MonoBehaviour
    {
        private W_playerController m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
    public Vector3 m_Move;
    public bool m_Jump;
    bool crouch;
    bool Shot;
    public float  HorizontalAxis;
    public float VerticalAxis;
    public bool UseDoubleArrows;

    public Rigidbody m_Rigidbody;

    private void Start()
        {


            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<W_playerController>();
            m_Rigidbody= GetComponent<Rigidbody>();
    }



    private void ControlsUpdate()
    {
        m_Jump = CrossPlatformInputManager.GetButton("Jump") || Input.GetKey(KeyCode.Space) || m_Character.AutoBouce;


        // read inputs
        if (!UseDoubleArrows)
        { 
        HorizontalAxis = CrossPlatformInputManager.GetAxis("Horizontal") + Input.GetAxis("Horizontal");        
        VerticalAxis = CrossPlatformInputManager.GetAxis("Vertical") + Input.GetAxis("Vertical");
        }
        crouch = CrossPlatformInputManager.GetButton("Crouch") || Input.GetKey(KeyCode.C);
        Shot = CrossPlatformInputManager.GetButtonDown("Shot") || Input.GetKeyDown(KeyCode.RightControl);
    }

    public void GoLeft()
    {
        if (!UseDoubleArrows) return;
            HorizontalAxis = -m_Character.m_MoveSpeedMultiplier;
    }

    public void GoRight()
    {
        if (!UseDoubleArrows) return;
        HorizontalAxis = m_Character.m_MoveSpeedMultiplier; ;
    }

    public void OnRelease()
    {
        if (!UseDoubleArrows) return;
        HorizontalAxis = 0f;
    }

    private void Update()
        {
        ControlsUpdate();

            // calculate move direction to pass to character
        if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = VerticalAxis * m_CamForward + HorizontalAxis * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = VerticalAxis * Vector3.forward + HorizontalAxis * Vector3.right;
            }



        if (GameManager.PlayerIsDead || GameManager.LevelComplete || GameManager.Lose) m_Move = Vector3.zero;

        // pass all parameters to the character control script
        m_Character.Move(m_Move, crouch, m_Jump,Shot);
  


        }

    public IEnumerator RemoveBounce()
    {
 
        yield return new WaitForEndOfFrame(); // wait for nexFrame
        m_Jump = false;
    }








}

