using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Screen;

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

    public Transform[] objetivos;



    float y_position;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (GameManager.instance.players.Count > 1)
        {
            Vector2 acum = Vector2.zero;
            foreach (var obj in GameManager.instance.players)
            {
                acum = new Vector2(acum.x + obj.transform.position.x, acum.y);
            }
            follow_dinamic.transform.position = acum / GameManager.instance.players.Count;
            follow_dinamic.transform.position = new Vector2(follow_dinamic.transform.position.x, 7);

            ClampToScreen(follow_dinamic);
        }
    }

    void ClampToScreen(Transform t)
    {
        if (t.position.x >= ScreenLimits.Right_Superior.x)
        {
            t.position = new Vector2(ScreenLimits.Right_Superior.x - 1, t.position.y);
        }
        if (t.position.x <= ScreenLimits.Left_Inferior.x)
        {
            t.position = new Vector2(ScreenLimits.Left_Inferior.x + 1, t.position.y);
        }
    }

    public Transform GetGhostTransformOrNull()
    {
        return GameManager.instance.players.Count > 0 ? follow_dinamic : null;
    }

    public Transform GetGhostTransform()
    {
        return GameManager.instance.players.Count > 0 ? follow_dinamic : follow_static;
    }
}
