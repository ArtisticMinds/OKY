using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTrigger : MonoBehaviour {

    public Alien01 alien;
    public Neanderthal neanderthal;
    public ParticleSystem effect;


    private void Start()
    {
        if (!neanderthal || !alien)
        {
            alien = GetComponentInParent<Alien01>();
            neanderthal = GetComponentInParent<Neanderthal>();
        }


            
    }


    void OnTriggerEnter(Collider col)
    {


        if (GameManager.PlayerIsDead)
        {

            return;
        }

        if (col.tag.Equals("PlayerFoot"))
        {

            

            
           print("Head Contact Y velocity: " + GameManager.m_Character.PlayerYVelocity);
              if (GameManager.m_Character.PlayerYVelocity < 0.001f)
             {
            if (effect) ParticleSystem.Instantiate(effect,transform.position,transform.rotation);
                GameManager.m_Character.AutoBounceNow(0.8f);
                if (alien) alien.Dead(true);
                if (neanderthal) neanderthal.Dead();
                gameObject.SetActive(false);

        }
    }
    }



}
