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

    public virtual bool CanAddToInventory(Customer customer)
    {
        CustomerMovement customerMovement = customer.customerMovement;

        return (customer.tape && customerMovement.isWaiting);
    }

    public virtual void AddToInventory(Tape_SO tapeToAdd)
    {
        tapeInventory.Add(tapeToAdd);
        Debug.Log(gameObject.name + " Received a tape");
    }
}
