using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathUI : MonoBehaviour
{
    public Text gameOverText;
    public Text PayText;

    // Start is called before the first frame update
    void Start()
    {
        string payMessage = "";

        if (ScoreManager.instance.score == 0)
        {
            payMessage = "You didn't earned any money.";
        }
        else if(ScoreManager.instance.score > 0)
        {
            payMessage = "But at least you earned $" + ScoreManager.instance.score.ToString();
        }
        else if(ScoreManager.instance.score < 0)
        {
            payMessage = "You owe the store $" + (ScoreManager.instance.score * -1).ToString();
        }

        gameOverText.text = GameManager.instance.gameOverMessage;
        PayText.text = payMessage;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
