using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDataBase : LoadComponent
{
    public static SoundDataBase instance;
    [SerializeField] AudioClip big_Cell_Divide;
    [SerializeField] AudioClip medium_Cell_Divide;
    [SerializeField] AudioClip button_Nav;
    [SerializeField] AudioClip button_Select;

    private void Awake() => instance = this;
    protected override IEnumerator LoadMe()
    {
        if (big_Cell_Divide) AudioManager.instance.GetSoundPool(big_Cell_Divide.name, AudioManager.AudioGroups.GAME_FX, big_Cell_Divide);
        if (medium_Cell_Divide) AudioManager.instance.GetSoundPool(medium_Cell_Divide.name, AudioManager.AudioGroups.GAME_FX, medium_Cell_Divide);
        if (button_Nav) AudioManager.instance.GetSoundPool(button_Nav.name, AudioManager.AudioGroups.GAME_FX, button_Nav);
        if (button_Select) AudioManager.instance.GetSoundPool(button_Select.name, AudioManager.AudioGroups.GAME_FX, button_Select);
        yield return null;
    }

    public override void OnStartGame()
    {

        //SoundDataBase.instance.PlayAuEx();
    }

    public void PlayBigCellDivide() => AudioManager.instance.PlaySound(big_Cell_Divide.name);
    public void PlayMediumCellDivide() => AudioManager.instance.PlaySound(medium_Cell_Divide.name);
    public void PlayButtonNav() => AudioManager.instance.PlaySound(button_Nav.name);
    public void PlayButtonSelect() => AudioManager.instance.PlaySound(button_Select.name);


}
