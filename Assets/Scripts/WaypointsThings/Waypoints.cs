using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    public int num = 0;

    public float speed;
    public int negativePoints;

    ScoreManager _ScoreManager;
    GameObject _Parent;

    public float minDist;

    public bool rand = false;
    public bool go = true;
    public bool goBack = false;

    private void Start()
    {
        _ScoreManager = FindObjectOfType<ScoreManager>();
        _Parent = this.transform.parent.gameObject;
    }


    void Update()
    {
        float dist = Vector2.Distance(gameObject.transform.position, waypoints[num].transform.position);

        if (go)
        {
            if (dist > minDist)
                Move(waypoints[num].transform.position - gameObject.transform.position);
            else if (!rand)
            {
                if (goBack == true)
                {
                    num--;
                    if (num == 0)
                        goBack = false;
                }
                else
                    num++;
                if (num == waypoints.Length)
                {
                    num--;
                    goBack = true;
                }
            }
            else
                num = Random.Range(0, waypoints.Length);
        }

    }

    void Move(Vector3 dir)
    {
            gameObject.transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Destroy(_Parent);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            //_ScoreManager.DecreasePoints(negativePoints);

            var obj = collision.gameObject.GetComponent<Player>();

            if (obj != null)
            {
                obj.Divide();
            }

            Destroy(_Parent);
        }

    }
}
