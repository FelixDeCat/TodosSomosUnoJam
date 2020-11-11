using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionCatcher : TriggerReceiver2D
{
    protected override void OnExecute(Collider2D coll)
    {
        coll.GetComponent<GameAction>().Execute();
    }
}
