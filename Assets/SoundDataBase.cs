using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDataBase : LoadComponent
{
    public static SoundDataBase instance;
    [SerializeField] AudioClip death_Cell;
    [SerializeField] AudioClip Cell_Divide;
    [SerializeField] AudioClip button_Nav;
    [SerializeField] AudioClip button_Select;
    [SerializeField] AudioClip BGMusicPlay;
    [SerializeField] AudioClip BGMusicMenu;

    private void Awake() => instance = this;
    protected override IEnumerator LoadMe()
    {
        /*if (death_Cell) AudioManager.instance.GetSoundPool(death_Cell.name, AudioManager.AudioGroups.GAME_FX, death_Cell);
        if (Cell_Divide) AudioManager.instance.GetSoundPool(Cell_Divide.name, AudioManager.AudioGroups.GAME_FX, Cell_Divide);
        if (button_Nav) AudioManager.instance.GetSoundPool(button_Nav.name, AudioManager.AudioGroups.GAME_FX, button_Nav);
        if (button_Select) AudioManager.instance.GetSoundPool(button_Select.name, AudioManager.AudioGroups.GAME_FX, button_Select);*/
        yield return null;
    }

    private void Start()
    {
        if (death_Cell) AudioManager.instance.GetSoundPool(death_Cell.name, AudioManager.AudioGroups.GAME_FX, death_Cell);
        if (Cell_Divide) AudioManager.instance.GetSoundPool(Cell_Divide.name, AudioManager.AudioGroups.GAME_FX, Cell_Divide);
        if (button_Nav) AudioManager.instance.GetSoundPool(button_Nav.name, AudioManager.AudioGroups.GAME_FX, button_Nav);
        if (button_Select) AudioManager.instance.GetSoundPool(button_Select.name, AudioManager.AudioGroups.GAME_FX, button_Select);
        if (BGMusicPlay) AudioManager.instance.GetSoundPool(BGMusicPlay.name, AudioManager.AudioGroups.MUSIC, BGMusicPlay);
        if (BGMusicMenu) AudioManager.instance.GetSoundPool(BGMusicMenu.name, AudioManager.AudioGroups.MUSIC, BGMusicMenu);
    }

    public override void OnStartGame()
    {

        //SoundDataBase.instance.PlayAuEx();
    }

    public void PlayDeathCell() => AudioManager.instance.PlaySound(death_Cell.name);
    public void PlayCellDivide() => AudioManager.instance.PlaySound(Cell_Divide.name);
    public void PlayButtonNav() => AudioManager.instance.PlaySound(button_Nav.name);
    public void PlayButtonSelect() => AudioManager.instance.PlaySound(button_Select.name);
    public void PlayMusicBGPlay() => AudioManager.instance.PlaySound(BGMusicPlay.name);
    public void PlayMusicBGMenu() => AudioManager.instance.PlaySound(BGMusicMenu.name);


}
