using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public abstract class GameAction : MonoBehaviour
{
    [SerializeField] UnityEvent UE_EXECUTE;

    private void Awake()
    {
        this.gameObject.layer = 13;
    }

    public void Execute()
    {
        OnExecute();
        UE_EXECUTE.Invoke();
    }

    protected abstract void OnExecute();
}
