using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public List<TMP_Text> PlayerScoreTexts = new List<TMP_Text>();
    public GameObject EndGameUI;
    public TMP_Text WonPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScores(Vector2 PlayerScores)
    {
        PlayerScoreTexts[0].text = PlayerScores.x.ToString();
        PlayerScoreTexts[1].text = PlayerScores.y.ToString();
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
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
