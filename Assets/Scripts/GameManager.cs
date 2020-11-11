using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public LoadHandler loadHandler;
    public UnityEvent OnPreLoad;
    public UnityEvent OnEndLoad;
    private void Awake() => instance = this;
    private void Start()
    {
        OnPreLoad.Invoke();
        loadHandler.BeginLoad(OnEndLoad.Invoke);
    }

    [SerializeField] Player model_player;
    public static Player GetPlayer() => instance.GetPLayer();
    Player GetPLayer() => model_player;
    public List<Player> players = new List<Player>();

    public void SubscribePlayer(Player player) => players.Add(player);
    public void UnSubscribePlayer(Player player) => players.Remove(player);
}
