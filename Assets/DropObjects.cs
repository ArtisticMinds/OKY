using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjects : MonoBehaviour {


    public  GameObject DropItem;
    public float AddValue =2;
    public float TimeDuration = 60;
    public bool active = true;
    public bool respawnItemAtResume=true;


	public void DropNow () {
        if (!DropItem) return;
        if (active && DropItem)
        Drop();
    }

     void Drop()
    {
        if (!DropItem) return;

        GameObject drop = GameObject.Instantiate(DropItem, transform.position, transform.rotation);
        drop.AddComponent<DropAnimation>();

        if (drop.GetComponent<Shoes3DItem>())
        {
            drop.GetComponent<Shoes3DItem>().AddValue = AddValue;
            drop.GetComponent<Shoes3DItem>().TimeDuration = TimeDuration;
            drop.GetComponent<Shoes3DItem>().respawnItemAtResume = respawnItemAtResume;
        }
        else if (drop.GetComponent<Cronometer>())
        {
            drop.GetComponent<Cronometer>().AddTime = AddValue;
           // drop.GetComponent<Cronometer>().respawnItemAtResume = respawnItemAtResume;
        }
        else if (drop.GetComponent<Life>())
        {
            drop.GetComponent<Life>().LifePoints = AddValue;
           // drop.GetComponent<Life>().respawnItemAtResume = respawnItemAtResume;
        }
        else if (drop.GetComponent<FireShot3DItem>())
        {
            drop.GetComponent<FireShot3DItem>().TimeDuration = TimeDuration;
            drop.GetComponent<FireShot3DItem>().respawnItemAtResume = respawnItemAtResume;
        }
    }
}
