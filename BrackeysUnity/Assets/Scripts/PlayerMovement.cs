using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public static bool isRewinding;
    public BoxCollider2D playerCol;
    public Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerCol = transform.GetComponent<BoxCollider2D>();
        playerRb = transform.GetComponent<Rigidbody2D>();
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        isRewinding = false;
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
    }

    public void Move()
    {
        if(Input.anyKey)
        {
            playerRb.velocity = new Vector2(0, 0);

            if (Input.GetKey(KeyCode.W))
            {
                playerRb.velocity = Vector2.up * walkSpeed;
            }

            else if(Input.GetKey(KeyCode.S))
            {
                playerRb.velocity = Vector2.down * walkSpeed;
            }


            if(Input.GetKey(KeyCode.A))
            {
                playerRb.velocity = new Vector2(-walkSpeed, playerRb.velocity.y);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            else if (Input.GetKey(KeyCode.D))
            {
                playerRb.velocity = new Vector2(walkSpeed, playerRb.velocity.y);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        else
        {
            playerRb.velocity = new Vector2(0, 0);
        }
    }


}
