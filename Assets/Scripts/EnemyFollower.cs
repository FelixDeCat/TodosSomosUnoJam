using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : Enemy
{
    public float followSpeed;
    public float slowChaser;

    public override void Move()
    {
        base.Move();

        var t = GhostFollow.instance.GetGhostTransform();

        if (t.position.x == transform.position.x)
            return;

        else if (t.position.x > transform.position.x)
            this.transform.position += new Vector3(1,0,0) * followSpeed * slowChaser * Time.deltaTime;
        else
            this.transform.position -= new Vector3(1, 0, 0) * followSpeed * slowChaser * Time.deltaTime;
    }
}
