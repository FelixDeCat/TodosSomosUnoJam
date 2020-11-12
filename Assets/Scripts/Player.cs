using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float Maxlife;
    float Actuallife;
    public int type_cel = 3;


    private void Start()
    {
        Actuallife = Maxlife;
        GameManager.instance.SubscribePlayer(this);
    }

    public void Build(int type_val)
    {
        type_cel = type_val;
        float size = 0;

        if (type_val == 3)
        {
            size = GameManager.instance.data.big;
            speed = GameManager.instance.data.slow_speed;
            transform.localScale = new Vector3(size, size, size);
        }
        if (type_val == 2)
        {
            size = GameManager.instance.data.medium;
            speed = GameManager.instance.data.medium_speed;
            transform.localScale = new Vector3(size, size, size);
        }
        if (type_val == 1)
        {
            size = GameManager.instance.data.small;
            speed = GameManager.instance.data.fast_speed;
            transform.localScale = new Vector3(size, size, size);
        }
    }
    void Update()
    {
        this.transform.position += Vector3.right * speed * Time.deltaTime * Input.GetAxis("Horizontal");

    }
    public void SetMaxLife()
    {
        Maxlife--;
    }


    public void Divide()
    {
        if (type_cel > 1)
        {
            PublicEvents.instance.EVENT_OnPlayerHit();
            for (int i = 0; i < 2; i++)
            {
                var separation = GameManager.instance.data.Separation;
                var obj = GameObject.Instantiate(GameManager.GetPlayer());
                obj.transform.position = new Vector3(i == 0 ? obj.transform.position.x - separation : obj.transform.position.x + separation, obj.transform.position.y, obj.transform.position.z);
                if (type_cel == 3) obj.Build(2);
                if (type_cel == 2) obj.Build(1);
            }
        }
        GameManager.instance.UnSubscribePlayer(this);
        Destroy(this.gameObject);
    }
}
