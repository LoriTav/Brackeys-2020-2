using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int maxLives;
    public bool IsGameOver;
    public bool IsAttendingCustomer;

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

    }

    public void ResetGameManager()
    {
        IsGameOver = false;
        IsAttendingCustomer = false;
        lives = maxLives;
    }

    public void RemoveLive()
    {
        lives--;
        IsGameOver = lives <= 0;
    }
}
