using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject confetti1;
    [SerializeField] private GameObject confetti2;
    [SerializeField] private GameObject confetti3;

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gamePanel; //canvas
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject successPanel;

    [SerializeField] private Text remainingText;
    [SerializeField] private Text countdownText;
    [SerializeField] private Text startingLevelText;
    [SerializeField] private Text levelFailedText;
    [SerializeField] private Text levelSuccessfulText;

    [SerializeField] private GameObject tutorialHand;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        startingLevelText.text = "Level " + LevelManager.instance.levelIndex;
        levelFailedText.text = "Level " + LevelManager.instance.levelIndex + " Failed";
        levelSuccessfulText.text = "Level " + (LevelManager.instance.levelIndex).ToString() + " Successful";
    }

    public void GameStart()
    {
        GameManager.instance.ChangeGameState(GameState.InGame);
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Success();
        }
    }
#endif
    public void GameOver()
    {
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void Success()
    {
        StartCoroutine(EndingCoroutine());
    }

    private IEnumerator EndingCoroutine()
    {
        countdownText.gameObject.SetActive(false);
        confetti1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        confetti2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        confetti3.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        gamePanel.SetActive(false);
        successPanel.SetActive(true);
        LevelManager.instance.UpdateLevelIndex();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        /*
       var bIndex = SceneManager.GetActiveScene().buildIndex;

       bIndex++;
       if (bIndex > 1)
       {
           bIndex = 0;
       }
       SceneManager.LoadScene(bIndex);
       */
    }

    public void SetRemainingText(int current, int total)
    {
        remainingText.text = current + "/" + total;
    }

    public void OpenCountdownText()
    {
        countdownText.gameObject.SetActive(true);
    }

    public void OnLevelStateChange(int state)
    {
        GameState gameState = (GameState)state;
        if (gameState == GameState.GameOver)
        {
            GameOver();
        }
        else if (gameState == GameState.GameSuccessful)
        {
            Success();
        }
    }
}
