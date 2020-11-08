using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    float points = 1;
    float HighScore;


    void Start()
    {
        scoreText.text = "0";
    }


    void Update()
    {
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
            //Time.timeScale = 0;
        }
    }
}
