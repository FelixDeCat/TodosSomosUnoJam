using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : LoadComponent
{
    public TextMeshProUGUI scoreText = null;
    public TextMeshProUGUI highScoreText = null;
    public TextMeshProUGUI highScoreGlobal = null;
    public TextMeshProUGUI highScoreCurrent = null;
    public GameObject canvasEndGame;
    float points = 1;
    float _HighScore = 0;
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
        highScoreGlobal.text = "HighScore:" + " ";
        canUpdate = true;
    }
    

    void Update()
    {
        if (!canUpdate) return;

        points += Time.deltaTime * 10;
        if (_HighScore < points)
        {
            _HighScore = points;
            highScoreText.text = "HighScore: " + " " + _HighScore.ToString("N0");
            highScoreGlobal.text = _HighScore.ToString("N0");
        }
        scoreText.text = "Score: " + " " + points.ToString("N0");

    }


    public void ResetGame()
    {
        canUpdate = true;
    }


    IEnumerator checkerPlayer()
    {
        yield return new WaitForSeconds(1);
        if (!FindObjectOfType<Player>())
        {
            Time.timeScale = 0;
            Finish();
        }
    }

    public void EndGame()
    {
        StartCoroutine(checkerPlayer());
    }


    public void Finish()
    {
        canvasEndGame.SetActive(true);

        var catch_reg = HighScore.instance.SubscribeHigScore((int)points);

        if (catch_reg.Item1)
        {
            //felicitaciones bbla bla bla
            highScoreGlobal.text = HighScore.instance.GetMaxHigsCore().ToString("N0");
            highScoreCurrent.text = points.ToString("N0");
        }
        else
        {
            highScoreGlobal.text = HighScore.instance.GetMaxHigsCore().ToString("N0");
            highScoreCurrent.text = points.ToString("N0");
        }

        canUpdate = false;
    }
}
