using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLedersFromWeb : MonoBehaviour {

    public string LeaderboadrsURL = "artistic-minds.it/OKY/OKYLeaderBoard.php?";
    public string thisWorld;
    public static CanvasGroup rootCanvas;
    Text UIText;


    private void Awake()
    {
        UIText = GetComponent<Text>();
       
        if (!rootCanvas)rootCanvas = GameObject.Find("LeaderBoardPanel").GetComponent<CanvasGroup>();
       

    }

    void OnEnable () {
        rootCanvas.alpha = 0;
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            StartCoroutine(InvokeGetData());
        }
        
    }



   public IEnumerator InvokeGetData() {
        UIText.text = "";
        yield return new WaitForSecondsRealtime(2);
        StartCoroutine(GetWebData());//Prende dati da Web 
    }

        IEnumerator GetWebData() {

        WWW hs_get = new WWW("http://" + LeaderboadrsURL + "&accesskey=" + SocialConnection.AccessKey + "&UserID=" + SocialConnection.UserID + "&world=" + thisWorld + "&accesskey=" + SocialConnection.AccessKey + "&getdata=WorldLeader" + "&DeviceID=" + SystemInfo.deviceUniqueIdentifier);
        yield return hs_get;
        if (hs_get.error != null)
        {
            rootCanvas.alpha = 0;
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            PrintOnText(hs_get.text.Trim());
        }
    }

    void PrintOnText(string Leader)
    {
        print("World"+thisWorld+" Leader = " +Leader.Split('@')[0]);

            UIText.text = Leader.Split('@')[0];
    }


    private void Update()
    {
        if (!CheckInternetConnection.IsOnline || UIText.text=="")
        {

            rootCanvas.alpha -= Time.unscaledDeltaTime * 0.5f;

        }
        else
        {
            rootCanvas.alpha += Time.unscaledDeltaTime * 0.5f;

        }
    }
}
