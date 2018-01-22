using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteora : MonoBehaviour {

    public float Duration = 5;
    public ParticleSystem DestroyEffect;
    public float Power = 0.2f;
    Rigidbody m_Rigidbody;
    public Vector3 AddTorque = Vector3.zero;


    void Start () {
        DestroyEffect.GetComponent<AutoDestruct>().enabled = false;
        Destroy(gameObject, Duration);
        m_Rigidbody = GetComponent<Rigidbody>();
        transform.LookAt(GameManager.m_Character.transform);
        m_Rigidbody.AddForce(transform.forward * 5 * m_Rigidbody.mass, ForceMode.Impulse);
        m_Rigidbody.AddRelativeTorque(AddTorque,ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 0 || col.gameObject.layer == 14)
            Destroy(gameObject);
    }

    void OnDestroy()
    {
        
        if (DestroyEffect)
        {
            DestroyEffect.gameObject.SetActive(true);
            DestroyEffect.transform.SetParent(null);
            DestroyEffect.GetComponent<AutoDestruct>().enabled = true;
            DestroyEffect.GetComponent<AudioSource>().enabled = true;
        }
        GameManager.cameraShake.shakecamera(0.3f, 2* m_Rigidbody.mass, 1f);
    }
 
}
