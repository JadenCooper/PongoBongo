using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public PlaySettingsSO playSettingsSO;
    public SceneChange sceneChanger;
    public Slider BotSlider;
    public TMP_Dropdown PlayerAmountDropDown;
    public bool PartyMode = false;
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
        if (PartyMode)
        {
            //Partymode
            if (playSettingsSO.OtherSettings[2] == 1)
            {
                // Party 4 Player
                sceneChanger.ChangeScene("FourPlayerPartyMode");
            }
            else
            {
                // Party 2 Player
                sceneChanger.ChangeScene("TwoPlayerPartyMode");
            }
        }
        else
        {
            if (playSettingsSO.OtherSettings[2] == 1)
            {
                // Standared 4 Player
                sceneChanger.ChangeScene("FourPlayerMode");
            }
            else
            {
                // Standared 2 Player
                sceneChanger.ChangeScene("TwoPlayerMode");
            }
        }
    }
    public void SetGameOptions()
    {
        SetDefualtGameOptions();
        int i = (int)BotSlider.value;
        int temp = 3;
        if (i == 1 && PlayerAmountDropDown.value == 0)
        {
            playSettingsSO.PlayerTypes[1] = 0;
        }
        else
        {
            while (i != 0)
            {
                playSettingsSO.PlayerTypes[temp] = 0;
                temp--;
                i--;
            }
        }
        playSettingsSO.OtherSettings[2] = PlayerAmountDropDown.value; // Game Size
        playSettingsSO.OtherSettings[0] = ScoreSlider.value;
        playSettingsSO.OtherSettings[1] = SpeedDropdown.value;
    }
    public void SetGameOptionsUI()
    {
        PlayerAmountDropDown.value = (int)playSettingsSO.OtherSettings[2];
        ScoreSlider.value = playSettingsSO.OtherSettings[0];
        SpeedDropdown.value = (int)playSettingsSO.OtherSettings[1];
        int temp = 0;
        for (int i = 0; i < playSettingsSO.PlayerTypes.Length; i++)
        {
            if (playSettingsSO.PlayerTypes[i] == 0)
            {
                temp++;
            }
        }
        BotSlider.value = temp;
    }

    public void SetDefualtGameOptions()
    {
        for (int t = 0; t < 4; t++)
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
    }
    public void UnsetPartyMode()
    {
        PartyMode = false;
    }
}
