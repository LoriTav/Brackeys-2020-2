using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapeRewind : MonoBehaviour
{
    public Text[] UISolutionText;

    private Canvas canvas;
    private int currentIdx;
    private Tape_SO currentTape;
    private PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas.enabled && currentTape)
        {
            UISolutionText[currentIdx].color = Color.green;
            string input = Input.inputString.ToLower();

            if(input == "w" || input == "a" || input == "s" || input == "d")
            {
                if(IsCorrectInput(input))
                {
                    UISolutionText[currentIdx].color = Color.white;
                    currentIdx++;
                }
                else
                {
                    CloseTapeRewindUI();
                }
            }

            // Rewind complete
            if(currentIdx >= UISolutionText.Length)
            {
                ScoreManager.instance.AddToScore(100);
                playerInventory.AddToInventory(currentTape);
                CloseTapeRewindUI();
            }
        }
    }

    public void ItsRewindTime(Tape_SO tape)
    {
        GameManager.instance.IsAttendingCustomer = true;
        currentTape = tape;
        SetSolution();
        canvas.enabled = true;
        currentIdx = 0;
    }

    private void SetSolution()
    {
        for(int i = 0; i < UISolutionText.Length; i++)
        {
            UISolutionText[i].text = currentTape.solution[i].ToString();
            UISolutionText[i].color = Color.white;
        }
    }

    private bool IsCorrectInput(string input)
    {
        return (input == currentTape.solution[currentIdx].ToString().ToLower());
    }

    public void CloseTapeRewindUI()
    {
        currentTape = null;
        canvas.enabled = false;
        GameManager.instance.IsAttendingCustomer = false;
    }
}
