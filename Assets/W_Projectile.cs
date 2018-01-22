using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Projectile : MonoBehaviour {

	public float Speed=10;
    Rigidbody m_Rigidbody;
    public float Duration=5;
    public ParticleSystem DestroyEffect;
    public float Power = 0.2f;
    public Alien01 ShotBy;

    void Awake() {
        m_Rigidbody = GetComponent<Rigidbody>();
        if(m_Rigidbody)m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        //transform.LookAt(transform.forward);
    }

	void Start () {
        Destroy(gameObject, Duration);
        //  transform.LookAt(transform.forward);

        if (m_Rigidbody) m_Rigidbody.constraints = RigidbodyConstraints.None;
        if (DestroyEffect) DestroyEffect.GetComponent<AutoDestruct>().enabled = false;
    }
	

	void Update () {

        if(Speed!=0)
        if (m_Rigidbody) m_Rigidbody.velocity = transform.TransformDirection(new Vector3(0, 0, Speed));
    }

    void OnDestroy()
    {
        if (DestroyEffect)
        {
            DestroyEffect.Emit(3);
            DestroyEffect.transform.SetParent(null);
            DestroyEffect.GetComponent<AutoDestruct>().enabled = true;
        }

      //  if(ShotBy)
       // ShotBy.ShotOnAir = false;
    }
}
