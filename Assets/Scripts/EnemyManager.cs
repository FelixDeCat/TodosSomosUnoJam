using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class EnemyManager : LoadComponent
{
    public GameObject[] baseEnemy;
    public static EnemyManager instance;
    private void Awake() => instance = this;

    protected override IEnumerator LoadMe()
    {
        
        yield return null;
    }

    public override void OnStartGame()
    {
        
    }

    public void Spawn()
    {
        bool[] positions = GetPositions();

        for (int i = 0; i < positions.Length; i++)
        {
            if (positions[i])
            {
                GameObject spawned = Instantiate(baseEnemy[Random.Range(0, baseEnemy.Length)]);
                spawned.transform.position = new Vector3(UniversalValues.POSITIONS[i], UniversalValues.POS_TO_ENEMY_SPAWN);
            }
        }
    }


    public bool[] GetPositions()
    {
        bool[] aux = new bool[UniversalValues.COUNT_POSITIONS];

        int initialrandom = Random.Range(0,UniversalValues.COUNT_POSITIONS-1);
        int auxrandom = -1;

        if (initialrandom <= 0)
        {
            auxrandom = 1;
        }
        else
        {
            if (initialrandom >= UniversalValues.COUNT_POSITIONS - 1)
            {
                auxrandom = UniversalValues.COUNT_POSITIONS - 2;
            }
            else
            {
                auxrandom = Random.Range(0, 2) == 0 ? initialrandom - 1 : initialrandom + 1;
            }
        }

        for (int i = 0; i < aux.Length; i++)
        {
            if (i == initialrandom || i == auxrandom)
            {
                aux[i] = false;
            }
            else
            {
                aux[i] = true;
            }
        }

        return aux;
    }
}
