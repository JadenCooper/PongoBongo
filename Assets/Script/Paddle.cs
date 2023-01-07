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
    [SerializeField]
    private float acceleration = 64f;
    private float deacceleration = 32f;
    [SerializeField]
    private float maxSpeed = 200f;
    private Rigidbody2D rb2d;
    // 0 = AI, 1 = Player1, 2 = Player2 
    public int PlayerType = 1;
    private string vertAxis;
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        switch(PlayerType)
        {
            case 0:
                //Ai
                break;

            case 1:
                //Player One
                vertAxis = "Vertical(Player1)";
                break;
            case 2:
                //Player Two
                vertAxis = "Vertical(Player2)";
                break;

            default:
                //PlayerType Broke
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw(vertAxis));
        Move();
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
            currentSpeed += acceleration * Time.deltaTime;
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
}
