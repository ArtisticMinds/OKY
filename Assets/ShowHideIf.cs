using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideIf : MonoBehaviour {

    public float Delay;
    public string ShowIfNickIs_01 = "ArtisticMinds75";
    public string ShowIfNickIs_02 = "WILEz75";
    public string ShowIfNickIs_03 = "Lerpz";
    public bool ShowOnlyIfNickNameIs=true;
    public bool ShowOnlyIfNOTAuthenticated = true;
    public bool ShowOnlyIfOnLine;
    public bool DestroyGObj;
    bool active;
    float MyTimer;

    void OnEnable () {
        if (Delay > 0) active = false;
        GetComponent<CanvasGroup>().alpha = 0;
        MyTimer = 0;
    }
	

	void Update () {

        
        if (MyTimer >= Delay)
        {
            active = true;
        }
        else {
            MyTimer += Time.unscaledDeltaTime;
            active = false;
            return;
        }



        if (!active) return;

        if(ShowOnlyIfNickNameIs)
        if(Social.localUser.userName== ShowIfNickIs_01 || Social.localUser.userName == ShowIfNickIs_02 || Social.localUser.userName == ShowIfNickIs_03)
        {

            GetComponent<CanvasGroup>().alpha = 1;
            return;
        }else {
            GetComponent<CanvasGroup>().alpha = 0;
                if (DestroyGObj)
                {
                    Destroy(gameObject);
                    return;
                }
            }


        if(ShowOnlyIfNOTAuthenticated)
        if (Social.localUser.authenticated)
        {
            GetComponent<CanvasGroup>().alpha = 0;
                if (DestroyGObj)
                {
                    Destroy(gameObject);
                    return;
                }
            }
            else{
            GetComponent<CanvasGroup>().alpha = 1;

        }


        if(ShowOnlyIfOnLine)
            if (!CheckInternetConnection.IsOnline) 
        {

                if (DestroyGObj)
                {
                    Destroy(gameObject);
                    return;
                }
                GetComponent<CanvasGroup>().alpha -= Time.unscaledDeltaTime * 0.5f;
  
            }
            else
            {
                GetComponent<CanvasGroup>().alpha += Time.unscaledDeltaTime * 0.5f;

            }
    }
}
