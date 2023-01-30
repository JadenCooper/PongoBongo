using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    const float STARTSPEED = 64f;
    [SerializeField]
    private Vector2 movementVector;
    [SerializeField]
    private float currentSpeed = 0;
    [SerializeField]
    private float currentVerticalDirection = 0;
    [SerializeField]
    private float currentHorzantalDirection = 0;

    public float acceleration = 32f;
    private Rigidbody2D rb2d;
    private Vector3 StartPosition;
    private Vector3 OrginalScale;
    [SerializeField]
    private float maxSpeed = 800f;
    public UnityEvent<Ball> OnCaught = new UnityEvent<Ball>();
    public bool doubleAcceleration = false;
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        currentSpeed = STARTSPEED;
        OrginalScale = gameObject.transform.localScale;
        StartPosition = gameObject.transform.localPosition;
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
            // Vertical Bounce
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

        CaculateSpeed();
    }

    private void CaculateSpeed()
    {
        if (doubleAcceleration == true)
        {
            currentSpeed += currentSpeed;
        }
        else
        {
            currentSpeed += acceleration;
        }
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.tag == "Wall")
        {
            Hit(false);
        }
        else if (collision.gameObject.tag == "HWall")
        {
            Hit(true);
        }
        else
        {
            Hit(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            Hit(true);
        }
        else if (collision.gameObject.tag == "Catch")
        {
            OnCaught?.Invoke(this);
        }
    }

    public void SetUp()
    {
        currentSpeed = STARTSPEED;
        TipOff();
    }

    public void ReturnToStart()
    {
        currentSpeed = STARTSPEED;
        gameObject.transform.localPosition = StartPosition;
    }
}
