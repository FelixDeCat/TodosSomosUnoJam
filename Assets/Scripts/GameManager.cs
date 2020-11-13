using System;
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
    public void TurnCollisions(bool val)
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].MyCollision(val);
        }
    }
    public void TurnOnBubble()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].TurnOnBubble();
        }
    }

    public void ReceiveSignalHeal(int signal)
    {
        int child_acum = 0;
        int med_acum = 0;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].type_cel == 1) child_acum++;
            if (players[i].type_cel == 2) med_acum++;
        }

        if (signal == 1)
        {
            if (child_acum > 1)
            {
                Create(1);
            }
            else
            {
                Create();
            }
        }
        else if (signal == 2)
        {
            if (med_acum > 1)
            {
                Create(2);
            }
            else
            {
                if (child_acum > 1)
                {
                    Create(1);
                }
                else
                {
                    Create();
                }
            }
        }
    }

    public void Create(int signal)
    {
       Player[] plays = new Player[2];
        int acum = 0;

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].type_cel == signal)
            {
                plays[acum] = players[i];
                acum++;
                if (acum > 1) break;
            }
        }

        Vector3 posacum = Vector3.zero; 
        for (int i = 0; i < plays.Length; i++)
        {
            posacum += plays[i].gameObject.transform.position;
            UnSubscribePlayer(plays[i]);
            Destroy(plays[i].gameObject);
        }
        posacum = posacum / 2;

        var obj = GameObject.Instantiate(GameManager.GetPlayer());
        obj.Build(signal+1, GhostFollow.instance.follow_dinamic.transform.position);
    }
    public void Create()
    {
        var obj = GameObject.Instantiate(GameManager.GetPlayer());
        obj.Build(1, GhostFollow.instance.follow_dinamic.transform.position);
    }

    internal void SetRecallOnPlayers()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].HitRecall();
        }
    }
}