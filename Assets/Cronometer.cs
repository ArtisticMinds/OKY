using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class Cronometer : MonoBehaviour
{


    AutoMoveAndRotate rotateAndMove;
    public float RotatioDelay;
    public float AddTime = 30;
    public GameObject ParticleOnDestroy;
    public AudioClip sound;
  //  public bool respawnItemAtResume;


    void Awake()
    {
        if (RotatioDelay > 0)
        {
            rotateAndMove = GetComponent<AutoMoveAndRotate>();

            rotateAndMove.enabled = false;
            Invoke("ActivateRotation", RotatioDelay);
        }

    }

    public void Delete()
    {
       // GameManager.ThisLevelManager.ObjectToRespawnOnResume.Add(gameObject);
       GameObject effect= GameObject.Instantiate(ParticleOnDestroy, transform.position, transform.rotation);
        effect.GetComponentInChildren<TextMesh>().text ="+"+ AddTime.ToString()+"s";
        //Non distruggere ma disattiva solamente
        //Poi viene salvato tra gli oggetti da riattivare quando c'è un resume
        //  if (respawnItemAtResume) gameObject.SetActive(false);
        //  else

        //Distruggo sempre il cronometro, tanto viene riazzerato il timer
        Destroy(gameObject);


    }

    void ActivateRotation()
    {
        rotateAndMove.enabled = true;
    }


}
