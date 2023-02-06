using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public GameManager gameManager;
    public Vector2 MaxMinPaddleScale = new Vector2(1.7f, 0.21f);
    public Vector2 MaxMinBallScale = new Vector2(1.2f, 0.16f);
    private int AmountOfEffects = 10;
    public GameObject IntialBall;
    public PartyColors partyColors;
    public List<GameObject> ListOfGameObjects = new List<GameObject>();
    public SoundManager soundManager;
    private void Start()
    {
        ChangeAllColors();
    }
    public void RandomEffect()
    {
        switch (Random.Range(0, AmountOfEffects))
        {
            case 0:
                Debug.Log("Add Ball");
                AddBall();
                break;
            case 1:
                Debug.Log("Double Paddle Scale");
                ChangePaddleSize(gameManager.paddles[Random.Range(0, gameManager.paddles.Count)], true);
                break;
            case 2:
                Debug.Log("Double Ball Scale");
                ChangeBallSize(gameManager.balls[Random.Range(0, gameManager.balls.Count)], true);
                break;
            case 3:
                Debug.Log("Change Paddle Color");
                ChangeObjectColor(gameManager.paddles[Random.Range(0, gameManager.paddles.Count)].gameObject);
                break;
            case 4:
                Debug.Log("Double Ball Speed");
                ChangeBallSpeed(gameManager.balls[Random.Range(0, gameManager.balls.Count)], true);
                break;
            case 5:
                Debug.Log("Change Ball Color");
                ChangeObjectColor(gameManager.balls[Random.Range(0, gameManager.balls.Count)].gameObject);
                break;
            case 6:
                Debug.Log("Change All Colors");
                ChangeAllColors();
                break;
            case 7:
                Debug.Log("Random Song");
                soundManager.RandomSong();
                break;
            case 8:
                Debug.Log("Half Paddle Scale");
                ChangePaddleSize(gameManager.paddles[Random.Range(0, gameManager.paddles.Count)], false);
                break;
            case 9:
                Debug.Log("Half Ball Scale");
                ChangeBallSize(gameManager.balls[Random.Range(0, gameManager.balls.Count)], false);
                break;
            case 10:
                Debug.Log("Half Ball Speed");
                ChangeBallSpeed(gameManager.balls[Random.Range(0, gameManager.balls.Count)], false);
                break;
            default:
                break;
        }
    }

    public void AddBall()
    {
        GameObject ball = Instantiate(IntialBall, new Vector3(0,0,0), Quaternion.identity);
        gameManager.AddBall(ball.GetComponent<Ball>());
    }
    public void ChangePaddleSize(Paddle paddle, bool Increace)
    {
        if (Increace)
        {
            if (paddle.gameObject.transform.localScale.x < MaxMinPaddleScale.x)
            {
                paddle.ResetPlay();
                paddle.gameObject.transform.localScale *= 2;
            }
            else
            {
                Debug.Log("Paddles Reached Max Scale");
            }
        }
        else
        {
            if (paddle.gameObject.transform.localScale.x > MaxMinPaddleScale.y)
            {
                paddle.gameObject.transform.localScale /= 2;
            }
            else
            {
                Debug.Log("Paddles Reached Max Scale");
            }
        }
    }

    public void ChangeBallSize(Ball ball, bool Increace)
    {
        if (Increace)
        {
            if (ball.gameObject.transform.localScale.x < MaxMinBallScale.x)
            {
                ball.gameObject.transform.localScale *= 2;
            }
            else
            {
                Debug.Log("Ball Reached Max Scale");
            }
        }
        else
        {
            if (ball.gameObject.transform.localScale.x > MaxMinBallScale.y)
            {
                ball.gameObject.transform.localScale /= 2;
            }
            else
            {
                Debug.Log("Ball Reached Max Scale");
            }
        }
    }
    public void ChangeBallSpeed(Ball ball, bool Increace)
    {
        if (Increace)
        {
            ball.maxSpeed *= 2;
            ball.currentSpeed *= 2;
        }
        else
        {
            ball.maxSpeed /= 2;
            ball.currentSpeed /= 2;
        }
    }
    public void ChangeAllColors()
    {
        foreach (GameObject ObjectToChange in ListOfGameObjects)
        {
            ChangeObjectColor(ObjectToChange);
        }
    }
    public void ChangeObjectColor(GameObject ObjectToChange)
    {
        ObjectToChange.GetComponent<SpriteRenderer>().color = partyColors.ColorList[Random.Range(0, partyColors.ColorList.Count)];
    }
}
