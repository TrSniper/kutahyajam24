using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    /// <summary>
    /// This class exists to handle all button behaviour in the game. Names are final, don't change or it breaks
    /// </summary>
   #region MainMenu Buttons 
    public void LoadGameMain()
    {
        SceneManager.LoadScene(1);
        UIManager.Instance.CloseCharacterSelectMenu();
        Debug.Log("Load The Game");
    }
    public void LoadSettings()
    {
        Debug.Log("Load Settings");
        UIManager.Instance.OpenSettings();
    }
    public void LoadAbout()
    {
        Debug.Log("Load About");
        UIManager.Instance.OpenAboutMenu();
    }
    public void LoadExitMenu()
    {
        Debug.Log("Open Exit Menu");
        UIManager.Instance.OpenExitMenu();
    }
    public void LoadCharacterSelect()
    {
        Debug.Log("Open Character Select");
        UIManager.Instance.OpenCharacterSelectMenu();
    }
    public void OpenMainMenuBack()
    {
        Debug.Log("Back");
        UIManager.Instance.OpenMainMenu();
    }
    public void ExitTheGame()
    {
        Application.Quit();
        Debug.Log("Exit the game");
    }
    #endregion

   #region InGameMenu Buttons


    public void LoadPauseMenu()
    {
        UIManager.Instance.OpenPauseMenu();
        Debug.Log("Load Pause Menu");
    }
    public void ClosePauseMenu()
    {
        UIManager.Instance.ClosePauseMenu();
        Debug.Log("Close Pause Menu");
    }

    public void LoadInGameSettingsMenu()
    {
        UIManager.Instance.OpenInGameSettingsMenu();
        Debug.Log("Load InGame Settings Menu");
    } 
    public void CloseInGameSettingsMenu()
    {
        UIManager.Instance.CloseInGameSettingsMenu();
        Debug.Log("Close In-Game Settings");
    }

    public void RestartButton()
    {
        UIManager.Instance.RestartTheRound();
        Debug.Log("Restart");
    }

    public void ExitToMenuButton()
    {
        UIManager.Instance.ExitToMainMenu();
        Debug.Log("Exit To Menu");
    }
   #endregion
}
