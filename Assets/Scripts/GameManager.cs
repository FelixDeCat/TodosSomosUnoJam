using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() => instance = this;

    [SerializeField] Player model_player;

    public static Player GetPlayer() => instance.GetPLayer();
    Player GetPLayer() => model_player;
    public List<Player> players = new List<Player>();


    public void SubscribePlayer(Player player) => players.Add(player);
    public void UnSubscribePlayer(Player player) => players.Remove(player);
}
