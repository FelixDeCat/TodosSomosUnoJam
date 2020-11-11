using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : LoadComponent
{
    public Text scoreText = null;
    float points = 1;
    float HighScore = 0;
    bool canUpdate = false;

    protected override IEnumerator LoadMe()
    {
        yield return null;
    }

    public override void OnStartGame()
    {
        scoreText.text = "0";
        canUpdate = true;
    }


    void Update()
    {
        if (!canUpdate) return;

        points += Time.deltaTime * 10;
        if (HighScore < points) HighScore = points;
        scoreText.text = points.ToString();
    }

    public void DecreasePoints(int pointsToDecrease)
    {
        points -= pointsToDecrease;
        if (points <= 0)
        {
            points = 0;
        }
    }
}
