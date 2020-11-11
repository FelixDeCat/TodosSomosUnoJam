using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionMovable : GameAction
{
    public float speed = 10;

    protected override void OnExecute()
    {
        
    }

    public virtual void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime);
    }

    public virtual void Move()
    {
        
    }
}
