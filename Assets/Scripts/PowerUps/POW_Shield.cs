using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POW_Shield : MonoBehaviour
{
    public void Execute()
    {
        GameManager.instance.TurnCollisions(false);
        GameManager.instance.TurnOnBubble();
    }
}
