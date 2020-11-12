using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFollow : LoadComponent
{
    public static GhostFollow instance;
    private void Awake() => instance = this;
    public Transform follow_static;
    public Transform follow_dinamic;

    bool canupdate;

    protected override IEnumerator LoadMe() { yield return null; }

    public override void OnStartGame()
    {
        follow_dinamic.transform.position = follow_static.transform.position;
        canupdate = true;
    }

    public Transform GetGhostTransform()
    {
        return GameManager.instance.players.Count > 0 ?
            GameManager.instance.players[0].transform : 
            follow_static.transform;
    }
}
