using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI winText;

    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    private float timer = 0;

    private bool gameActive = false;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetStageText(1);
        timerText.text = "0 : 0";
    }

    // Update is called once per frame
    void Update()
    {
        if(gameActive)
        {
            timer += Time.deltaTime;
            TimeSpan second = TimeSpan.FromSeconds(timer);

            timerText.text = second.Minutes.ToString() + " : " + second.Seconds.ToString();
        }
        
    }

    public void SetStageText(int changeStage)
    {
        stageText.text = "Stage  " + changeStage.ToString();
    }

    public bool IsGameActive()
    {
        return gameActive;
    }

    public void SetGameActive()
    {
        gameActive = false;
    }

    public void SetWin()
    {
        gameActive = false;
        winText.gameObject.SetActive(true);

        restartButton.gameObject.SetActive(true);
        //quitButton.gameObject.SetActive(true);
        
    }

    public void StartGame()
    {
        gameActive = true;
        startButton.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
