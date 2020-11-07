using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float Maxlife;
    float Actuallife;
    public Transform subOne;
    public Transform subTwo;


    private void Start()
    {
        Actuallife = Maxlife;
    }

    void Update()
    {
        this.transform.position += Vector3.right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
    }

    public void SetMaxLife()
    {
        Maxlife--;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.GetComponent<Enemy>())
        {
            Instantiate(this,);
        }*/
    }
}
