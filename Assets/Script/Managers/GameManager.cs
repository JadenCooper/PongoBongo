using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Ball> balls = new List<Ball>();
    public List<Paddle> paddles = new List<Paddle>();
    public List<float> Scores = new List<float>();
    public UIManager uIManager;
    public float WinScore = 5;
    public string[] PlayerNames = new string[2];
    private bool GameEnded = false;
    private bool FreeForAll = false;
    private float ScoreChange = 1;
    public PlaySettingsSO playSettingsSO;

    private void Start()
    {
        for (int i = 0; i < paddles.Count; i++)
        {
            paddles[i].SetPlayerType(playSettingsSO.PlayerTypes[i]);
            switch (playSettingsSO.OtherSettings[1])
            {
                case 0:
                    // Normal
                    paddles[i].acceleration = 32f;
                    balls[0].acceleration = 32f;
                    break;
                case 1:
                    //Fast
                    paddles[i].acceleration = 64f;
                    balls[0].acceleration = 32f;
                    break;
                case 2:
                    //Extreme
                    paddles[i].acceleration = 88f;
                    balls[0].acceleration = 32f;
                    break;
                case 3:
                    //Double
                    paddles[i].doubleAcceleration = true;
                    balls[0].doubleAcceleration = true;
                    break;
                case 4:
                    //Slow
                    paddles[i].acceleration = 16f;
                    balls[0].acceleration = 32f;
                    break;
                default:
                    break;
            }
        }
        WinScore = playSettingsSO.OtherSettings[0];
        if (playSettingsSO.OtherSettings[2] == 1)
        {
            //Free For All Mode
            Scores.Add(0);
            Scores.Add(0);
            uIManager.SetupFreeForAll();
            FreeForAll = true;
            ScoreChange = -1;
            for (int i = 0; i < Scores.Count; i++)
            {
                Scores[i] = WinScore;
            }
            WinScore = 0;
            uIManager.UpdateScores(Scores);
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Pause") && !GameEnded)
        {
            uIManager.PauseGame();
        }
    }

    public void ResetBall(Ball ball)
    {
        Vector2 ballPosition = ball.gameObject.transform.localPosition;
        int playerIndex = 0;
        if (FreeForAll)
        {
            // Free For All
            if (ballPosition.x < 0)
            {
                if (ballPosition.y < 0)
                {
                    // Player 3 Loses Life
                    playerIndex = 2;
                }
                else
                {
                    //Player 1 loses Life
                    playerIndex = 0;
                }
            }
            else
            {
                if (ballPosition.y < 0)
                {
                    //Player 2 Loses Life
                    playerIndex = 1;
                }
                else
                {
                    // Player 4 Loses Life
                    playerIndex = 3;
                }
            }
        }
        else
        {
            // Teams
            if (ballPosition.x < 0)
            {
                // Player 2 Scores
                playerIndex = 1;
            }
            else
            {
                // Player 1 Scores
                playerIndex = 0;
            }
        }

        Scores[playerIndex] += ScoreChange;
        uIManager.UpdateScores(Scores);
        if (Scores[0] == WinScore)
        {
            if (FreeForAll)
            {
                // Player Eliminated

            }
            else
            {
                GameOver(PlayerNames[0]);
            }
        }
        else
        {
            ball.gameObject.transform.localPosition = Vector3.zero;
            ball.SetUp();
        }
    }

    public void GameOver(string WonPlayerName)
    {
        Debug.Log("Game Over " + WonPlayerName + " Won");
        foreach (Ball ball in balls)
        {
            ball.gameObject.transform.localPosition = Vector3.zero;
            ball.gameObject.SetActive(false);
        }
        GameEnded = true;
        uIManager.EndGame(WonPlayerName);
    }

    public void StartGame()
    {
        for (int i = 0; i < Scores.Count; i++)
        {
            Scores[i] = 0;
        }
        uIManager.UpdateScores(Scores);
        GameEnded = false;
        uIManager.StartGame();
        foreach(Paddle paddle in paddles)
        {
            paddle.ResetPlay();
        }
        foreach (Ball ball in balls)
        {
            ball.gameObject.SetActive(true);
            ball.gameObject.transform.localPosition = Vector3.zero;
            ball.SetUp();
        }
    }
}
