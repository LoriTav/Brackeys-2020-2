using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Tape_SO> tapeInventory;

    // Start is called before the first frame update
    void Start()
    {
        tapeInventory = new List<Tape_SO>();    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual bool CanAddCustomerTapeToInventory(Customer customer)
    {
        CustomerMovement customerMovement = customer.customerMovement;

        return (customer.tape && customerMovement.isWaiting && !GameManager.instance.IsGameOver);
    }

    public virtual void AddToInventory(Tape_SO tapeToAdd)
    {
        tapeInventory.Add(tapeToAdd);
        //Debug.Log(gameObject.name + " Received a tape");
    }

    public void RemoveFromInventory(Tape_SO tapeToDrop)
    {
        tapeInventory.Remove(tapeToDrop);
        //Debug.Log(gameObject.name + " Dropped off tape");
    }
}
