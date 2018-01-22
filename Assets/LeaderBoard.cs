using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;


public class LeaderBoard : MonoBehaviour
{
    #region PUBLIC_VAR
    public string leaderboard;
    #endregion

    #region DEFAULT_UNITY_CALLBACKS
    void Start()
    {
        //// recommended for debugging:
        //PlayGamesPlatform.DebugLogEnabled = true;

        //// Activate the Google Play Games platform
        //PlayGamesPlatform.Activate();


        //if(GameManager.UserIsLogin) OnShowLeaderBoard();


    }
    #endregion

    #region BUTTON_CALLBACKS

 

    ///// <summary>
    ///// Shows All Available Leaderborad
    ///// </summary>
    //public void OnShowLeaderBoard()
    //{
    //    //		Social.ShowLeaderboardUI (); // Show all leaderboard
    //    ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard); // Show current (Active) leaderboard
    //}

    ///// <summary>
    ///// Adds Score To leader board
    ///// </summary>
    //public void OnAddScoreToLeaderBorad()
    //{

    //  //  if(CheckNetwork.checkOnlineStatus()))
    //    if (Social.localUser.authenticated)
    //    {
    //        Social.ReportScore(100, leaderboard, (bool success) =>
    //        {
    //            if (success)
    //            {
    //                Debug.Log("Update Score Success");

    //            }
    //            else
    //            {
    //                Debug.Log("Update Score Fail");
    //            }
    //        });
    //    }
    //}

    /// <summary>
    /// On Logout of your Google+ Account
    /// </summary>
    public void OnLogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut(false);
    }
    #endregion
}