using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Vector2 movementVector;
    [SerializeField]
    private float currentSpeed = 0;
    private float currentForewardDirection = 0;
    public float acceleration = 64f;
    private float deacceleration = 32f;
    [SerializeField]
    private float maxSpeed = 300f;
    private Rigidbody2D rb2d;
    // 0 = AI, 1 = Player1, 2 = Player2 
    public int PlayerType = 1;
    private string vertAxis;
    public Vector3 IntialScale;
    public bool Player = true;
    public GameObject ball;
    private bool choiceMade = false;
    public float choiceTime = 0.4f;
    public bool doubleAcceleration = false;
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        IntialScale = gameObject.transform.localScale;
    }

    public void SetPlayerType(int playerType)
    {
        PlayerType = playerType;
        switch (PlayerType)
        {
            case 0:
                //Ai
                Player = false;
                break;

            case 1:
                //Player One
                vertAxis = "Vertical(Player1)";
                break;
            case 2:
                //Player Two
                vertAxis = "Vertical(Player2)";
                break;

            case 3:
                //Player Three
                vertAxis = "Vertical(Player3)";
                break;

            case 4:
                //Player Four
                vertAxis = "Vertical(Player4)";
                break;

            default:
                //PlayerType Broke
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player)
        {
            movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw(vertAxis));
        }
        else
        {
            if (!choiceMade)
            {
                choiceMade = true;
                Vector2 ballPosition = ball.transform.position;
                float paddlePosition = gameObject.transform.position.y;
                if (ballPosition.y > paddlePosition)
                {
                    movementVector = new Vector2(0, 1);
                }
                else if (ballPosition.y < paddlePosition)
                {
                    movementVector = new Vector2(0, -1);
                }
                else
                {
                    movementVector = Vector2.zero;
                }
                StartCoroutine(WaitTimer());
            }
        }
        Move();
    }

    private IEnumerator WaitTimer()
    {
        yield return new WaitForSeconds(choiceTime);
        choiceMade = false;
    }
    public void Move()
    {
        CaculateSpeed();
        if (movementVector.y > 0)
        {
            currentForewardDirection = 1;
        }
        else if (movementVector.y < 0)
        {
            currentForewardDirection = -1;
        }
    }

    private void CaculateSpeed()
    {
        if (MathF.Abs(movementVector.y) > 0)
        {
            if (doubleAcceleration == true)
            {
                currentSpeed += currentSpeed + 16f * Time.deltaTime;
            }
            else
            {
                currentSpeed += acceleration * Time.deltaTime;
            }
        }
        else
        {
            currentSpeed -= deacceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = (Vector2)transform.up * currentSpeed * currentForewardDirection * Time.fixedDeltaTime;
    }
    public void ResetPlay()
    {
        gameObject.transform.localScale = IntialScale;
        Vector3 position = gameObject.transform.position;
        gameObject.transform.position = new Vector3(position.x, 0, 0);
        currentSpeed = 0;
    }
}
