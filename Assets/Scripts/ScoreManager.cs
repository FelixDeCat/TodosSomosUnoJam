using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : LoadComponent
{
    public Text scoreText = null;
    public Text highScoreText = null;
    public Text highScoreEndText = null;
    public GameObject canvasEndGame;
    float points = 1;
    float HighScore = 0;
    bool canUpdate = false;
    float timerDead;

    protected override IEnumerator LoadMe()
    {
        yield return null;
    }

    public override void OnStartGame()
    {
        Time.timeScale = 1;
        canvasEndGame.SetActive(false);
        scoreText.text = "Score:" + " ";
        highScoreText.text = "HighScore:" + " ";
        highScoreEndText.text = "HighScore:" + " ";
        canUpdate = true;
    }
    

    void Update()
    {
        if (!canUpdate) return;

        points += Time.deltaTime * 10;
        if (HighScore < points)
        {
            HighScore = points;
            highScoreText.text = "HighScore: " + " " + HighScore.ToString("N0");
            highScoreEndText.text = HighScore.ToString("N0");
        }
        scoreText.text = "Score: " + " " + points.ToString("N0");

    }

    /*public void DecreasePoints(int pointsToDecrease)
    {
        points -= pointsToDecrease;
        if (points <= 0)
        {
            points = 0;
        }
    }*/

    public void EndGame()
    {
        StartCoroutine(checkerPlayer());
    }

    IEnumerator checkerPlayer()
    {
        yield return new WaitForSeconds(1);
        if (!FindObjectOfType<Player>())
        {
            canvasEndGame.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
