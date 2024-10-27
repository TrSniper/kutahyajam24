using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UIManager : MonoSingleton<UIManager>
{
    [Header("MENU CANVASES")]
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject inGameCanvas;

    [Header("MAINMENU OBJECTS")]
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject SettingsMenu;
    [SerializeField] GameObject AboutMenu;
    [SerializeField] GameObject ExitMenu;

    [Header("INGAME OBJECTS")]
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject InGameSettingsMenu;
    [SerializeField] GameObject GameOverText;

    //Slider events
    public event Action<float> OnMasterSlider;
    public event Action<float> OnMusicSlider;
    public event Action<float> OnSFXSlider;
    public event Action<bool> OnSoundToggle;

    private GameObject[]  menus = null;

    private bool inGameMenuMode = false;
    private bool isPaused = false;

    private bool willRestart = false;

    private byte pressedInputButton = 0;

    ///TODO: Implement controller button changes.

    private void Start()
    {
        menus = new GameObject[4] { MainMenu, SettingsMenu, AboutMenu, ExitMenu};

        SceneManager.activeSceneChanged += OnLevelChanged;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            OpenPauseMenu();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            CloseInGameSettingsMenu(); //the order is important, <- this function closes settings and opens pause menu.
            ClosePauseMenu(); // this nigga works as expected
            isPaused = false;
        }
    }
    private void OnLevelChanged(Scene arg0, Scene arg1)
    {
        if (arg1.buildIndex == 1) // 1 is game scene
        {
            inGameMenuMode = true;
        }
        else inGameMenuMode = false;

        mainMenuCanvas.SetActive(!inGameMenuMode);
        inGameCanvas.SetActive(inGameMenuMode);
    }


    #region Event-based functionality
    private void OnGameOver(string winner)
    {
        StartCoroutine(nameof(GameOverRoutine), winner);
    }

    IEnumerator GameOverRoutine(string winner)
    {

        var text = GameOverText.GetComponent<TextMeshProUGUI>();
        text.text = $"Game Over. \n{winner} wins!";
        GameOverText.SetActive(true);
        yield return new WaitForSeconds(5f); //5 saniye sike sike bekliyor
        text.text = "Press any button to restart!";
        yield return new WaitUntil(() => willRestart);
        GameOverText.SetActive(false);
        willRestart = false;
    }

    #endregion

    //It certainly is possible to split these functions to classes and make it modüler but who cares

    #region MainMenu Functions 
    public void OpenMainMenu()
    {
        for (int i = 0; i < 5; i++)
        {
            menus[i].SetActive(false);
        }
        MainMenu.SetActive(true);
    }
    public void OpenSettings()
    {
        for(int i = 0;i < 5; i++)
        {
            menus[i].SetActive(false);
        }
        SettingsMenu.SetActive(true);
    }
    public void OpenAboutMenu()
    {
        for(int i = 0; i < 5; i++)
        { menus[i].SetActive(false);}
        AboutMenu.SetActive(true);
    }
    public void OpenExitMenu()
    {
        for(int i = 0; i < 5; i++)
        {
            menus[i].SetActive(false);
        }
        ExitMenu.SetActive(true);
    }

    #endregion

    #region InGame Menu Functions
    public void OpenPauseMenu()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;
        //TODO: Cancel input
        //input cancel for the game
        //input open for the ui
    }
    public void ClosePauseMenu() 
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
        //TODO: Re-enable input for the game
    }
    public void OpenInGameSettingsMenu()
    {
        PauseMenu.SetActive(false);
        InGameSettingsMenu.SetActive(true);
    }
    public void CloseInGameSettingsMenu()
    {
        InGameSettingsMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }
    public void RestartTheRound()
    {
        ClosePauseMenu();
    }
    public void ExitToMainMenu()
    {
        //TODO: Load main menu scene properly.HEHEHEHEHEHEEHHEEHHEEHHEHEHEHEE kesin öyle olur
    }
    #endregion

    #region Shared Functions

    public void MasterSliderFunction(float value)
    {
        OnMasterSlider?.Invoke(value);
        Debug.Log(value);
    }
    public void MusicSliderFunction(float value)
    {
        OnMusicSlider?.Invoke(value);
    }
    public void SFXSliderFunction(float value)
    {
        OnSFXSlider?.Invoke(value);
    }
    public void ToggleSoundButton(bool b)
    {
        OnSoundToggle?.Invoke(b);
    }
    #endregion
}
