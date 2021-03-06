﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int maxLives;
    public bool IsGameOver;
    public bool IsAttendingCustomer;
    public float DeathTimer;
    public string gameOverMessage = "";

    [HideInInspector]
    public int lives;

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
        ResetGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGameOver == true)
        {
            if (SceneManager.GetActiveScene().name != "GameOver")
            {
                SceneManager.LoadScene("GameOver");
            }

            DeathTimer -= Time.deltaTime;
        }

        if(DeathTimer <= 0f && IsGameOver == true)
        {
            ScoreManager.instance.ResetScoreManager();
            SceneManager.LoadScene(0);
            ResetGameManager();
        }
    }

    public void ResetGameManager()
    {
        IsGameOver = false;
        IsAttendingCustomer = false;
        DeathTimer = 5.0f;
        lives = maxLives;
        gameOverMessage = "";
    }

    public void RemoveLive()
    {
        gameOverMessage = "Too many tapes were broken!";
        lives--;
        IsGameOver = lives <= 0;
    }
}
