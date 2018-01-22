using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class W_Button : MonoBehaviour {

    public enum ActionOnClick
    {
        ToTheNextScene,OpenLevelsList,OpenCredits,OpenHighScore,CloseAllPanels,OpenOptions, ResetAll,OpenDialog01,NoSure, OpenDialog02, QuitGame,NoQuit,RelaodScene,PauseButton,OpenMainMenu,OpenMiniOptions, CloseMiniOptions,OpenGadgetsPanel,OpenSkinPanel,SelectSkin,ResumeGame,
        nextWordPanel,prevWordPanel,OpenGuidePanel,ResumeWithGems,nextSkinPanel, prevSkinPanel, nextLeaderBoardPanel, prevLeaderBoardPanel, nextBuyGemsPanel, prevBuyGemsPanel, OpenBuyGemsPanel,BuyGems,UnlockSkin,OpenUnlockAllLevels,UnlockAllLevels,UnlockBonusLevel
    }


    public ActionOnClick inputType = ActionOnClick.ToTheNextScene;
    public int parameter;
    public int parameter2;

    void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);


    }

   //OnClick
    void TaskOnClick()
    {
        if (inputType.Equals(ActionOnClick.ToTheNextScene))
            GameManager.GoToNextScene();
        if (inputType.Equals(ActionOnClick.OpenCredits))
            MainMenu.ShowCredits();
        else if (inputType.Equals(ActionOnClick.OpenLevelsList))
            MainMenu.ShowLevels();
        else if (inputType.Equals(ActionOnClick.OpenHighScore))
            MainMenu.ShowHigScore();
        else if (inputType.Equals(ActionOnClick.OpenOptions))
            MainMenu.ShowOptions();
        else if (inputType.Equals(ActionOnClick.OpenGadgetsPanel))
            MainMenu.ShowGadgetsPanel();
        else if (inputType.Equals(ActionOnClick.OpenSkinPanel))
            MainMenu.ShowSkinPanel();
        else if (inputType.Equals(ActionOnClick.ResetAll))
            GameManager.ResetAll();
        else if (inputType.Equals(ActionOnClick.OpenDialog01))
            MainMenu.OpenDialog01();
        else if (inputType.Equals(ActionOnClick.NoSure))
            MainMenu.NoSure();
        else if (inputType.Equals(ActionOnClick.CloseAllPanels))
            MainMenu.HideAllPanels();
        else if (inputType.Equals(ActionOnClick.OpenDialog02))
            MainMenu.OpenQuitDialog();
        else if (inputType.Equals(ActionOnClick.QuitGame))
            MainMenu.QuitGame();
        else if (inputType.Equals(ActionOnClick.NoQuit))
            MainMenu.NoQuit();
        else if (inputType.Equals(ActionOnClick.RelaodScene))
            GameManager.ReloadScene();
        else if (inputType.Equals(ActionOnClick.SelectSkin))
            GameManager.Instance.SelectSkin(parameter);
        else if (inputType.Equals(ActionOnClick.ResumeWithGems))
            W_GemManager._istance.ResumeWithGems();
        else if (inputType.Equals(ActionOnClick.OpenGuidePanel))
            MainMenu.OpenGuidePanel();
        else if (inputType.Equals(ActionOnClick.PauseButton))
        {
            //Metto in pausa solo se il palyer è a terra
            if (GameManager.Instance.GetGameState().Equals(GameManager.Game_State.Running) && GameManager.m_Character.m_IsGrounded)
                GameManager.ShowMiniMenu();
            else
                GameManager.HideMiniMenu();
        }
        else if (inputType.Equals(ActionOnClick.OpenMainMenu))
            MainMenu.BackToMainMenu();
        else if (inputType.Equals(ActionOnClick.OpenMiniOptions))
            GameManager.OpenMiniOptions();
        else if (inputType.Equals(ActionOnClick.CloseMiniOptions))
            GameManager.CloseMiniOptions();
        else if (inputType.Equals(ActionOnClick.ResumeGame))
            MainMenu.Instance.ResumeGame();
        else if (inputType.Equals(ActionOnClick.nextWordPanel))
            AllWordlPanels.nextWordPanel();
        else if (inputType.Equals(ActionOnClick.prevWordPanel))
            AllWordlPanels.prevWordPanel();
        else if (inputType.Equals(ActionOnClick.nextSkinPanel))
            W_SkinscrollablePanel.nextPanel();
        else if (inputType.Equals(ActionOnClick.prevSkinPanel))
            W_SkinscrollablePanel.prevPanel();
        else if (inputType.Equals(ActionOnClick.nextLeaderBoardPanel))
            W_LeaderBcrollablePanel.nextPanel();
        else if (inputType.Equals(ActionOnClick.prevLeaderBoardPanel))
            W_LeaderBcrollablePanel.prevPanel();
        else if (inputType.Equals(ActionOnClick.nextBuyGemsPanel))
            W_BuyGemsScrollablePanel.nextPanel();
        else if (inputType.Equals(ActionOnClick.prevBuyGemsPanel))
            W_BuyGemsScrollablePanel.prevPanel();
        else if (inputType.Equals(ActionOnClick.OpenBuyGemsPanel))
            MainMenu.OpenBuyGemsPanel();
        else if (inputType.Equals(ActionOnClick.UnlockSkin))
            W_SkinscrollablePanel.instance.BuySkin(parameter, parameter2);
        else if (inputType.Equals(ActionOnClick.BuyGems))
            MainMenu.OpenBuyGemsPanel();
        else if (inputType.Equals(ActionOnClick.OpenUnlockAllLevels))
            MainMenu.OpenUnlockAllLevels();
        else if (inputType.Equals(ActionOnClick.UnlockAllLevels))
            W_GemManager._istance.UnlockAllLevels();
        else if (inputType.Equals(ActionOnClick.UnlockBonusLevel))
            W_GemManager._istance.UnlockBonusLevel(parameter); 

    }



}
