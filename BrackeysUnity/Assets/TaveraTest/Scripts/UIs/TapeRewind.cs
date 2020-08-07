using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TapeRewind : MonoBehaviour
{
    public Image[] letterSprites;
    public AudioClip startClip;
    public AudioClip middleClip;

    private Canvas canvas;
    private int currentIdx;
    private Tape_SO currentTape;
    private AudioSource audioSource;
    private PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = SoundManager.instance.soundFXVolume;
        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas.enabled && currentTape)
        {
            UpdateRewindSoundFX();
            ReadAndApplyInput();
        }
    }

    // Opens Tape Rewind UI with the tape data that was passed in.
    public void ItsRewindTime(Tape_SO tape)
    {
        GameManager.instance.IsAttendingCustomer = true;
        currentTape = tape;
        SetSolution();
        canvas.enabled = true;
        currentIdx = 0;

        if(SoundManager.instance.enableSoundEfx)
        {
            audioSource.clip = startClip;
            audioSource.loop = false;
            audioSource.Play();
        }
    }

    private void SetSolution()
    {
        // Debug.Log(currentTape.solution);

        // Get the correct letters in their default mode, and display them to Tape Rewind UI
        for(int i = 0; i < letterSprites.Length; i++)
        {
            letterSprites[i].sprite = GetLetterData(i).defaultSprite;
        }
    }

    private bool IsCorrectInput(string input)
    {
        return (input == currentTape.solution[currentIdx].ToString().ToLower());
    }

    private void CloseTapeRewindUI()
    {
        currentTape = null;
        canvas.enabled = false;
        GameManager.instance.IsAttendingCustomer = false;
        audioSource.Stop();
    }

    // Returns a particular set of Letter data from the array of letters in Score Manager
    private Letter_SO GetLetterData(int ScoreManIdx)
    {
        return ScoreManager.instance.letters
            .FirstOrDefault(l => l.letter.ToLower()
            == currentTape.solution[ScoreManIdx].ToString().ToLower());
    }

    private void UpdateRewindSoundFX()
    {
        if (!audioSource.isPlaying && audioSource.clip == startClip
                && SoundManager.instance.enableSoundEfx && GameManager.instance.IsAttendingCustomer)
        {
            audioSource.Stop();
            audioSource.clip = middleClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void ReadAndApplyInput()
    {
        // Highlight the sprite at the current index to red
        letterSprites[currentIdx].sprite = GetLetterData(currentIdx).targetSprite;

        // Get player input
        string input;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            input = "w";
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            input = "a";
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            input = "s";
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            input = "d";
        }
        else
        {
            return;
        }

        if (IsCorrectInput(input))
        {
            // Hightlight current sprite to green = correct
            letterSprites[currentIdx].sprite = GetLetterData(currentIdx).correctSprite;

            // Move to next sprite
            currentIdx++;
        }
        else
        {
            // Close the Tape Rewind UI if incorrect choice
            CloseTapeRewindUI();
        }

        // Rewind complete - Award points and add tape to player inventory
        if (currentIdx >= letterSprites.Length)
        {
            ScoreManager.instance.AddToScore(50);
            playerInventory.AddToInventory(currentTape);
            CloseTapeRewindUI();
        }
    }
}
