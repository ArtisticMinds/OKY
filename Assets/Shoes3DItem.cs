
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class Shoes3DItem : MonoBehaviour
{

    public ItemType itemType = ItemType.Speed;
    public enum ItemType
    {
        Speed, Jump
    }
    AutoMoveAndRotate rotateAndMove;
    public float RotatioDelay;
    public float AddValue = 0.3f;
    public GameObject ParticleOnDestroy;
    public AudioClip sound;
    public float TimeDuration = 10;
    public bool respawnItemAtResume;

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
        
        GameObject.Instantiate(ParticleOnDestroy, transform.position, transform.rotation);
        //Non distruggere ma disattiva solamente
        //Poi viene salvato tra gli oggetti da riattivare quando c'è un resume
        if (respawnItemAtResume) {
            GameManager.ThisLevelManager.ObjectToRespawnOnResume.Add(gameObject);
            gameObject.SetActive(false); }
        else
            Destroy(gameObject);

    }

    void ActivateRotation()
    {
        rotateAndMove.enabled = true;
    }


}
