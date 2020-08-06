using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shelf : MonoBehaviour
{
    private PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            // Get every tape from player inventory that belongs to 'this' particular shelf.
            Tape_SO[] targetTapes = playerInventory.tapeInventory.Where(t => t.shelf == this).ToArray();

            // Remove each tape collected above from player inventory.
            foreach(Tape_SO tape in targetTapes)
            {
                playerInventory.RemoveFromInventory(tape);
                ScoreManager.instance.AddToScore(100);
            }
        }
    }
}
