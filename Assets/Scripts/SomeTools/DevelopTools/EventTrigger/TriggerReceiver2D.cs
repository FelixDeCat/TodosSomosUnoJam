using UnityEngine;
public abstract class TriggerReceiver2D : MonoBehaviour
{
    [SerializeField] protected bool has_one_Shot = false;
    bool oneshot;

    public void Execute(Collider2D coll)
    {
        //Debug.Log("ENTRO AL EXECUTE");

        if (has_one_Shot)
        {
            if (!oneshot)
            {
                oneshot = true;
                OnExecute(coll);
            }
        }
        else
        {
            OnExecute(coll);
        }
    }

    protected abstract void OnExecute(Collider2D coll);
}
