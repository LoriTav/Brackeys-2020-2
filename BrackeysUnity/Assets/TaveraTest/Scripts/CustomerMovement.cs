using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    public float speed = 4;
    public Transform destination;
    
    [HideInInspector]
    public int spotIndex;
    
    private bool isMovingHorizontally = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!destination) { return; }

        if (Vector2.Distance(transform.position, destination.position) <= 0) { return; }

        isMovingHorizontally = transform.position.x != destination.position.x;

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
}
