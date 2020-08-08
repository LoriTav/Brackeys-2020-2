using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDeskInventory : Inventory
{
    public int gameOverReach = 5;

    private GameObject[] stackOfTapes;

    // Start is called before the first frame update
    void Start()
    {
        stackOfTapes = GameObject.FindGameObjectsWithTag("FDTape");
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < stackOfTapes.Length; i++)
        {
            stackOfTapes[i].GetComponent<SpriteRenderer>().enabled = i < tapeInventory.Count;
        }
    }

    public override bool CanAddCustomerTapeToInventory(Customer customer)
    {
        if (base.CanAddCustomerTapeToInventory(customer))
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
            GameManager.instance.gameOverMessage = "Too Many unattended tapes in front desk";
            GameManager.instance.IsGameOver = true;
        }
    }
}
