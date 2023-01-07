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
    private float acceleration = 8f;
    private float deacceleration = 8f;
    private float maxSpeed = 50f;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
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
