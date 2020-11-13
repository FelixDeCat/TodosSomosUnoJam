using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDataBase : LoadComponent
{
    public static SoundDataBase instance;
    [SerializeField] AudioClip auEx;
    [SerializeField] AudioClip cell_divide;

    private void Awake() => instance = this;
    protected override IEnumerator LoadMe()
    {
        if (auEx) AudioManager.instance.GetSoundPool(auEx.name, AudioManager.AudioGroups.GAME_FX, auEx);
        if (cell_divide) AudioManager.instance.GetSoundPool(cell_divide.name, AudioManager.AudioGroups.GAME_FX, cell_divide);
        yield return null;
    }

    public override void OnStartGame()
    {

        //SoundDataBase.instance.PlayAuEx();
    }

    public void PlayAuEx() => AudioManager.instance.PlaySound(auEx.name);
    public void PlayCellDivide() => AudioManager.instance.PlaySound(cell_divide.name);


}
