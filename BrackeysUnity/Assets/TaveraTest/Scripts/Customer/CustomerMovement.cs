﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    public float speed = 4;
    public Transform destination;
    public Animator animator;

    private string facingDirection;
    private SpriteRenderer spriteRenderer;
    
    [HideInInspector]
    public Customer_SO animalVariation;

    [HideInInspector]
    public bool isWaiting = false;

    [HideInInspector]
    public bool isExiting;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //default direction
        facingDirection = "Down";

        isExiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!destination) { return; }

        // Cutomer reached destination = start waiting in Customer Comp
        isWaiting = Vector2.Distance(transform.position, destination.position) == 0;

        if (isWaiting) 
        {
            if (!isExiting)
            {
                ChangeDirection("Down");
            }
            return; 
        }

        bool isMovingHorizontally = transform.position.x != destination.position.x;

        if(isMovingHorizontally)
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                new Vector2(destination.position.x, transform.position.y), speed * Time.deltaTime);

            var heading = destination.position.x - transform.position.x;

            //left flip "Right sprite"
            if (heading >= 0 && facingDirection != "Right")
            {
                ChangeDirection("Right");
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            //Right flip "Right sprite"
            if (heading <= 0 && facingDirection != "Right")
            {
                ChangeDirection("Right");
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {

            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(transform.position.x, destination.position.y), speed * Time.deltaTime);

            var heading = destination.position.y - transform.position.y;

            if (heading <= 0 && facingDirection != "Down")
            {
                ChangeDirection("Down");
            }

            if (heading >= 0 && facingDirection != "Up")
            {
                ChangeDirection("Up");
            }
        }
    }

    public void LeaveStore()
    {
        // Get the spawners location (door), and make customer move that way
        GameObject spawner = GameObject.Find("Customer Spawner");
        spawner.GetComponent<CustomerSpawner>().RemoveCustomer(gameObject);
        destination = spawner.transform;
        isExiting = true;
    }

    private void ChangeDirection(string direction)
    {
        facingDirection = direction;

        if (facingDirection == "Up")
        {
            animator.runtimeAnimatorController = animalVariation.backView_controller;
        }

        else if (facingDirection == "Down")
        {
            animator.runtimeAnimatorController = animalVariation.frontView_controller;
        }
        else
        {
            animator.runtimeAnimatorController = animalVariation.sideView_controller;
        }
    }
}
