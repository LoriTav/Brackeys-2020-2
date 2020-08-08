using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInvUI : MonoBehaviour
{
    public Image[] slots;
    public Sprite defaultSprite;
    public Sprite sSprite;

    private PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < slots.Length; i++)
        {

            slots[i].sprite = i < playerInventory.tapeInventory.Count ? sSprite : defaultSprite;
        }
    }
}
