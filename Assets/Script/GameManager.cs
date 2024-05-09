using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public GameObject player;
    public GameObject GameOver_Panel;
    public GameObject Timer_Panel;
    public GameObject Pouse_Pause;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText_GO;
    public TextMeshProUGUI high_Score_GO;
    public TextMeshProUGUI timerText;
    public int score = 0;
    public int High_Score = 0;
    public float countdownTime;
    public UnityEngine.UI.Toggle Pouse_Play;
    public UnityEngine.UI.Image panelImage;

    private void Awake()
    {
        GM = this;
        High_Score = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(StartCountdown());
        Pouse_Play.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private IEnumerator StartCountdown()
    {
        float currentTime = countdownTime;
        while (currentTime > 0)
        {
            if (currentTime != 1)
            {
                timerText.text = (currentTime - 1).ToString();
                FindObjectOfType<AudioManager>().Play_Sound("Timer_Beep");
            }
            else
            {
                timerText.text = "GO.!";
                FindObjectOfType<AudioManager>().Play_Sound("Timer_Beep3");
            }

            yield return new WaitForSecondsRealtime(1f);
            currentTime--;
        }
        countdownTime = 4;
        Timer_Panel.SetActive(false);
        player.SetActive(true);
    }

    public void Score(int s)
    {
        score += s;
        scoreText.text = score.ToString();
    }

    public void Game_Over()
    {
        Pouse_Pause.SetActive(false);
        GameOver_Panel.SetActive(true);
        scoreText_GO.text = "Score: " + score.ToString();
        if (score > High_Score)
        {
            High_Score = score;
            PlayerPrefs.SetInt("HighScore", High_Score);
        }
        high_Score_GO.text = "High Score: " + High_Score.ToString();
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void Home()
    {
        SceneManager.LoadScene("StartScene");
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            player.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            Color newColor = panelImage.color;
            newColor.a = 0f;  // Alpha is set to 1 (equivalent to 255 in non-normalized values)
            panelImage.color = newColor;
            Timer_Panel.SetActive(true);
            StartCoroutine(StartCountdown());
            Invoke("ExecuteAfterWait", 3.0f);
        }
    }

    private void ExecuteAfterWait()
    {
        Timer_Panel.SetActive(false);
        player.SetActive(true);
    }
}