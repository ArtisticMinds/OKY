using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLedersFromWeb : MonoBehaviour {

    string LeaderboadrsURL = "artistic-minds.it/OKY/OKYLeaderBoard.php?";
    string thisWorld;
    Text UIText;
    void Start () {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            StartCoroutine(GetWebData("FirstFiveScores"));//Prende dati da Web
        }
        UIText = getComponent<PrintOnText>();
    }


    void GetWebData() {
        WWW hs_get = new WWW("http://" + LeaderboadrsURL + "&accesskey=" + SocialConnection.AccessKey + "&UserID=" + SocialConnection.UserID + "&world=" + thisWorld + "&accesskey=" + SocialConnection.AccessKey + "&getdata=" + data + "&DeviceID=" + SystemInfo.deviceUniqueIdentifier);
        yield return hs_get;

        if (data == "WorldLeader")
            PolupateScores(hs_get.text.Trim());
    }

    void PrintOnText(string Leader)
    {
        print(Leader.Split('@')[0];);

            UITexts.text = Leader.Split('@')[0];
    }
}
