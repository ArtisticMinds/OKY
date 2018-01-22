
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_playerProjectile : MonoBehaviour
{

    public float Speed = 10;
    Rigidbody m_Rigidbody;
    public float Duration = 5;
    public ParticleSystem HitDestroyEffect;
    public ParticleSystem EndLifeDestroyEffect;
    public float Power = 0.2f;
    public bool Hit;


    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        if (m_Rigidbody) m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        HitDestroyEffect.gameObject.SetActive(false);
        EndLifeDestroyEffect.gameObject.SetActive(false);
    }

    void Start()
    {
        Destroy(gameObject, Duration+GameManager.ThisLevelManager.AddLifeToShot);

        if (m_Rigidbody) m_Rigidbody.constraints = RigidbodyConstraints.None;
        if (HitDestroyEffect) HitDestroyEffect.GetComponent<AutoDestruct>().enabled = false;
        if (EndLifeDestroyEffect) EndLifeDestroyEffect.GetComponent<AutoDestruct>().enabled = false;
    }


    void FixedUpdate()
    {


        if (m_Rigidbody) m_Rigidbody.velocity = transform.TransformDirection(new Vector3(0, 0, Speed));
        if (m_Rigidbody.velocity.magnitude < 0.5f)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
       // print(m_Rigidbody.velocity.magnitude);
    }

    void OnDestroy()
    {
        if (Hit)
        {
            HitEffect();
        }
        else
            EndLifeEffect();
    }

    void HitEffect()
    {
        HitDestroyEffect.gameObject.SetActive(true);
        if (HitDestroyEffect)
        {
            HitDestroyEffect.Emit(3);
            HitDestroyEffect.transform.SetParent(null);
            HitDestroyEffect.GetComponent<AutoDestruct>().enabled = true;
        }
    }
    void EndLifeEffect() {
        EndLifeDestroyEffect.gameObject.SetActive(true);
        if (EndLifeDestroyEffect)
        {
            EndLifeDestroyEffect.Emit(3);
            EndLifeDestroyEffect.transform.SetParent(null);
            EndLifeDestroyEffect.GetComponent<AutoDestruct>().enabled = true;
        }


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 0 || col.gameObject.layer == 14 || col.gameObject.layer == 18)
        {
            Hit = false;
            Destroy(gameObject);
        }


        //PlayerShotReciverLayer
        if (col.gameObject.layer == 16 )
        {
            if (col.GetComponent<TriggerPlayerShot>()) //Lo sente ma ci passa attraverso
            {
                return;
            }

            Hit = true;
            if (col.GetComponentInParent<Neanderthal>())
            {
            col.GetComponentInParent<Neanderthal>().Dead();
            }
            else if (col.GetComponentInParent<Alien01>())
            {
            col.GetComponentInParent<Alien01>().Dead(false);
            }

            Destroy(gameObject);
        }
    }
}
