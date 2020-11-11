using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseManager : LoadComponent
{
    public Fase[] fases;
    int current;

    public static FaseManager instance;
    private void Awake()
    {
        instance = this;
    }

    protected override IEnumerator LoadMe()
    {
        yield return null;
    }

    public override void OnStartGame()
    {
        current = 0;
        StartFase();
    }

    void Check()
    {
        fases[current].EndFase();

        current++;
        if (current >= fases.Length)
        {
            Debug.Log("END ALL FASES");
        }
        else
        {
            fases[current].BeginFase();
        }
    }

    public void EndFase()
    {
        Check();
    }

    void StartFase() => fases[current].BeginFase();
    public void TRIGGER_EndElement() => fases[current].EndElement();
}
