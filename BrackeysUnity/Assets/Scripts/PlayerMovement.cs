using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public Customer_SO playerCustomer_SO;

    private string facingDirection;
    private Rigidbody2D playerRb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRb = transform.GetComponent<Rigidbody2D>();
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;

        //default direction
        ChangeDirection("Up");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!GameManager.instance.IsAttendingCustomer)
        {
            Move();
        }
        else
        {
            playerRb.velocity = new Vector2(0, 0);
        }
    }

    public void Move()
    {
        if(Input.anyKey)
        {
            playerRb.velocity = new Vector2(0, 0);

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if(facingDirection != "Up")
                {
                    ChangeDirection("Up");
                }

                playerRb.velocity = Vector2.up * walkSpeed;       
            }

            else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                if (facingDirection != "Down")
                {
                    ChangeDirection("Down");
                }

                playerRb.velocity = Vector2.down * walkSpeed;
            }


            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (facingDirection != "Right")
                {
                    ChangeDirection("Right");
                }

                playerRb.velocity = new Vector2(-walkSpeed, playerRb.velocity.y);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (facingDirection != "Right")
                {
                    ChangeDirection("Right");
                }

                playerRb.velocity = new Vector2(walkSpeed, playerRb.velocity.y);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        else
        {
            playerRb.velocity = new Vector2(0, 0);
        }
    }

    public void ChangeDirection(string direction)
    {
        facingDirection = direction;

        if (facingDirection == "Up")
        {
            animator.runtimeAnimatorController = playerCustomer_SO.backView_controller;
        }
        else if (facingDirection == "Down")
        {
            animator.runtimeAnimatorController = playerCustomer_SO.frontView_controller;
        }
        else if (facingDirection == "Right")
        {
            animator.runtimeAnimatorController = playerCustomer_SO.sideView_controller;
        }
    }
}
