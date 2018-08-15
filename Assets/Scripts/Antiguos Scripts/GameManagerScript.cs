using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    private static GameManagerScript _instance = null;

    private GameOverScript gameOverScript;
    private GameObject playerGameObject;
    private CheckPointScript checkpointScript;

    private Vector3 spawnPosition;

    void Awake()
    {
        Time.timeScale = 1;

        if (_instance == null)
        {
            _instance = new GameManagerScript();
        }

        GameObject[] gameManagers = GameObject.FindGameObjectsWithTag("GameManager");

        if (gameManagers.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        spawnPosition = new Vector3(27f, -0.88f, 28.5f);

        gameOverScript = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GameOverScript>();
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        checkpointScript = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<CheckPointScript>();

        if (gameOverScript != null)
        {
            gameOverScript.HideGameOverScreen();
        }

        if (checkpointScript.checkpointPassed)
        {
            spawnPosition = checkpointScript.initialSpawnPosition;
        }

        /*if (!CharacterThirdPerson.gameHasRestarted)
        {
            playerGameObject.transform.position = spawnPosition;
        }*/
    }

	void Start ()
    {   
    }

	void Update ()
    {
        /*if (HealthScript.playerIsDead)
        {
            gameOverScript.ShowGameOverScreen();
        }*/
        gameOverScript = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GameOverScript>();
    }

    public void RestartScene()
    {
        gameOverScript.HideGameOverScreen();
        SceneManager.LoadScene(0);
    }

    public void RestartFromCheckpoint()
    {
        gameOverScript.HideGameOverScreen();
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
