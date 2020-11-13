using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    [Header("Speeds")]
    public float fast_speed = 13;
    public float medium_speed = 9;
    public float slow_speed = 7;

    [Header("Size")]
    public float big;
    public float medium;
    public float small;

    [Header("Spawn data")]
    public float Separation = 1.15f;

    public void Initialize()
    {
        big = GameManager.GetPlayer().transform.localScale.x;
        medium = GameManager.GetPlayer().transform.localScale.x * 0.5f;
        small = GameManager.GetPlayer().transform.localScale.x * 0.25f;
        GameManager.GetPlayer().Build(3, transform.position);
    }
}
