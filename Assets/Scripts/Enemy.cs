﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{
    public float speed;
    public int negativePoints;


    public virtual void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {

            var obj = collision.gameObject.GetComponent<Player>();

            if (obj != null)
            {
                obj.Divide();
            }

            Destroy(gameObject);
        }
        
    }
}
