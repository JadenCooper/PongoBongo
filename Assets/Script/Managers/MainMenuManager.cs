using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public PlaySettingsSO playSettingsSO;
    public SceneChange sceneChange;
    public Slider SinglePlayerScoreSlider;
    public TMP_Dropdown SinglePlayerSpeedDropDown;
    public Slider TwoPlayerScoreSlider;
    public TMP_Dropdown TwoPlayerSpeedDropDown;
    public void StartSinglePlayer()
    {
        playSettingsSO.PlayerTypes[0] = 1;
        playSettingsSO.PlayerTypes[1] = 0;
        playSettingsSO.OtherSettings[0] = SinglePlayerScoreSlider.value;
        playSettingsSO.OtherSettings[1] = SinglePlayerSpeedDropDown.value;
        //sceneChange.PlayGameTwoPlayer();
    }

    public void StartTwoPlayer()
    {
        playSettingsSO.PlayerTypes[0] = 1;
        playSettingsSO.PlayerTypes[1] = 2;
        playSettingsSO.OtherSettings[0] = TwoPlayerScoreSlider.value;
        playSettingsSO.OtherSettings[1] = TwoPlayerSpeedDropDown.value;
        //sceneChange.PlayGameTwoPlayer();
    }
}
