using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Tools.EventClasses;
using System;

public class TriggerDispatcher2D : MonoBehaviour
{
    [SerializeField] UnityEvent OnTriggerEnterEvent = null;
    [SerializeField] UnityEvent OnTriggerExitEvent = null;
    [SerializeField] UnityEvent OnTriggerLateEnterEvent = null;

    public bool ByLayer;
    public LayerMask layers;

    public void SubscribeToEnter(UnityAction callback)
    {
        OnTriggerEnterEvent.AddListener(callback);
    }

    [SerializeField] TriggerReceiver2D[] receivers = new TriggerReceiver2D[0];

    [SerializeField] Entities entitiesThatCanTrigger = Entities.all;

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (ByLayer) if (collision.gameObject.layer != layers) return;
        StartCoroutine(LateEnter(collision));
        OnExecute(OnTriggerEnterEvent, collision);
    }

    IEnumerator LateEnter(Collider2D other)
    {
        yield return new WaitForEndOfFrame();
        OnExecute(OnTriggerLateEnterEvent, other);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnExecute(OnTriggerExitEvent, collision);
    }

    void OnExecute(UnityEvent eventToInvoke, Collider2D other)
    {
        if (CheckCollision(other))
        {

            eventToInvoke.Invoke();

            foreach (var r in receivers)
            {
                r.Execute(other);
            }
        }               
    }

    public bool CheckCollision(Collider2D other)
    {
        if (other == null) return false;
        switch (entitiesThatCanTrigger)
        {
            case Entities.all:
                return true;
            case Entities.player:
                return other.GetComponent<Player>();                
            case Entities.enemy:
                return other.GetComponent<EnemyBase>();
            case Entities.special:
                return true;
            case Entities.game_action:
                return other.GetComponent<GameActionMovable>();
        }
        return false;
    }
}
