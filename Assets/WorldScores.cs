
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using GooglePlayGames.BasicApi;
using System.Collections.Generic;
using System.Linq;

public class WorldScores : MonoBehaviour {
    public string leaderboardID;
    public Text UnserID;
    public Text[] UsersNamesUITexts;


    public Text UserScore;
    public Text UserRank;
    public Text NumberOfPlayers;
    public GameObject preloader;
    public static GameObject _preloader;

    List<string> userIDs = new List<string>();

    void OnEnable() {
        if (!_preloader) _preloader= preloader;
        if (!Social.localUser.authenticated && Application.internetReachability != NetworkReachability.NotReachable ) SocialConnection.instance.LogIn();
        ShowPlayerScores();
      
    }



    public void ShowPlayerScores()
    {}

    //public void ShowPlayerScores()
    //{

    //    for (int i = 0; i < UsersNamesUITexts.Length; i++)
    //        UsersNamesUITexts[i].text = "------";

    //    UserRank.text = UserScore.text = "--";

    //    if (!Social.localUser.authenticated)
    //    {

    //        MainMenu.Instance.ShowNoConnectedMessage();

    //        if (preloader) preloader.SetActive(false);

    //        print("noConnect");
    //        return;
    //    }

    //    if (preloader) {
    //        preloader.SetActive(true);
    //        Invoke("DeactivatePreloader", 5);
    //    }

    //    userIDs.Clear();


    //    for (int i = 0; i < UsersNamesUITexts.Length; i++)
    //        UsersNamesUITexts[i].text = "-------";

    //    PlayGamesPlatform.Instance.LoadScores(
    //         leaderboardID,
    //         LeaderboardStart.TopScores,
    //         1,
    //         LeaderboardCollection.Public,
    //         LeaderboardTimeSpan.AllTime,
    //     (LeaderboardScoreData data) =>
    //     {
    //         Debug.Log(data.Valid);
    //         Debug.Log(data.Id);
    //         Debug.Log(data.PlayerScore);
    //         // Debug.Log(data.PlayerScore.userID);
    //         // Debug.Log(data.PlayerScore.formattedValue);
    //         UnserID.text = data.PlayerScore.userID;
    //         if (!data.Valid)
    //         {
    //             if (preloader) preloader.SetActive(false); return;
    //         }

    //         foreach (IScore score in data.Scores)
    //         {

    //             userIDs.Add(score.userID);
    //             NumberOfPlayers.text = data.Scores.Length.ToString();

    //         }



    //         PlayGamesPlatform.Instance.LoadUsers(userIDs.ToArray(), (userProfile) => {


    //             for (int i = 0; i < data.Scores.Length; i++)
    //                 UsersNamesUITexts[i].text= userProfile[i].userName;

    //         });


    //         UserRank.text = data.PlayerScore.rank.ToString();//Rank del Player connesso
    //         UserScore.text = data.PlayerScore.value.ToString();//HighScore del Player connesso

    //         if (preloader)preloader.SetActive(false);
    //     });


    //}


    void DeactivatePreloader() {
         preloader.SetActive(false);
    }



}
