using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase_Elements : Fase
{
    public GameObject[] ToSpawn;
    public float timeToSpawn;
    public int patronsToSpawn;
    int current = 0;
    float timer;
    bool canSpawn = true;

    protected override void OnBegin()
    {
        current = 0;
        timer = 0;
        Spawn();
    }

    protected override void OnEnd() { current = 0; }

    protected override void OnUpdate()
    {
        timer += Time.deltaTime;

        if (timer <= timeToSpawn && canSpawn)
        {
            Spawn();
        }
    }



    void Check()
    {
        current++;
        if (current >= patronsToSpawn)
        {
            FaseManager.instance.EndFase();
        }
        /*else
        {
            Spawn();
        }*/
    }
    void Spawn()
    {
        canSpawn = false;
        GameObject go = Instantiate(ToSpawn[Random.Range(0, ToSpawn.Length - 1)]);
        go.transform.position = new Vector3(0, UniversalValues.POS_TO_ENEMY_SPAWN);
    }

    public override void EndElement()
    {
        Check();
        timer = 0;
        canSpawn = true;
    }
}
