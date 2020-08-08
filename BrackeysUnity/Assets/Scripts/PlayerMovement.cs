using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public static bool isRewinding;
    public BoxCollider2D playerCol;
    public Rigidbody2D playerRb;
    public string facingDirection;
    public Sprite Right;
    public Sprite Up;
    public Sprite Down;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController anim1;
    public RuntimeAnimatorController anim2;
    public RuntimeAnimatorController anim3;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCol = transform.GetComponent<BoxCollider2D>();
        playerRb = transform.GetComponent<Rigidbody2D>();
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        isRewinding = false;

        //default direction
        facingDirection = "Up";
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

                animator.runtimeAnimatorController = anim1;
                playerRb.velocity = Vector2.up * walkSpeed;       
            }

            else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                if (facingDirection != "Down")
                {
                    ChangeDirection("Down");
                }

                animator.runtimeAnimatorController = anim2;
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

                animator.runtimeAnimatorController = anim3;
            }

            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (facingDirection != "Right")
                {
                    ChangeDirection("Right");
                }

                playerRb.velocity = new Vector2(walkSpeed, playerRb.velocity.y);
                transform.eulerAngles = new Vector3(0, 180, 0);

                animator.runtimeAnimatorController = anim3;
            }
        }
        else
        {
            playerRb.velocity = new Vector2(0, 0);
            ChangeDirection(facingDirection);
        }
    }

    public void ChangeDirection(string direction)
    {
        facingDirection = direction;

        if (facingDirection == "Up")
        {
            spriteRenderer.sprite = Up;
        }

        else if (facingDirection == "Down")
        {
            spriteRenderer.sprite = Down;
        }
        else
        {
            spriteRenderer.sprite = Right;
        }
    }
}
