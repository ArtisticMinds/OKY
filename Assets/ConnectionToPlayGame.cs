using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System.Collections;



public class ConnectionToPlayGame : MonoBehaviour
{ 
    public static ConnectionToPlayGame Instance;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);


    }



    // Use this for initialization
    void Start()
    {

          Connect();

    }

    public void Connect()
    {

        if (!Social.localUser.authenticated) { 
       if(!Application.isEditor) ActivateGPG(); //Per connettersi con Lerp
        StartCoroutine(LogIn());
    }

    }


    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }

    void ActivateGPG()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
       
    }

    //Login 
    public IEnumerator LogIn()
    {
        Time.timeScale = 1;

        if (Social.localUser.authenticated)
        {

            Debug.Log("User Already Authenticated: " + Social.localUser.userName);
   
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);

        Social.localUser.Authenticate((bool success) =>
        {

            if (success)
            {

                Debug.Log("OK Login (GooglePlayGameConnection)");
            }
            else
            {
                Debug.Log("No Login (GooglePlayGameConnection)");

            }


        });

    }

    public void SignOUT()
    {
        PlayGamesPlatform.Instance.SignOut();
    }



}