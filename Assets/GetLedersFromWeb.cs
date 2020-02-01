using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Text;

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
        string url= "http://" + LeaderboadrsURL + "&world=" + thisWorld + "&getdata=WorldLeader" ;

        string hs_get = "";
        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

        using (WebClient webClient = new WebClient())
        {
            webClient.Encoding = Encoding.UTF8;
            hs_get = webClient.DownloadString(url);

        }

        yield return hs_get ;


       // print("<color=#FFFF00>WorldLeader request URL</color> " + url);
       // print("<color=#FFFF00>Return Text</color> " + hs_get);


        if (hs_get.Contains("Juniper") || hs_get.Contains("Error"))
        {
            rootCanvas.alpha = 0;
            UIText.text = "-----";
            print("<color=#FF5500>There was an error getting the high score -</color> " + hs_get);
        }
        else
        {
            PrintOnText(hs_get.Trim());
        }
    }

    void PrintOnText(string Leader)
    {
      //  print("World"+thisWorld+" Leader = " +Leader.Split('@')[0]);

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
