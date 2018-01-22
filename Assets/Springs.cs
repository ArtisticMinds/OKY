using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springs : MonoBehaviour {

    public float SpringPower=2;
    Animator animator;

	void Start () {
        animator = GetComponent<Animator>();

    }


    void OnTriggerEnter(Collider col)
    {

        if (GameManager.PlayerIsDead || GameManager.Lose) return;



        if (col.tag == "Player")
        {
            if(GameManager.m_Character.RexHitInfo.collider)
            GameManager.m_Character.RexHitInfo.collider.tag = "Soft";

            animator.SetBool("Activate", true);
            //   PlayerAudioSource.PlayOneShot(mollaSound);
            AddForce(col.GetComponentInParent<Rigidbody>());
            if (GameManager.m_Character.RexHitInfo.collider)
                GameManager.m_Character.RexHitInfo.collider.tag = "null";
        }
    }

    void AddForce(Rigidbody rig) {


        Vector3 Force = (transform.forward * SpringPower) - (transform.forward * Mathf.Clamp(rig.velocity.y,-15f,15f));
        Force = new Vector3(Mathf.Clamp(Force.x, -45f, 45f), Mathf.Clamp(Force.y, 5f, 45f), Mathf.Clamp(Force.z, -45f, 45f));


        rig.AddForce(Force, ForceMode.VelocityChange);

    }

    void OnTriggerExit(Collider col)
    {

        //Esce dal trigger
        if (col.tag == "Player")
            Invoke("DeactivateAnimation", 1);

    }
     void DeactivateAnimation() {
        animator.SetBool("Activate", false);
    }
}
