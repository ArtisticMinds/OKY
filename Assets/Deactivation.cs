using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivation : MonoBehaviour
{

    void Awake()
    {
        
    }

    void Start()
    {
        
    }


   public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
