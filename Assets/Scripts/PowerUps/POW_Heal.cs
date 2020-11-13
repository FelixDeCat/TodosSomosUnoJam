using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POW_Heal : MonoBehaviour
{
    public void Execute()
    {

    }


    public void ExecutePlayer(Player player)
    {
        player.Heal();
    }
}
