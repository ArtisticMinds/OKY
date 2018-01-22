using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour {

    public float RemoveEnergy = 100000;
    public bool IsWater = false;
    public bool IsLava = false;
    public bool ActiveOnEnemy =true;
    public bool ActiveOnPlayer = true;
    public Neanderthal FiredBy;
    public Alien01 FiredByA;


}
