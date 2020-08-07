using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShelfHolder : MonoBehaviour
{
    public List<Shelf> listOfShelves;
    private PlayerInventory playerInventory;
    private Color originalShelfColor;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        originalShelfColor = new Color(255,255,255,0);

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = SoundManager.instance.soundFXVolume;
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Gets all the shelves that corresponds with each tape found in player inventory
        Shelf[] targetShelves = listOfShelves
                                .Where(shelve => playerInventory.tapeInventory
                                .Any(tape => tape.shelf == shelve)).ToArray();

        // Go though all the shelves and color the targeted one to yellow.
        foreach(Shelf shelf in listOfShelves)
        {
            shelf.GetComponent<SpriteRenderer>().color 
                = targetShelves.Contains(shelf) ? Color.yellow : originalShelfColor;
        }
    }

    public void PlayMoneySound()
    {
        if(SoundManager.instance.enableSoundEfx)
        {
            audioSource.Play();
        }
    }
}
