using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimInvulnerabilty : MonoBehaviour
{
    float timer = 0;
    public float pulseSpeed = 1;
    bool anim = false;
    bool go = false;

    public SpriteRenderer sprender;

    Color transparent = new Color(1, 1, 1, 0.5f);
    Color white = new Color(1, 1, 1, 1);

    public void Anim() { timer = 0; anim = true; go = true; }
    public void StopAnim() { timer = 0; anim = false; go = true; sprender.color = Color.white; }

    private void Update()
    {
        if (anim)
        {
            if (timer < 1)
            {
                timer = timer + pulseSpeed * Time.deltaTime;
                sprender.color = Color.Lerp(go ? white : transparent, go ? transparent : white, timer);
            }
            else
            {
                go = !go;
                timer = 0;
            }
        }
    }
}
