using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public LoadHandler loadHandler;

    public Data data;
    
    private void Awake() => instance = this;
    private void Start()
    {
        PublicEvents.instance.EVENT_OnPreLoad();
        loadHandler.BeginLoad(PublicEvents.instance.EVENT_OnEndLoad);
        data.Initialize();

    }

    [SerializeField] Player model_player;
    public static Player GetPlayer() => instance.GetPLayer();
    Player GetPLayer() => model_player;
    public List<Player> players = new List<Player>();

    public void PushAllPlayers(bool right, float force = 10)
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].Push(right,force);
        }
    }

    public void SubscribePlayer(Player player) => players.Add(player);
    public void UnSubscribePlayer(Player player) 
    { 
        players.Remove(player);
        if (players.Count <= 0)
        {
            PublicEvents.instance.EVENT_OnPlayerDeath();
        }
    }

    public void AvoidHits()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<CircleCollider2D>().enabled = false;
        }

        StartCoroutine(TurnOnCollider());
    }

    IEnumerator TurnOnCollider()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
