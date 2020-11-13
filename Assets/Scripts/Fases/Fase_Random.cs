using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Screen;
using Tools;

public class Fase_Random : Fase
{
    public GameObject[] ToSpawn;
    public int[] probabilities;
    Dictionary<GameObject, int> dic = new Dictionary<GameObject, int>();
    public float space_time;

    public float durationFase = 10f;
    float timer_duration;

    float timer;

    public bool proced;


    protected override void OnBegin()
    {

        for (int i = 0; i < ToSpawn.Length; i++)
        {
            if (!dic.ContainsKey(ToSpawn[i]))
            {
                dic.Add(ToSpawn[i], probabilities[i]);
            }
            
        }

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
                GameObject go = Instantiate(RoulletteWheel.Roullette(dic));
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
