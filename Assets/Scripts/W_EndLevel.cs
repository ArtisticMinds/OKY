using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Advertisements;
using System.Net;
using System.Text;
public class W_EndLevel : MonoBehaviour {

    public GameObject OpenEffect;
    public AudioClip LevelCompleteSound;
    public AudioClip OpenPortalSound;
    public bool StartOpen = false;


    void Start () {

        //Lo rende invisibile e non attivo
        GameUI.Instance.LevelCompleteMessageUI.GetComponent<CanvasGroup>().interactable = false;
        GameUI.Instance.LevelCompleteMessageUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameUI.Instance.LevelCompleteMessageUI.transform.GetComponent<CanvasGroup>().alpha = 0;
        GameUI.Instance.LevelCompleteMessageUI.GetComponentInChildren<Animator>().enabled = false;

        //Disabilito l'effetto grafico del portale aperto
        OpenEffect.SetActive(false);

        if (!GameManager.Instance.debugMode)
        GetComponent<Renderer>().enabled = false;

        if (StartOpen) OpenPortalEffect();
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
            BlinkUseButton.DeActive();
    }


    void OnTriggerStay (Collider col) {
        if (col.gameObject.tag.Equals("Player"))
        {

            BlinkUseButton.Active();
            if (CrossPlatformInputManager.GetButton("Inside") || Input.GetKey(KeyCode.W))
            {

                //Se il livello risulta già completato 
                if (GameManager.LevelComplete) return;
            //O se il personaggio ha già perso
            if (GameManager.Lose) return;

            //Se sono state raccolte tutte le stelle necessarie
            if (W_PlayerPoints.StarsComplete)
                LivelloCompletato();
            else
                MoreStarsNeededMessage();
            }
        }
	}
    public void MoreStarsNeededMessage()
    {

        if (OpenEffect.activeInHierarchy) return;

       GameUI.Instance._MoreStarsNeeded.SetActive(true);
    }

    public void OpenPortalEffect() {

        if (OpenEffect.activeInHierarchy) return;

        OpenEffect.SetActive(true);
        GameManager.MasterAudioSource.PlayOneShot(OpenPortalSound);
        GameUI.Instance.ShowUseButton();
    }

   public void LivelloCompletato()
    {
        //Segnala che il livello è completato
        GameManager.LevelComplete = true;

        //Attiva il messaggio a schermo
        GameUI.Instance.LevelCompleteMessageUI.gameObject.SetActive(true);
        GameUI.Instance.LevelCompleteMessageUI.GetComponent<CanvasGroup>().interactable = true; //Attiva i pulsanti
        GameUI.Instance.LevelCompleteMessageUI.transform.GetComponent<CanvasGroup>().alpha = 1;//Visualizza la grafica del livello completato
        GameUI.Instance.LevelCompleteMessageUI.GetComponentInChildren<Animator>().enabled = true;
        GameUI.Instance.LevelCompleteMessageUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
        GameUI.Instance.LevelCompleteMessageUI.GetComponent<CanvasGroup>().interactable = true;
        GameManager.MasterAudioSource.PlayOneShot(LevelCompleteSound);

        //Calcola i punti fatti in questo livello aggiungendo anche il tempo rimasto 
        W_PlayerPoints._istance.LevelComplete();

        //Salvo il numero del livello su dataBase
        if (Social.localUser.authenticated && Application.internetReachability != NetworkReachability.NotReachable)
            StartCoroutine(SendLastLevel());


        if(GameManager.ThisLevelManager.LevelNumber!="1")
                if (GameManager.ThisLevelManager.LevelNumber != "4")
                                            StartCoroutine(AdvertisementShow());
    }



    // Salva l'ultimo livello giocato sul database
    IEnumerator AdvertisementShow()
    {
        yield return new WaitForSeconds(0.5f);
        Advertisement.Show();


    }


    // Salva l'ultimo livello giocato sul database
    IEnumerator SendLastLevel()
    {
      


            string post_url = "https//:www.artistic-minds.it/OKY/SetLastLevel.php?" + "&accesskey=" + SocialConnection.AccessKey + "&UserID="+  SocialConnection.UserID + "&LastLevel=" + PlayerPrefs.GetInt(GameManager.Instance.AppName + "_LastLevel") + "&getdata=setLastLevel" ;

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
                print("There was an error posting the Last Level: " + hs_post);
            }
            else
            {
                print("LASTLEVEL: " + post_url);
            }

        

    }
}
