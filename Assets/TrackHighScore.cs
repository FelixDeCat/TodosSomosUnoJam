using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class TrackHighScore : MonoBehaviour
{
   const string EVENT_HIGH_SCORE = "High Score";

    public void SendHighScore(float highScore)
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        data.Add("high_score", highScore);
        AnalyticsResult result = Analytics.CustomEvent(EVENT_HIGH_SCORE, data);
        Debug.Log(result);
    }

    public void CaptureEvent()
    {
        
    }

    //This will only be useful if you have a small number of levels
    public void SendHighScorePerLevel(float highScore, int level)
    {
        // Create dictionary to store you event data
        Dictionary<string, object> data = new Dictionary<string, object>();

        //Add the high score to your event data
        data.Add("high_score", highScore);

        // The name of the event that you will send
        string eventName = "Level - " + level;

        //Send the event. Also get the result, so we can make sure it sent correctly
        AnalyticsResult result = Analytics.CustomEvent(eventName, data);
        //Debug.Log(result);
    }
}