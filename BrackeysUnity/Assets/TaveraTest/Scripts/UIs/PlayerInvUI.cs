using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInvUI : MonoBehaviour
{
    public Image[] slots;
    public Sprite defaultSprite;

    private PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();

        for (int i = 0; i < slots.Length; i++)
        {
            Tape_SO tape;

            try
            {
                tape = playerInventory.tapeInventory[i];
            }
            catch(Exception e)
            {
                string listen_TheOnlyWayToRemoveThisWarningIsToDoSomethingLikeThis = e.Message;
                tape = null;
            }

            slots[i].sprite = tape ? tape.sprite : defaultSprite;
        }
    }
}
