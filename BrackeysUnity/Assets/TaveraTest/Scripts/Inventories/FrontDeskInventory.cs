using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDeskInventory : Inventory
{
    public int gameOverReach = 5;

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
        if (base.CanAddToInventory(customer))
        {
            AddToInventory(customer.tape);
            return true;
        }

        return false;
    }

    public override void AddToInventory(Tape_SO tapeToAdd)
    {
        base.AddToInventory(tapeToAdd);

        if(tapeInventory.Count >= gameOverReach)
        {
            Debug.Log("Game Over");
        }
    }
}
