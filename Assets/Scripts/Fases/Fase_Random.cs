using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Screen;

public class Fase_Random : Fase
{
    public GameObject[] ToSpawn;
    public float space_time;

    public float durationFase = 10f;
    float timer_duration;

    float timer;

    public bool proced;


    protected override void OnBegin()
    {
        timer = 0;
        Debug.Log("Fase iniciada");
    }

    protected override void OnEnd()
    {
        timer = 0;
    }

    protected override void OnUpdate()
    {
        if (timer < space_time)
        {
            timer = timer + 1 * Time.deltaTime;
        }
        else
        {
            if (proced)
            {
                EnemyManager.instance.Spawn();
            }
            else
            {
                int index = Random.Range(0, ToSpawn.Length);
                GameObject go = Instantiate(ToSpawn[index]);
                go.transform.position = new Vector3(UniversalValues.Get_Random_X_Position(), UniversalValues.POS_TO_ENEMY_SPAWN);
            }
            timer = 0;
        }

        if (timer_duration < durationFase)
        {
            timer_duration = timer_duration + 1 * Time.deltaTime;
        }
        else
        {
            timer_duration = 0;
            FaseManager.instance.EndFase();
        }
    }
}
