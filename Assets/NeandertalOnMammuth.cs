using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeandertalOnMammuth : MonoBehaviour {

    public ParticleSystem ShotEffect;
    public GameObject LanciaPrefab;
    public Transform ShotPoint;
    float SpeedByDistance;
    public Transform LanciaStatica;
    void Start () {
		
	}

    //Chiamato dall'animazione
    public void NeanderthalShot()
    {


        ShotEffect.Emit(5);

        SpeedByDistance = Vector3.Distance(ShotPoint.position, GameManager.m_Character.transform.position);
      
        GameObject lancia = GameObject.Instantiate(LanciaPrefab, ShotPoint.position, ShotPoint.rotation);
        lancia.GetComponent<LanciaShot>().SpeedByDistance = SpeedByDistance + Random.Range(-5f, 15);

        LanciaStatica.gameObject.SetActive(false);
        Invoke("RactivateLanciaStatica", 1);
    }

    void RactivateLanciaStatica() {
        LanciaStatica.gameObject.SetActive(true);
    }

}
