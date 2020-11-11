using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Fase : MonoBehaviour
{
    Action callbackEnd = delegate { };
    public void Configure(Action OnEndCallback)
    {
        callbackEnd = OnEndCallback;
    }

    bool canUpdate = false;
    public void BeginFase()
    {
        canUpdate = true;
        OnBegin();
    }
    public void EndFase()
    {
        canUpdate = false;
        OnEnd();
        callbackEnd.Invoke();
    }
    void Update()
    {
        if (canUpdate) OnUpdate();
    }

    protected abstract void OnBegin();
    protected abstract void OnEnd();
    protected abstract void OnUpdate();
}
