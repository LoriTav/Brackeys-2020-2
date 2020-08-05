﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    public int limit = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool CanAddToInventory(Customer customer)
    {
        return (base.CanAddToInventory(customer) && tapeInventory.Count < limit);
    }
}