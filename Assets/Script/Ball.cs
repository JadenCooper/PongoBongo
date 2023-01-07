using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 movementVector = new Vector2(-1,0);
    [SerializeField]
    private float currentSpeed = 0;
    private float currentVerticalDirection = 0;
    private float currentHorzantalDirection = 0;
    private float acceleration = 8f;
    private float maxSpeed = 200f;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        currentSpeed += 32;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (movementVector.y > 0)
        {
            currentVerticalDirection = 1;
        }
        else if (movementVector.y < 0)
        {
            currentVerticalDirection = -1;
        }
        if (movementVector.x > 0)
        {
            currentHorzantalDirection = 1;
        }
        else if (movementVector.x < 0)
        {
            currentHorzantalDirection = -1;
        }
    }

    public void Hit()
    {
        movementVector = -movementVector;
        CaculateSpeed();
    }

    private void CaculateSpeed()
    {
        currentSpeed += acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(transform.right.x * currentSpeed * currentHorzantalDirection * Time.fixedDeltaTime, transform.up.y * currentSpeed * currentVerticalDirection * Time.fixedDeltaTime);
        //Debug.Log((Vector2)transform.right);
    }
}
