using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInfo : MonoBehaviour
{
    int points = 0;
    public Text pointsText;
    public Image timeleft;
    public GameObject endPanel;
    public Text endPanelPoints;
    public Text endPanelTitle;
    bool endGame = false;
    float time;
    float maxTime = 10f;
    void Start()
    {
        maxTime = Global.GameTime * 60f;
        time = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!endGame)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                timeleft.fillAmount = time / maxTime;
            }
            else
            {
                OpenEndPanel("Time Over");
            }
        }
    }
    public void OpenEndPanel(string t)
    {
        Time.timeScale = 0;
        endPanelTitle.text = t;
        endPanelPoints.text = pointsText.text;
        endPanel.SetActive(true);
        endGame = true;
    }
    public void addPoints()
    {
        points += 1;
        pointsText.text = points.ToString();
    }
    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
