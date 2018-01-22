using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OkySkinButton : MonoBehaviour {

    string ButtonName;
    Button button;
    public int UnlockCost=2;
    public Text ValueUI;
    public GameObject lockObject;

	void Awake () {
        button = GetComponent<Button>();
        ButtonName =gameObject.name;
        
    }

    //Se esiste il corrispettivo salvataggio su PlayerPref ritorna True
    bool IsOpen()
    {
        if (PlayerPrefs.HasKey(GameManager.Instance.AppName + ButtonName))
            return true;
        else
            return false;
    }


    public void OnEnable()
    {
        UpdateStatus();

    }

    public void UpdateStatus()
    {
        MainMenu.BuySkinDialog.SetActive(false);

        if (IsOpen())
        {
            //Se già acquistata, abilita la scelta
            GetComponent<W_Button>().enabled = true;
            lockObject.SetActive(false);
            button.onClick.RemoveListener(OpenUnlockSkinPanel); //Disabilita il tasto compra Skin

        }
        else
        { //Se non ancora acquistata

            ValueUI.text = UnlockCost.ToString();
            GetComponent<W_Button>().enabled = false;
            lockObject.SetActive(true);
            button.onClick.AddListener(OpenUnlockSkinPanel);//Abilita il tasto compra Skin
        }
    }

    //OnClick
    void OpenUnlockSkinPanel() //Immette i dati sul pulsante "YES" parameter è il numero ID delle SKIN, parameter2 è il suo costo
    {
        if (Social.localUser.authenticated && //Autenticato
                 Application.internetReachability != NetworkReachability.NotReachable && CheckInternetConnection.IsOnline && //Internet connesso
                !SocialConnection.NoCorrectDeviceID)
        { 
            MainMenu.BuySkinDialog.SetActive(true);
            MainMenu.BuySkinDialog.GetComponentInChildren<W_Button>().parameter = GetComponent<W_Button>().parameter;
            MainMenu.BuySkinDialog.GetComponentInChildren<W_Button>().parameter2 = UnlockCost;
        }
        else
        {

            MainMenu.Instance.ShowNoConnectedMessage();


        }
    }




    }
