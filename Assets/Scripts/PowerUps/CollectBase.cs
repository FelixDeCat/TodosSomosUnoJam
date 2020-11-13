using UnityEngine;
using UnityEngine.Events;
using Tools.EventClasses;

public class CollectBase : MonoBehaviour
{
    public UnityEvent OnExecute;
    public EventPlayer OnExecuteEventPlayer;
    public float speed = 10;
    public virtual void Update() => Move();
    public virtual void Move() => transform.position += new Vector3(0, speed * Time.deltaTime);

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9) Destroy(gameObject);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            OnExecute.Invoke();
            OnExecuteEventPlayer.Invoke(collision.transform.gameObject.GetComponent<Player>());
            Destroy(gameObject);
        }
    }

}
