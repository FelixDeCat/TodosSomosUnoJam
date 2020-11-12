using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Screen;

public static class UniversalValues 
{
    public const int POS_TO_ENEMY_SPAWN = -15;

    public static readonly float[] POSITIONS = { -7.5f, -5f, -2.5f, 0, 2.5f, 5f, 7.5f };
    public const int COUNT_POSITIONS = 7;

    public static readonly bool[,] PSEUDO_RANDOM_MATRIX = { { true, false, false, false, false, false, false, false } };

    public static float Get_Random_X_Position()
    {
        return POSITIONS[Random.Range(0, COUNT_POSITIONS-1)];
    }
}
