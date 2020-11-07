using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject baseEnemy;

    public float timerSpawnEnemy;
    float timer;

    bool canSpawnBase;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawnBase) SpawnBaseEnemy();

        timer += Time.deltaTime;
        if (timer >= timerSpawnEnemy)
        {
            canSpawnBase = true;
        }

    }

    public void SpawnBaseEnemy()
    {
        GameObject spawned = Instantiate(baseEnemy);
        spawned.transform.position = new Vector3(Random.Range(-21, 21), -15);

        GameObject spawned2 = Instantiate(baseEnemy);
        spawned2.transform.position = new Vector3(Random.Range(-21, 21), -15);

        GameObject spawned3 = Instantiate(baseEnemy);
        spawned3.transform.position = new Vector3(Random.Range(-21, 21), -15);
        canSpawnBase = false;
        timer = 0;
    }

}
