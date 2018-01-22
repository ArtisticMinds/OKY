using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotReceiver : MonoBehaviour {


   public Alien01 Alien01Receiver;
    Boss01 boss01Receiver;
    Boss02 boss02Receiver;
    Neanderthal Neanderthal01Receiver;
    Collider thisTrigger;
    public float DamageMultipler = 1;


	void Start () {
        Alien01Receiver = GetComponentInParent<Alien01>();
        boss01Receiver = GetComponentInParent<Boss01>();
        boss02Receiver = GetComponentInParent<Boss02>();
        Neanderthal01Receiver = GetComponentInParent<Neanderthal>();
        thisTrigger = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider col)
    {

        if (Time.timeSinceLevelLoad < 2) return;
        if (col.transform.GetComponent<W_playerProjectile>())//Collisione con Proiettile del Player
        {
            col.transform.GetComponent<W_playerProjectile>().Hit = true;
            Destroy(col.gameObject);

            if (Alien01Receiver)
            {

                Alien01Receiver.Dead(false);
                thisTrigger.enabled = false;
            }


            if (boss01Receiver)
            {
                boss01Receiver.Attack01(Random.Range(0, 50));
                boss01Receiver.RemoveEnergy(col.transform.GetComponent<W_playerProjectile>().Power* DamageMultipler);
            }
            else if (boss02Receiver)
            {
                boss02Receiver.RemoveEnergy(col.transform.GetComponent<W_playerProjectile>().Power * DamageMultipler);
            }

            if (Neanderthal01Receiver)
            {
                thisTrigger.enabled = false;
                Neanderthal01Receiver.Dead();
            }

        }
        else if (col.transform.GetComponent<DeadTrigger>())//Collisione con DeadTrigger
        {
            if (!col.transform.GetComponent<DeadTrigger>().ActiveOnEnemy) return; //Se il ddeadTrigger colpisce anche i nemici

            if (Alien01Receiver)
            {
                    if (col.transform.GetComponent<DeadTrigger>().FiredByA == Alien01Receiver) return;

                    GameUI.Instance.SmartKillUI.SetActive(true);//Visualizza la UI GoogKill
                Alien01Receiver.PointValue *= 2;
                Alien01Receiver.Dead(false);
                thisTrigger.enabled = false;
            }

            if (Neanderthal01Receiver)
            {
                if (col.transform.GetComponent<DeadTrigger>().FiredBy == Neanderthal01Receiver) return;

                GameUI.Instance.SmartKillUI.SetActive(true);//Visualizza la UI GoogKill
                Neanderthal01Receiver.PointValue *= 2;
                Neanderthal01Receiver.Dead();
                thisTrigger.enabled = false;
               
            }
            
        }

        }

}
