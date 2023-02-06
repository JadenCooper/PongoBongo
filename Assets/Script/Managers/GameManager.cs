using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public List<Ball> balls = new List<Ball>();
    public List<Paddle> paddles = new List<Paddle>();
    public List<float> Scores = new List<float>();
    public UIManager uIManager;
    public float WinScore = 5;
    public string[] PlayerNames = new string[2];
    private bool GameEnded = false;
    private float ScoreChange = 1;
    public PlaySettingsSO playSettingsSO;
    public UnityEvent OnCaughtEffect = new UnityEvent();
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
        Vector2 ballPosition = ball.gameObject.transform.localPosition;
        int playerIndex = 0;
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

        Scores[playerIndex] += ScoreChange;
        uIManager.UpdateScores(Scores);
        if (Scores[playerIndex] == WinScore)
        {
            GameOver(PlayerNames[playerIndex]);
        }
        else
        {
            ball.gameObject.transform.localPosition = Vector3.zero;
            ball.SetUp();
            OnCaughtEffect?.Invoke();
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

        for (int i = 0; i < balls.Count; i++)
        {
            if (i == 0)
            {
                balls[i].gameObject.SetActive(true);
                balls[i].gameObject.transform.localPosition = Vector3.zero;
                balls[i].SetUp();
            }
            else
            {
                Destroy(balls[i].gameObject);
            }
        }
        while (balls.Count > 1)
        {
            balls.RemoveAt(1);
        }
    }
    public void AddBall(Ball ball)
    {
        balls.Add(ball);
        ball.StartPosition = Vector3.zero;
        ball.ReturnToStart();
    }
}
