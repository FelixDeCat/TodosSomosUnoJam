using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadHandler : MonoBehaviour
{
    Action OnEnd = delegate { };
    LoadComponent[] components;
    public void BeginLoad(Action _OnEnd)
    {
        OnEnd = _OnEnd;
        components = FindObjectsOfType<LoadComponent>();
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        for (int i = 0; i < components.Length; i++)
        {
            components[i].Load();
            yield return null;
        }

        for (int i = 0; i < components.Length; i++)
        {
            components[i].OnStartGame();
        }

    }
}
