
    using UnityEngine;
    using GooglePlayGames;
    using UnityEngine.SocialPlatforms;
    using UnityEngine.UI;
    using GooglePlayGames.BasicApi;
    using System.Collections;
using System.Net;
using System.Text;



public class SocialConnection : MonoBehaviour
{


    #region PUBLIC_VAR
    #endregion
    #region DEFAULT_UNITY_CALLBACKS
    public string NewUserURL;
    public static SocialConnection instance;
    public Text UserNameText;
    public RawImage UserNamePicture;
    public GameObject NoLoggedMessage;
    public static string UserName;
    public static string UserID;
    public static Texture2D ProfilePic;
    public string UserEmail;
    public Text UserEmailText;
    public static string AccessKey = "17071975";
    [Multiline]
    public string returnWWWMessage;
    public GameObject MessageInfo;

    #endregion



    void Awake()
    {
        if (instance != null)
        {
            Destroy(transform.root.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(transform.root.gameObject);
            instance = this;
        }
        
        MessageInfo = GameObject.Find("_Messages");
      if(MessageInfo)  MessageInfo.SetActive(false);

      //  print("<color=#FFFFFF>Device ID:" + SystemInfo.deviceUniqueIdentifier + "</color>");
    }

        void Start()
    {

      //  print("InternetConnection: " + Application.internetReachability);
 

        if (Application.internetReachability == NetworkReachability.NotReachable ) return;


        StartCoroutine(CheckIfLogged());

        if (!Social.localUser.authenticated && Application.internetReachability != NetworkReachability.NotReachable)
        LogIn();
    }




    //Login 
    public void LogIn()
    {


        if(ConnectionToPlayGame.Instance)
            if (!Social.localUser.authenticated)
                ConnectionToPlayGame.Instance.Connect();

        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                print("Login Success\nNew User:" + Social.localUser.userName);
            }
            else
            {

                print("Login failed");
            }

            StartCoroutine(CheckIfLogged());
        });

       
    }

    public IEnumerator CheckIfLogged()
    {
        yield return new WaitForSeconds(0.2f);

        if (NoLoggedMessage) NoLoggedMessage.SetActive(false);


       

        if (Social.localUser.authenticated)
        {
            UserName = Social.localUser.userName; // UserName
            UserID = Social.localUser.id; // UserID

            if (UserNameText)UserNameText.text = UserName;
   

            if (NoLoggedMessage) NoLoggedMessage.SetActive(false);

            if(UserID!="")
            StartCoroutine(NewUser(UserName, UserID));//Controlla se è un nuovo utente e nel caso, lo aggiunge al Database



        }
        else
        {
            if (UserNamePicture)UserNamePicture.transform.parent.gameObject.SetActive(false);
            if (NoLoggedMessage) NoLoggedMessage.SetActive(true);
            
        }


        if (UserName == "")
        {
            UserNamePicture.transform.parent.gameObject.SetActive(false);
            NoLoggedMessage.SetActive(true);
        }

    }




    /// <summary>
    /// On Logout of your Google Account
    /// </summary>
    public void OnLogOut()
    {
        print("LOG OUT:" + Social.localUser.userName);
        //PlayGamesPlatform.Instance.SignOut(false);

    }



    /// <summary>
    /// //////////////////////////////////////
    /// /////////////////////////////////////
    /// </summary>




    // Se non esiste questo ID nel database, crea un nuovo record sul databse
    IEnumerator NewUser(string name,string ID)
    {
        print("Check if User Exist...");
        if (Application.internetReachability == NetworkReachability.NotReachable) yield return null;

        string post_url = "https://www." + NewUserURL + "&nickname=" + name + "&UserID=" + ID;

        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        string hs_post = "";
        using (WebClient webClient = new WebClient())
        {
            webClient.Encoding = Encoding.UTF8;
            hs_post = webClient.DownloadString(post_url);

        }

        yield return hs_post; // Wait until the download is done

        if (hs_post.Contains("Error"))
        {
            print("There was an error SigUp new User: " + hs_post);
        }else
        {
           print(("TRY TO NEW USER"));
           print(("User " + name + "&UserID=" + ID));
           print(("URL: " + post_url + " Return Text: "+ hs_post));
    
        }
       
    }




    // Cancella l'utente dal databse (solo per debug, non sarà possibile per l'utente cancellarsi)
    public static void DeleteUserFormDatabase()
    {
        string DeleteUserURL = "artistic-minds.it/OKY/DelUser.php?";
        string post_url = DeleteUserURL + "&accesskey=" + SocialConnection.AccessKey + "&UserID=" + SocialConnection.UserID;

        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW("http://" + post_url);

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
        else
        {
            print("<color=#FF0000>UserDeleted</color>" + "UserID: "+SocialConnection.UserID);
        }

    }






    void ShowMessage(string name) {

        if (!MessageInfo) return;

        MessageInfo.SetActive(true);


        if (GameManager.Instance.lang == GameManager.Lang.English)
            MessageInfo.GetComponentInChildren<Text>().text = "<color=#FF0000>Warning!</color>\n" +
        "This device is\n" +
        "registered by another\n" +
        "user (" + returnWWWMessage + ")\n" +
        "Please, exit from the game\n"+
        "and log in with \n" +
        "the correct account.\n";

        else if (GameManager.Instance.lang == GameManager.Lang.Italian)
         MessageInfo.GetComponentInChildren<Text>().text = "<color=#FF0000>Attenzione!</color>\n" +
        "Questo dispositivo è\n" +
        "registrato da un altro\n" +
        "utente (<color=#FF0000>" + returnWWWMessage+ "</color>)\n" +
        "Per favore esci dal gioco\n" +
        "ed accedi conl'account\n"+
        "corretto.\n";
    }

    private void Update()
    {
        if (UserNameText) UserNameText.text = Social.localUser.userName;
        if (UserNameText.text == "Uninitialized") UserNameText.text = "";
    }

}