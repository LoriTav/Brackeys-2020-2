using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLine : MonoBehaviour
{
    public TapeRewind rewindCanvas;
    private PlayerInventory playerInventory;
    private CustomerSpawner spawner;
    private bool IsOnCustomerLine;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        spawner = GameObject.Find("Customer Spawner").GetComponent<CustomerSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInventory || !spawner || !rewindCanvas) { return; }
        
        if (IsOnCustomerLine && Input.GetKeyDown(KeyCode.E)
            && spawner.customers.Count > 0 && !GameManager.instance.IsAttendingCustomer)
        {
            // Get customer in front of line
            Customer customer = spawner.customers[0].GetComponent<Customer>();

            // Make sure we can add the customer's tape to player inventory
            if (playerInventory.CanAddCustomerTapeToInventory(customer))
            {
                // Pass the tape to Rewind Comp
                rewindCanvas.ItsRewindTime(customer.tape);

                // Add score for receiving tape from customer directly
                ScoreManager.instance.AddToScore(35);

                // Remove tape from customer and make them leave
                customer.RemoveTapeFromCustomer();
                customer.customerMovement.LeaveStore();
            }
        }
    }

    // Set the IsOnCustomerLine flag to know if player is in front of customer's line

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsOnCustomerLine = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsOnCustomerLine = false;
        }
    }
}
