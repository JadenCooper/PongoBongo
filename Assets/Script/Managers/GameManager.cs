using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Ball> balls = new List<Ball>();
    public List<Paddle> paddles = new List<Paddle>();
    public Vector2 Scores = new Vector2(0, 0);
    public UIManager uIManager;
    public float WinScore = 5;
    public string[] PlayerNames = new string[2];
    private bool GameEnded = false;
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
        if (ball.gameObject.transform.localPosition.x < 0)
        {
            // Player 2 Scores
            Scores.y += 1;
            uIManager.UpdateScores(Scores);
            if (Scores.y >= WinScore)
            {
                GameOver(PlayerNames[1]);
            }
            else
            {
                ball.gameObject.transform.localPosition = Vector3.zero;
                ball.SetUp();
            }
        }
        else
        {
            // Player 1 Scores
            Scores.x += 1;
            uIManager.UpdateScores(Scores);
            if (Scores.x >= WinScore)
            {
                GameOver(PlayerNames[0]);
            }
            else
            {
                ball.gameObject.transform.localPosition = Vector3.zero;
                ball.SetUp();
            }
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
        Scores = Vector2.zero;
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
