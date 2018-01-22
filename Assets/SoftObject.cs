using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerStay(Collider col)
    {

        if (GameManager.PlayerIsDead || GameManager.Lose) return;



        if (col.tag == "Player")
        {
            if (GameManager.m_Character.RexHitInfo.collider)
                GameManager.m_Character.RexHitInfo.collider.tag = "Soft";
           // GameManager.m_Character.AutoBounceNow(0.5f);

        }
    }
}
