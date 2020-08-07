using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapePile : MonoBehaviour
{
    public TapeRewind rewindCanvas;

    private PlayerInventory playerInventory;
    private FrontDeskInventory deskInventory;
    private AudioSource audioSource;
    private bool IsOnTapePile;

    // Start is called before the first frame update
    void Start()
    {
        deskInventory = gameObject.GetComponent<FrontDeskInventory>();
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();

        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
        audioSource.volume = SoundManager.instance.soundFXVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInventory || !rewindCanvas) { return; }

        if (IsOnTapePile && Input.GetKeyDown(KeyCode.E) && !GameManager.instance.IsAttendingCustomer)
        {
            // Make sure the player inventory has room left, and if desk inventory has any tapes
            if (deskInventory.tapeInventory.Count > 0
                && playerInventory.CanAddTapeToInventory())
            {
                // Grab first tape from desk inventory
                Tape_SO tape = deskInventory.tapeInventory[0];

                // Pass the tape to Rewind Comp and remove tape from desk inventory
                rewindCanvas.ItsRewindTime(tape);
                deskInventory.RemoveFromInventory(tape);
            }
        }
    }

    // Set the IsOnTapePile flag to know if player is in front of tape pile

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsOnTapePile = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsOnTapePile = false;
        }
    }

    public void PlayTapeDropOff()
    {
        if(!SoundManager.instance.enableSoundEfx) { return; }

        audioSource.Play();
    }
}