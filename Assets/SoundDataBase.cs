using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDataBase : LoadComponent
{
    [SerializeField] AudioClip auEx;

    protected override IEnumerator LoadMe()
    {
        if (auEx) AudioManager.instance.GetSoundPool(auEx.name, AudioManager.AudioGroups.GAME_FX, auEx);
        yield return null;
    }

    public override void OnStartGame()
    {

    }

    public void PLayAuEx()
    {
        AudioManager.instance.PlaySound(auEx.name);
    }

    
}
