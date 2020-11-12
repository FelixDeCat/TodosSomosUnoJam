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
        var aux = speed / 4;

        if (type_val == 3)
        {
            aux = aux * 2;
            transform.localScale = new Vector3(GameManager.instance.big, GameManager.instance.big, GameManager.instance.big);
        }
        if (type_val == 2)
        {
            aux = aux * 1;
            transform.localScale = new Vector3(GameManager.instance.medium, GameManager.instance.medium, GameManager.instance.medium);
        }
        if (type_val == 1)
        {
            transform.localScale = new Vector3(GameManager.instance.small, GameManager.instance.small, GameManager.instance.small);
        }

        speed -= aux;

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
                var obj = GameObject.Instantiate(GameManager.GetPlayer());
                obj.transform.position = new Vector3(i == 0 ? obj.transform.position.x - 1.15f : obj.transform.position.x + 1.15f, obj.transform.position.y, obj.transform.position.z);
                if (type_cel == 3) obj.Build(2);
                if (type_cel == 2) obj.Build(1);
            }
        }
        GameManager.instance.UnSubscribePlayer(this);
        Destroy(this.gameObject);
    }
}
