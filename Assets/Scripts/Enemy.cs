using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int negativePoints;

    void Update()
    {
        transform.position += new Vector3(0,speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            FindObjectOfType<ScoreManager>().DecreasePoints(negativePoints);
            Destroy(gameObject);
        }
        
    }
}
