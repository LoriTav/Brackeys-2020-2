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
        gameOverText.text = GameManager.instance.gameOverMessage;
        
        PayText.text = string.Format("But at least you earned $" + ScoreManager.instance.score.ToString() + " first!");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
