using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(Tape_SO tape in playerInventory.tapeInventory)
        {
            if (tape.shelf == this)
            {
                playerInventory.RemoveFromInventory(tape);
            }
        }
    }
}
