using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flippers : EnemyBase
{
    public float speed;

    public bool right;

    void Update()
    {
        Move();
    }

    public void Move()
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
            //_ScoreManager.DecreasePoints(negativePoints);

            var obj = collision.gameObject.GetComponent<Player>();

            if (obj != null)
            {
                GameManager.instance.PushAllPlayers(right,20);
            }

            //Destroy(gameObject);
        }

    }
}
