using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : LoadComponent
{
    public GameObject baseEnemy;

    public float timerSpawnEnemy;
    float timer;

    bool canSpawnBase;
    bool spawned3Last;

    bool canupdate = false;


    protected override IEnumerator LoadMe()
    {
        timer = 0;
        yield return null;
    }

    public override void OnStartGame()
    {
        canupdate = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (!canupdate) return;

        if (canSpawnBase && !spawned3Last) SpawnBaseEnemy3();
        else if (canSpawnBase && spawned3Last) SpawnBaseEnemy2();

        timer += Time.deltaTime;
        if (timer >= timerSpawnEnemy)
        {
            canSpawnBase = true;
        }

    }

    public void SpawnBaseEnemy2()
    {
        GameObject spawned = Instantiate(baseEnemy);
        spawned.transform.position = new Vector3(UniversalValues.Get_Random_X_Position(), UniversalValues.POS_TO_ENEMY_SPAWN);

        GameObject spawned2 = Instantiate(baseEnemy);
        spawned2.transform.position = new Vector3(UniversalValues.Get_Random_X_Position(), UniversalValues.POS_TO_ENEMY_SPAWN);

        canSpawnBase = false;
        spawned3Last = false;
        timer = 0;
    }

    public void SpawnBaseEnemy3()
    {
        GameObject spawned = Instantiate(baseEnemy);
        spawned.transform.position = new Vector3(UniversalValues.Get_Random_X_Position(), UniversalValues.POS_TO_ENEMY_SPAWN);

        GameObject spawned2 = Instantiate(baseEnemy);
        spawned2.transform.position = new Vector3(UniversalValues.Get_Random_X_Position(), UniversalValues.POS_TO_ENEMY_SPAWN);

        GameObject spawned3 = Instantiate(baseEnemy);
        spawned3.transform.position = new Vector3(UniversalValues.Get_Random_X_Position(), UniversalValues.POS_TO_ENEMY_SPAWN);
        canSpawnBase = false;
        spawned3Last = true;
        timer = 0;
    }

    
}
