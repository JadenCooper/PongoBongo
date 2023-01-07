using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Vector2 movementVector;
    [SerializeField]
    private float currentSpeed = 0;
    [SerializeField]
    private float currentVerticalDirection = 0;
    [SerializeField]
    private float currentHorzantalDirection = 0;
    [SerializeField]
    private float acceleration = 32f;
    private float maxSpeed = 200f;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        currentSpeed += 64;
        TipOff();
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

    public void Hit(bool PaddleHit)
    {
        if(PaddleHit == true)
        {
            if (movementVector.x == -1)
            {
                if (movementVector.y == -1)
                {
                    // -1,-1
                    movementVector = new Vector2(1, -1);
                }
                else
                {
                    // -1,1
                    movementVector = new Vector2(1, 1);
                }
            }
            else
            {
                if (movementVector.y == -1)
                {
                    // 1,-1
                    movementVector = new Vector2(-1, -1);
                }
                else
                {
                    //1,1
                    movementVector = new Vector2(-1, 1);
                }
            }
        }

        else
        {
            if (movementVector.x == -1)
            {
                if (movementVector.y == -1)
                {
                    // -1,-1
                    movementVector = new Vector2(-1, 1);
                }
                else
                {
                    // -1,1
                    movementVector = new Vector2(-1, -1);
                }
            }
            else
            {
                if (movementVector.y == -1)
                {
                    // 1,-1
                    movementVector = new Vector2(1, 1);
                }
                else
                {
                    //1,1
                    movementVector = new Vector2(1, -1);
                }
            }
        }

        Debug.Log(movementVector);
        CaculateSpeed();
    }

    private void CaculateSpeed()
    {
        currentSpeed += acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    private void TipOff()
    {
        switch(Random.Range(0,3))
        {
            case 0:
                movementVector = new Vector2(1, 1);
                break;

            case 1:
                movementVector = new Vector2(-1, -1);
                break;

            case 2:
                movementVector = new Vector2(-1, 1);
                break;

            case 3:
                movementVector = new Vector2(1, -1);
                break;
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(transform.right.x * currentSpeed * currentHorzantalDirection * Time.fixedDeltaTime, transform.up.y * currentSpeed * currentVerticalDirection * Time.fixedDeltaTime);
        //Debug.Log((Vector2)transform.right);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        if(collision.gameObject.tag == "Paddle")
        {
            Hit(true);
        }
        else
        {
            Hit(false);
        }
    }
}
