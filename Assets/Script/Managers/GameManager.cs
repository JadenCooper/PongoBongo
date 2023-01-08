using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Ball> balls = new List<Ball>();
    public Vector2 Scores = new Vector2(0, 0);
    public UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetBall(Ball ball)
    {
        if (ball.gameObject.transform.localPosition.x < 0)
        {
            Scores.y += 1;
        }
        else
        {
            Scores.x += 1;
        }
        ball.gameObject.transform.localPosition = Vector3.zero;
        uIManager.UpdateScores(Scores);
        ball.SetUp();
    }
}
