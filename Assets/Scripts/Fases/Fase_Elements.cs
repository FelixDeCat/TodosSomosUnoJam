using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase_Elements : Fase
{
    public GameObject[] ToSpawn;
    int current = 0;

    protected override void OnBegin()
    {
        current = 0;
        Spawn();
    }

    protected override void OnEnd() { current = 0; }
    protected override void OnUpdate() { }

    void Check()
    {
        current++;
        if (current >= ToSpawn.Length)
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
        GameObject go = Instantiate(ToSpawn[current]);
        go.transform.position = new Vector3(0, UniversalValues.POS_TO_ENEMY_SPAWN);
    }

    public override void EndElement()
    {
        Check();
    }
}
