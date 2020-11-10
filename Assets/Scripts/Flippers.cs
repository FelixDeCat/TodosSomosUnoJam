using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flippers : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime);
    }
}
