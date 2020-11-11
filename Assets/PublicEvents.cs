using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PublicEvents : MonoBehaviour
{
    public static PublicEvents instance;
    private void Awake() => instance = this;

    [Header("GameCore")]
    [SerializeField] UnityEvent OnPreLoad;
    [SerializeField] UnityEvent OnEndLoad;

    [Header("Player Gameplay")]
    [SerializeField] UnityEvent OnPlayerDeath;
    [SerializeField] UnityEvent OnPlayerHit;

    [Header("Fases")]
    [SerializeField] UnityEvent OnBeginFirstFase;
    [SerializeField] UnityEvent OnChangeFase;
    [SerializeField] UnityEvent OnEndAllFases;

    public void EVENT_OnPreLoad() => OnPreLoad.Invoke();
    public void EVENT_OnEndLoad() => OnEndLoad.Invoke();
    public void EVENT_OnPlayerDeath() => OnPlayerDeath.Invoke();
    public void EVENT_OnPlayerHit() => OnPlayerHit.Invoke();
    public void EVENT_OnBeginFirstFase() => OnBeginFirstFase.Invoke();
    public void EVENT_OnChangeFase() => OnChangeFase.Invoke();
    public void EVENT_OnEndAllFases() => OnEndAllFases.Invoke();
}
