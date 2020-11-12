using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase_Elements : Fase
{
    public GameObject[] ToSpawn;
    public int patronsToSpawn;
    int current = 0;
    float timer;

    protected override void OnBegin()
    {
        current = 0;
        timer = 0;
        Spawn();
    }

    protected override void OnEnd() { current = 0; }

    protected override void OnUpdate(){    }



    void Check()
    {
        current++;
        if (current >= patronsToSpawn)
        {
            FaseManager.instance.EndFase();
        }
        else
        {
            Spawn();
        }
    }
    void Spawn()
    {
        GameObject go = Instantiate(ToSpawn[Random.Range(0, ToSpawn.Length - 1)]);
        go.transform.position = new Vector3(0, UniversalValues.POS_TO_ENEMY_SPAWN);
    }

    public override void EndElement()
    {
        Check();
    }
}
