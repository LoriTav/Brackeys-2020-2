using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    public float speed = 4;
    public Transform destination;

    [HideInInspector]
    public bool isWaiting = false;

    [HideInInspector]
    public bool isExiting;
    
    // Start is called before the first frame update
    void Start()
    {
        isExiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!destination) { return; }
        
        // Cutomer reached destination = start waiting in Customer Comp
        isWaiting = Vector2.Distance(transform.position, destination.position) == 0;

        if (isWaiting) { return; }

        bool isMovingHorizontally = transform.position.x != destination.position.x;

        if(isMovingHorizontally)
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                new Vector2(destination.position.x, transform.position.y), speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(transform.position.x, destination.position.y), speed * Time.deltaTime);
        }
    }

    public void LeaveStore()
    {
        // Get the spawners location (door), and make customer move that way
        GameObject spawner = GameObject.Find("Customer Spawner");
        spawner.GetComponent<CustomerSpawner>().RemoveCustomer(gameObject);
        destination = spawner.transform;
        isExiting = true;

        Destroy(gameObject, 4f);
    }
}
