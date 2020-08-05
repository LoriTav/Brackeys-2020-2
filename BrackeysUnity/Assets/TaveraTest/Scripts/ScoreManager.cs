using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetScoreManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScoreManager()
    {
        score = 0;
    }

    public void AddToScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void SubtractScore(int scoreToSub)
    {
        score -= scoreToSub;
    }
}
