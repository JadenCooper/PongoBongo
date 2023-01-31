using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public PlaySettingsSO playSettingsSO;
    public SceneChange sceneChange;
    public Slider BotSlider;
    public TMP_Dropdown PlayerAmountDropDown;
    public bool PartyMode = false;
    public TMP_Text GameModeTextBox;
    public Slider ScoreSlider;
    public TMP_Dropdown SpeedDropdown;
    public void RestrictSlider()
    {
        if (PlayerAmountDropDown.value == 0)
        {
            BotSlider.maxValue = 1;
        }
        else
        {
            BotSlider.maxValue = 3;
        }
    }

    public void StartGame()
    {

    }
    public void SetGameOptions()
    {
        SetDefualtGameOptions();
        int i = (int)BotSlider.value;
        int temp = 3;
        while (i != 0)
        {
            playSettingsSO.PlayerTypes[temp] = 0;
            temp--;
            i--;
        }
        playSettingsSO.OtherSettings[2] = PlayerAmountDropDown.value; // Game Size
        playSettingsSO.OtherSettings[0] = ScoreSlider.value;
        playSettingsSO.OtherSettings[1] = SpeedDropdown.value;
    }
    public void SetDefualtGameOptions()
    {
        for (int t = 0; t < 3; t++)
        {
            playSettingsSO.PlayerTypes[t] = t + 1;
        }
        playSettingsSO.OtherSettings[2] = 0; // Game Size
        playSettingsSO.OtherSettings[0] = 5; // Score
        playSettingsSO.OtherSettings[1] = 0; // Speed Type
    }
    public void SetPartyMode()
    {
        PartyMode = true;
        GameModeTextBox.text = "Party Mode";
    }
    public void UnsetPartyMode()
    {
        PartyMode = false;
        GameModeTextBox.text = "Standard Mode";
    }
}
