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
        PublicEvents.instance.EVENT_OnBeginFirstFase();
    }

    void Check()
    {
        fases[current].EndFase();

        current++;
        if (current >= fases.Length)
        {
            //PublicEvents.instance.EVENT_OnEndAllFases();
            current = 0;
            fases[current].BeginFase();
        }
        else
        {
            PublicEvents.instance.EVENT_OnChangeFase();
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
