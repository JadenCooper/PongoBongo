using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Ball> balls = new List<Ball>();
    public List<Paddle> paddles = new List<Paddle>();
    public Vector2 Scores = new Vector2(0, 0);
    public UIManager uIManager;
    public int WinScore = 5;
    public string[] PlayerNames = new string[2];
    private bool GameEnded = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
            ball.SetUp();
        }
    }
}
