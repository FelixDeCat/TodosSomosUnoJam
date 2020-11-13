using System;
using UnityEngine;
public class HighScore : MonoBehaviour
{
    public static HighScore instance;
    int MaxHighScore;
    private void Awake()
    {
        if (instance == null) { instance = this; DontDestroyOnLoad(this.gameObject); }
        else { Destroy(this.gameObject); }
    }
    public Tuple<bool, int> SubscribeHigScore(int higscore) 
    {
        if (higscore > MaxHighScore)
        {
            MaxHighScore = higscore;
            return Tuple.Create(true, higscore);
        }
        else
        {
            return Tuple.Create(false, MaxHighScore);
        }
    }

    public int GetMaxHigsCore()
    {
        return MaxHighScore;
    }
}