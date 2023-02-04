using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public List<TMP_Text> PlayerScoreTexts = new List<TMP_Text>();
    public List<TMP_Text> PlayerNameTexts = new List<TMP_Text>();
    public GameObject FreeForAllUIHolder;
    public GameObject EndGameUI;
    public GameObject PauseGameUI;
    public TMP_Text WonPlayer;
    public AudioSource mainGameMusic;

    public void SetupFreeForAll()
    {
        FreeForAllUIHolder.SetActive(true);
        PlayerNameTexts[0].text = "Player One Lives:";
        PlayerNameTexts[1].text = "Player Two Lives";
        PlayerNameTexts[2].text = "Player One Lives:";
        PlayerNameTexts[3].text = "Player Two Lives";
    }
    public void RemovePlayer(int playerIndex)
    {
        PlayerScoreTexts[playerIndex].color = Color.clear;
        PlayerNameTexts[playerIndex].color = Color.clear;
    }
    public void AddPlayer(int playerIndex)
    {
        PlayerScoreTexts[playerIndex].color = Color.white;
        PlayerNameTexts[playerIndex].color = Color.white;
    }
    public void UpdateScores(List<float> PlayerScores)
    {
        for (int i = 0; i < PlayerScoreTexts.Count; i++)
        {
            PlayerScoreTexts[i].text = PlayerScores[i].ToString();
        }
    }
    public void EndGame(string WonPlayerName)
    {
        EndGameUI.SetActive(true);
        WonPlayer.text = WonPlayerName + " Won";
    }
    public void StartGame()
    {
        EndGameUI.SetActive(false);
    }

    public void PauseGame()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            mainGameMusic.Pause();
            PauseGameUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            PauseGameUI.SetActive(false);
            mainGameMusic.Play();
        }
    }
}
