using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Screen;

public static class UniversalValues 
{
    public const int POS_TO_ENEMY_SPAWN = -15;

    public static int Get_Random_X_Position()
    {
        return Random.Range(-8, 8);
    }
}
