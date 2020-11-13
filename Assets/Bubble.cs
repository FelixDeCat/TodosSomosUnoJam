using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    float timer;
    public float speed_animation_begin_bubble;
    bool anim;
    public float scale;
    public float time_bubble_duration;
    float timer_duration;
    bool beginTimer;

    public void Amplify()
    {
        anim = true;
        timer = 0;
        beginTimer = true;
        timer_duration = 0;
    }

    private void Update()
    {
        if (anim)
        {
            if (timer < 1)
            {
                timer = timer + speed_animation_begin_bubble * Time.deltaTime;
                this.transform.localScale = Vector2.Lerp(Vector2.zero, new Vector2(scale,scale), timer);
            }
            else
            {
                timer = 0;
                anim = false;
            }
        }
        if (beginTimer)
        {
            if (timer_duration < time_bubble_duration)
            {
                timer_duration = timer_duration + 1 * Time.deltaTime;
            }
            else
            {
                timer_duration = 0;
                beginTimer = false;
                BlowUp();
            }
        }
    }

    void BlowUp()
    {
        this.transform.localScale = Vector2.zero;
        GameManager.instance.TurnCollisions(true);
    }
}
