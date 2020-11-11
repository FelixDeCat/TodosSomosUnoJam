using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseManager : LoadComponent
{
    public Fase[] fases;
    int current;

    protected override IEnumerator LoadMe()
    {
        yield return null;
    }

    public override void OnStartGame()
    {
        current = 0;
        StartFase();
    }

    void StartFase()
    {
        fases[current].BeginFase();
    }
}
