using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDataBase : MonoBehaviour
{
    [SerializeField] AudioClip auEx;

    private void Awake()
    {
        if(auEx) AudioManager.instance.GetSoundPool(auEx.name, AudioManager.AudioGroups.GAME_FX, auEx);
    }

    public void PLayAuEx()
    {
        AudioManager.instance.PlaySound(auEx.name);
    }
}
