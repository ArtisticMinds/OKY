using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class W_SceneItem : MonoBehaviour
{
    public string SceneNameToLoad;
    CanvasGroup thisCanvas;
    [Header("Numeri livelli")]
    public string LevelNumber;
    public string OpeningSceneLevelNumber;
    [Space(10)]
    public Text LevelPointsText;
    public GameObject LockIcon;
    public GameObject[] Stars;
    public GameObject PerfectIcon;
    public GameObject OpeningEffect;
    public bool IsLocked;
    private string loadProgress = "Loading...";
    bool LaodingActive;
    public bool IsBonus;
    public GameObject OpenBonusButton;
    Button btn;


    private bool LoadingIsActive = false; 
    AsyncOperation async = null;

    public int ThisLevelPoints;
    int stars = 0;


   public void CheckIfOpen()
    {


        //Se non è un bonus
        if (!IsBonus)
        {
            //Se il suo livello di dipendenza è completo (se ha un punteggio)
            if (LevelNumber=="1" || PlayerPrefs.GetInt(GameManager.Instance.AppName + "LevN_" + OpeningSceneLevelNumber) > 0 || WorldLevelsPanel.AllLevelsOpen)
                IsLocked = false;

        }//Se è un livello bonus, lo apro se risulta aperto dai salvataggi
        else
        {//Se esiste un salvataggio tipo "OKY_BonusOpen_1001"
            if (PlayerPrefs.HasKey(GameManager.Instance.AppName + "_BonusOpen_" + LevelNumber))
            {
                   OpenBonusButton.SetActive(false);
                   IsLocked = false;
            }
        }


        //Se questo livello è stato completato
        if (IsComplete())
        {
            IsLocked = false;
            Stars[0].transform.parent.gameObject.SetActive(true);//Se completo allora posso visualizzare le stelle
            if(OpenBonusButton)
            if (IsBonus) OpenBonusButton.SetActive(false);

            //Faccio il calcolo che isualizza o nasconde le stelle/corona                                                     
            ShowStarsIcons();
        }
        else
        {//Se non completo allora nascondo tutto il gameObject padre delle stelle 
            Stars[0].transform.parent.gameObject.SetActive(false);
        }


        GetComponent<Button>().interactable = !IsLocked;
        LockIcon.SetActive(IsLocked);

        if (OpeningEffect) {
            OpeningEffect.SetActive(!IsLocked);
           if(IsComplete())
                OpeningEffect.SetActive(false);
        }


    }



        void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);


    }

    void OnEnable()
    {


        UpdateStatus();

    }

    public void UpdateStatus() {


        //Se la sua apertura dipende dal completamento di un altro livello
        if (OpeningSceneLevelNumber != "")
        {
            if (!IsBonus)
                IsLocked = true;
        }
        else//Se non è specificato il livello di dipendenza, apri il livello
        {
            IsLocked = false;
        }

        if (IsBonus)
        {
            IsLocked = true;

        }
        else
        {
            if (WorldLevelsPanel.AllLevelsOpen) IsLocked = false;
        }

        //Nascondo tutte le stelle/corone, una ad una
        Stars[0].SetActive(false);
        Stars[1].SetActive(false);
        Stars[2].SetActive(false);
        PerfectIcon.SetActive(false);

        //Ad ogni riattivazione del menu faccio il controllo
        CheckIfOpen();

    }

    void TaskOnClick()
    {
        MainMenu.LoadingBar.fillAmount = 0;
        MainMenu.textPourcentage.text = "";
        print("You have clicked " + SceneNameToLoad);
        ChargementScene(SceneNameToLoad);
    }



    //Se esiste un punteggio salvato per questo livello, ritorna true e segno Complete=true
    public bool IsComplete()
    {
        //string pointsString="";

        ////if (GameManager.Instance.lang == GameManager.Lang.Italian) pointsString = " Punti";
        ////if (GameManager.Instance.lang == GameManager.Lang.English) pointsString = " Points";

        ThisLevelPoints = PlayerPrefs.GetInt(GameManager.Instance.AppName + "LevN_" + LevelNumber);
        if (ThisLevelPoints > 0)
        {
            LevelPointsText.text = ThisLevelPoints.ToString(); 
            if(OpenBonusButton)
            if(IsBonus) OpenBonusButton.SetActive(false);

            return true;
        }
        else
        {
            LevelPointsText.text = "";
            return false;
        }
    }


    void ShowStarsIcons()
    {
        if (!IsComplete())
        {
            Stars[0].transform.parent.gameObject.SetActive(false);
            return;
        }


          Stars[0].SetActive(true);//Se completato, almeno una stella

          //Nascondo tutte le stelle/corone, una ad una
          Stars[1].SetActive(false);
          Stars[2].SetActive(false);
          PerfectIcon.SetActive(false);

            //Qui in base al punteggio visualizzo le stelle e/o la corona
            if (ThisLevelPoints > GameManager.Star02Points) Stars[1].SetActive(true);
            if (ThisLevelPoints > GameManager.Star03Points) Stars[2].SetActive(true);
            if (ThisLevelPoints > GameManager.CrowPoints) PerfectIcon.SetActive(true);



    }




    //Caricamento
    public void ChargementScene(string SceneName)
    {
        LoadingIsActive = true;
        MainMenu.LoadingPanel.SetActive(true);
        async = SceneManager.LoadSceneAsync(SceneName,LoadSceneMode.Single);
        async.allowSceneActivation = false;
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }



    void Update() {


            if (LoadingIsActive)
            {
                StartCoroutine(LevelCoroutine());

            }

       

    }




    IEnumerator LevelCoroutine()
    {

        float pourcentage = 0;
        while (!async.isDone)
        {
            if (async.progress < 0.9f)
            {

                MainMenu.LoadingBar.fillAmount =  async.progress / 0.9f;
                pourcentage = async.progress * 100;
                MainMenu.textPourcentage.text = (int)pourcentage + "%";
            }
            else
            {

                MainMenu.LoadingBar.fillAmount =  async.progress / 0.9f;
                pourcentage = (async.progress / 0.9f) * 100;
                MainMenu.textPourcentage.text = (int)pourcentage + "%";
                async.allowSceneActivation = true;
            }

            yield return null;
        }


        yield return async;

    }


}
