using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverScript : MonoBehaviour {

    private GameManagerScript gameManagerScript;
    [SerializeField]
    private CheckPointScript checkpointScript;

    public Image blackScreenImage;
    public Text gameOverText;
    public Image retryButton;
    public Text retryText;
    public Image restartButton;
    public Text restartText;
    public Image exitButton;
    public Text exitText;
    

    void Awake()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }


    /*public void RestartScene()
    {
        CharacterThirdPerson.gameHasRestarted = false;
        gameManagerScript.RestartScene();
    }


    public void RestartFromCheckpoint()
    {
        CharacterThirdPerson.gameHasRestarted = true;
        gameManagerScript.RestartFromCheckpoint();
    }*/


    public void ExitGame()
    {
        gameManagerScript.ExitGame();
    }


    public void ShowGameOverScreen()
    {
        ActivateGameOverScreen();
    }


    public void HideGameOverScreen()
    {
        DeactivateGameOverScreen();
    }


    void DeactivateGameOverScreen()
    {
        blackScreenImage.GetComponent<Image>().enabled = false;
        gameOverText.GetComponent<Text>().enabled = false;
        retryButton.GetComponent<Image>().enabled = false;
        retryText.GetComponent<Text>().enabled = false;
        restartButton.GetComponent<Image>().enabled = false;
        restartText.GetComponent<Text>().enabled = false;
        exitButton.GetComponent<Image>().enabled = false;
        exitText.GetComponent<Text>().enabled = false;
    }


    void ActivateGameOverScreen()
    {
        blackScreenImage.GetComponent<Image>().enabled = true;
        gameOverText.GetComponent<Text>().enabled = true;
        restartButton.GetComponent<Image>().enabled = true;
        restartText.GetComponent<Text>().enabled = true;
        exitButton.GetComponent<Image>().enabled = true;
        exitText.GetComponent<Text>().enabled = true;

        if (checkpointScript.checkpointPassed)
        {
            retryButton.GetComponent<Image>().enabled = true;
            retryText.GetComponent<Text>().enabled = true;
        }
    }
}
