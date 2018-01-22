using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    static public GameUI Instance;

     public GameObject _MiniMenu;
     public GameObject _MiniOptionsMenu;
     public GameObject _DeadPanel;
    public GameObject _EndTimePanel;
    public Image EnergyBarImage;
    public Animator EnergyHeartAnimator;
    public Animator BossEnergyAnimator;
    public GameObject LevelCompleteMessageUI;
    public GameObject OpenSceneUI;
    public GameObject _MoreStarsNeeded;
    public GameObject _autoSettingUI;
    public GameObject EndTestingMessage;
    [Header("ActiveItems")]
    public GameObject SpeedItem;
    public GameObject JumpItem;
    public GameObject FireShotItem;
    public GameObject FireButton;
    public Button NextLevelButton;
    public GameObject _AddGemsUI;
    public GameObject SecretAreaFoundUI;
    public Button ResumeUseGems1;
    public Button ResumeUseGems2;
    public Image BossEnergyBarImage;
    public Text LevelNameOnUI;
    public GameObject UseButton;
    public GameObject SmartKillUI;


    void Awake () {
        Instance = this;
        OpenSceneUI.SetActive(true);
        LevelCompleteMessageUI.GetComponent<CanvasGroup>().alpha = 1;
        OpenSceneUI.GetComponent<CanvasGroup>().alpha = 1;
        _MoreStarsNeeded.SetActive(false);
        EndTestingMessage.SetActive(false);
        _AddGemsUI.SetActive(false);
        SmartKillUI.SetActive(false);
        SecretAreaFoundUI.SetActive(false);
        _autoSettingUI.SetActive(false);
        if (BossEnergyBarImage) BossEnergyBarImage.transform.parent.gameObject.SetActive(false);


    }
    void Start()
    {
        SpeedItem.SetActive(false);
        JumpItem.SetActive(false);
        FireShotItem.SetActive(false);
        FireButton.SetActive(false);


    }

    public void InVisible()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        GetComponent<CanvasGroup>().interactable = false;
    }

    public void Visible()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        GetComponent<CanvasGroup>().interactable = true;
    }


    public void HideUseButton() {
         UseButton.SetActive(false);
    }

    public void ShowUseButton()
    {
        UseButton.SetActive(true);
    }


    void Update () {
       if(GameManager.m_Character)
        EnergyBarImage.fillAmount = GameManager.m_Character.PlayerEnergy;

    }
}
