using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject baseEnemy;

    public float timerSpawnEnemy;
    float timer;

    bool canSpawnBase;
    bool spawned3Last;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
        spawned.transform.position = new Vector3(Random.Range(-8, 8), -15);

        GameObject spawned2 = Instantiate(baseEnemy);
        spawned2.transform.position = new Vector3(Random.Range(-8, 8), -15);

        canSpawnBase = false;
        spawned3Last = false;
        timer = 0;
    }

    public void SpawnBaseEnemy3()
    {
        GameObject spawned = Instantiate(baseEnemy);
        spawned.transform.position = new Vector3(Random.Range(-8, 8), -15);

        GameObject spawned2 = Instantiate(baseEnemy);
        spawned2.transform.position = new Vector3(Random.Range(-8,8), -15);

        GameObject spawned3 = Instantiate(baseEnemy);
        spawned3.transform.position = new Vector3(Random.Range(-8, 8), -15);
        canSpawnBase = false;
        spawned3Last = true;
        timer = 0;
    }

}
