using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Public Variables
    [Header("\t--Public Variables--")]
    public bool checkpointPassed = false;
    [Header("Time Variables")]
    public Text timeText;

    [Header("Menu Variables")]
    public GameObject pausePanel;
    public GameObject buttonsPanel;
    public GameObject restartConfirmationPanel;
    public GameObject settingsPanel;
    public GameObject menuConfirmationPanel;
    public GameObject quitConfirmationPanel;
    public bool confirmationPanelOpen = false;
    public bool finalPanelActive = false;

    [Header("Victory Panel Variables")]
    public GameObject victoryPanel;

    [Header("Defeat Panel Variables")]
    public GameObject defeatPanel;
    #endregion

    //Time Variables
    private int hours;
    private int minutes;
    private int seconds;

    //Game Variables
    private static GameManager _instance;
    private int gameTime;
    private bool gameFinished = false;
    private bool isPlaying = false;
    private bool playerIsDead = false;
    private bool isGamePaused = false;
    private Vector3 spawnPosition;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);

        gameFinished = false;
        isPlaying = true;
        isGamePaused = false;
        playerIsDead = false;
        finalPanelActive = false;
    }

    void Start()
    {
    }

    void Update()
    {
        LockCursor();
        if (!gameFinished)
        {
            isPlaying = true;
            
        }

        if (isPlaying)
        {
            if (isGamePaused)
            {
                PauseActions();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && !finalPanelActive && !isGamePaused)
            {
                PauseGame();
            } else
            {
                DisplayTime();
            }
            
            if (Input.GetKeyDown(KeyCode.CapsLock))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; //si le damos al botón de Quit en Unity, parará de jugar
#endif
            }
        }
    }


    public bool CheckIfPlayerIsDead()
    {
        return playerIsDead;
    }

    void DisplayTime()
    {
        gameTime = (int)Time.deltaTime;
        hours = ((int)Time.timeSinceLevelLoad - gameTime) / 3600;
        minutes = Mathf.Abs(((int)Time.timeSinceLevelLoad - gameTime) / 60);
        seconds = ((int)Time.timeSinceLevelLoad - gameTime) % 60;

        timeText.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    void LockCursor()
    {
        if (!isGamePaused && !finalPanelActive && !gameFinished)
        {
            Debug.Log("HELLO");
            Cursor.lockState = CursorLockMode.Locked;

            if (Input.GetAxis("Cancel") > 0)
                Cursor.lockState = CursorLockMode.None;

            if (Input.GetMouseButtonDown(0))
                Cursor.lockState = CursorLockMode.Locked;

            Cursor.visible = false;
        }
        else
        {
            Debug.Log("SHOW YOURSELF");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    #region Pause Methods
    public void PauseActions()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !confirmationPanelOpen && isGamePaused)
        {
            Resume();
        }

        if (confirmationPanelOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (restartConfirmationPanel.gameObject.activeSelf)
                    HideRestartConfirmationPanel();

                /*if (settingsPanel.gameObject.activeSelf)
                    HideSettingsPanel();*/

                if (menuConfirmationPanel.gameObject.activeSelf)
                    HideMenuConfirmationPanel();

                if (quitConfirmationPanel.gameObject.activeSelf)
                    HideQuitConfirmationPanel();
            }
        }
    }

    public void PauseGame()
    {
        if (!confirmationPanelOpen)
        {
            pausePanel.SetActive(true);
            buttonsPanel.SetActive(true);
            Time.timeScale = 0;
            isGamePaused = !isGamePaused;
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    #region Restart Button
    public void RestartScene()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        SceneManagerScript.Instance.RestartScene();
    }

    public void ShowRestartConfirmationPanel()
    {
        confirmationPanelOpen = true;
        restartConfirmationPanel.SetActive(true);
        buttonsPanel.SetActive(false);
    }

    public void HideRestartConfirmationPanel()
    {
        confirmationPanelOpen = false;
        restartConfirmationPanel.SetActive(false);
        buttonsPanel.SetActive(true);
    }
    #endregion

    #region Menu Button
    public void LoadMenu()
    {
        isGamePaused = false;
        SceneManagerScript.Instance.GoBackToMenu();
    }

    public void ShowMenuConfirmationPanel()
    {
        confirmationPanelOpen = true;
        menuConfirmationPanel.SetActive(true);
        buttonsPanel.SetActive(false);
    }

    public void HideMenuConfirmationPanel()
    {
        confirmationPanelOpen = false;
        menuConfirmationPanel.SetActive(false);
        buttonsPanel.SetActive(true);
    }
    #endregion

    #region Settings Button
    /*public void ShowSettingsPanel()
    {
        StartCoroutine(HighlightButton(controllerToggle));
        confirmationPanelOpen = true;
        settingsPanel.SetActive(true);
        pauseMenuGO.SetActive(false);
    }

    public void HideSettingsPanel()
    {
        StartCoroutine(HighlightButton(settingsButton));
        confirmationPanelOpen = false;
        settingsPanel.SetActive(false);
        pauseMenuGO.SetActive(true);
    }

    public void SetControllerToggle()
    {
        controllerToggleIsChecked = !controllerToggleIsChecked;

        if (controllerToggleIsChecked)
        {
            InputsManager.Instance.isControllerPlaying = true; //InputsManager.isControllerPlaying = true;
        }
        else
        {
            InputsManager.Instance.isControllerPlaying = false; //InputsManager.isControllerPlaying = false;
        }
    }*/
    #endregion

    #region Quit Button
    public void QuitGame()
    {
        SceneManagerScript.Instance.QuitGame();
    }

    public void ShowQuitConfirmationPanel()
    {
        confirmationPanelOpen = true;
        quitConfirmationPanel.SetActive(true);
        buttonsPanel.SetActive(false);
    }

    public void HideQuitConfirmationPanel()
    {
        confirmationPanelOpen = false;
        quitConfirmationPanel.SetActive(false);
        buttonsPanel.SetActive(true);
    }
    #endregion

    #endregion

    #region Game States
    public void SetLastCheckpointPosition(Vector3 currentSpawnPosition)
    {
        checkpointPassed = true;
        spawnPosition = currentSpawnPosition;
    }

    public Vector3 GetSpawnPosition()
    {
        return spawnPosition;
    }

    public void ShowVictoryScreen()
    {
        playerIsDead = false;
        gameFinished = true;
        isPlaying = false;
        victoryPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowDefeatScreen()
    {
        playerIsDead = true;
        gameFinished = true;
        isPlaying = false;
        defeatPanel.SetActive(true);
        Time.timeScale = 0;
    }
    #endregion
}
