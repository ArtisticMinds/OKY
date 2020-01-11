using UnityEngine;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System.Collections;



public class ConnectionToPlayGame : MonoBehaviour
{
    public static ConnectionToPlayGame Instance;
    public static string UserEmail;
     public void Awake()
    {
        if (Instance != null)
        {
            Destroy(transform.root.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(transform.root.gameObject);
            Instance = this;
        }


        Connect();
    }

    public void Start()
    {

    }


    public void Connect()
    {
        if (Application.isEditor) return;
        if (Application.internetReachability == NetworkReachability.NotReachable) return;

        StartCoroutine(Connession());
    }

    IEnumerator Connession() {
 

        //// Activate the Google Play Games platform
        //PlayGamesPlatform.Activate();
        //// recommended for debugging:
        //PlayGamesPlatform.DebugLogEnabled = true;


        Social.localUser.Authenticate((bool success) => {
            if (success)
            {
               
                Debug.Log("You've successfully logged in");

            }
            else
            {
       
                Debug.Log("Login failed for some reason");
            }

           
        });

        //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        //    .RequestEmail()
        //    .Build();

        //PlayGamesPlatform.InitializeInstance(config);

      
        yield return Social.localUser; // Wait until the download is done

        //UserEmail = PlayGamesPlatform.Instance.GetUserEmail();
    }
}