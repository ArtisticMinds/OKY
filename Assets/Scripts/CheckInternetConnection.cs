using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System;

public class CheckInternetConnection : MonoBehaviour
{

    public static bool IsOnline;

    void Start() {

        InvokeRepeating("CheckConnection",1, 35);
    }

   public void CheckConnection()
    {
        StartCoroutine(Check());

    }


   public IEnumerator Check()
    {
        
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.isDone && www.bytesDownloaded > 0)
                {
            IsOnline=true;
        }

        if (www.isDone && www.bytesDownloaded == 0)
            IsOnline = false;


        print("IsOnline: " + IsOnline);
    }
    
}