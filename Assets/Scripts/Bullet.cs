using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Enemy
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

       if (collision.gameObject.layer == 9 || collision.gameObject.layer == 10)
      {
           GameObject.Destroy(gameObject);
        }
    }

    //public override void OnCollisionEnter2D(Collision2D collision)
    //{
    //    base.OnCollisionEnter2D(collision);

    //    GameObject.Destroy(gameObject);
    //}
}
