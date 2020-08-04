using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInventory playerInventory;
    private CustomerSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        spawner = GameObject.Find("Customer Spawner").GetComponent<CustomerSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerInventory || !spawner) { return; }
    
        if(Input.GetKeyDown(KeyCode.P) && spawner.customers.Count > 0)
        {
            Customer customer = spawner.customers[0].GetComponent<Customer>();

            if(!customer) { return; }

            if(playerInventory.CanAddToInventory(customer))
            {
                customer.RemoveTapeFromCustomer();
                customer.customerMovement.LeaveStore();
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach(var t in playerInventory.tapeInventory)
            {
                Debug.Log(t.solution);
            }
        }
    }
}
