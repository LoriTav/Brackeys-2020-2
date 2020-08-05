﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public List<GameObject> customers;
    public float spawnRate = 4.0f;
    public GameObject customerPrefab;
    public GameObject[] lineSpots;

    private float spawnTimer;

    private void Awake()
    {
        // TODO Move this line to a manager
        Physics2D.gravity = new Vector2(0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        customers = new List<GameObject>();
        spawnTimer = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0 && customers.Count < lineSpots.Length 
            && !GameManager.instance.IsGameOver && !GameManager.instance.IsAttendingCustomer)
        {
            GameObject newCustomer = Instantiate(customerPrefab, transform.position, transform.rotation);
            customers.Add(newCustomer);

            newCustomer.GetComponent<CustomerMovement>().destination = lineSpots[customers.Count - 1].transform;

            spawnTimer = spawnRate;
        }

        spawnTimer -= Time.deltaTime;
    }

    void UpdateCustomerSpots()
    {
        for (int i = 0; i < customers.Count; i++)
        {
            customers[i].GetComponent<CustomerMovement>().destination = lineSpots[i].transform;
        }
    }

    public void RemoveCustomer(GameObject customerToRemove)
    {
        customers.Remove(customerToRemove);
        UpdateCustomerSpots();

        spawnTimer = spawnRate;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Customer")
        {
            GameObject customer = collision.gameObject;
            
            if(customer.GetComponent<CustomerMovement>().isExiting)
            {
                Destroy(collision.gameObject, 1f);
            }
        }
    }
}
