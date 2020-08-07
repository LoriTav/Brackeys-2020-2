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
        HashSet<Shelf> targetShelves = new HashSet<Shelf>();

        for(int i = 0; i < playerInventory.tapeInventory.Count; i++)
        {
            Tape_SO tape = playerInventory.tapeInventory[i];

            if (listOfShelves.Contains(tape.shelf))
            {
                targetShelves.Add(tape.shelf);
            }
        }

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
