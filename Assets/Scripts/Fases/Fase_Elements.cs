using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase_Elements : Fase
{
    public GameObject[] ToSpawn;
    public int patronsToSpawn;
    int current = 0;
    float timer;
    int lastSpawned = -1;

    protected override void OnBegin()
    {
        current = 0;
        timer = 0;
        Spawn();
    }

    protected override void OnEnd() { current = 0; }

    protected override void OnUpdate() { }



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
        int randomNumber = Random.Range(0, ToSpawn.Length - 1);
        if (randomNumber == lastSpawned)
        {
            randomNumber = Random.Range(0, ToSpawn.Length - 1);
            GameObject go = Instantiate(ToSpawn[randomNumber]);
            //go.transform.localScale = new Vector3(Random.Range(-1,1),1);
            go.transform.position = new Vector3(0, UniversalValues.POS_TO_ENEMY_SPAWN);
            lastSpawned = randomNumber;
        }
        else
        {
            GameObject go = Instantiate(ToSpawn[randomNumber]);
            go.transform.position = new Vector3(0, UniversalValues.POS_TO_ENEMY_SPAWN);
            lastSpawned = randomNumber;
        }
    }

    public override void EndElement()
    {
        Check();
    }
}
