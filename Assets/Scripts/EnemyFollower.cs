using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : Enemy
{
    public float followSpeed;
    public float slowChaser;


    Player _player;


    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    public override void Move()
    {
        base.Move();

        if (_player.transform.position.x == transform.position.x)
            return;

        else if (_player.transform.position.x > transform.position.x)
            this.transform.position += new Vector3(1,0,0) * followSpeed * slowChaser * Time.deltaTime;
        else
            this.transform.position -= new Vector3(1, 0, 0) * followSpeed * slowChaser * Time.deltaTime;
    }
}
