using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public float maxPatienceInSeconds = 10.0f;
    public Tape_SO tape;
    public ShelfHolder shelfHolder;

    private float waitingTimeInSeconds;
    private FrontDeskInventory frontDeskInventory;

    [HideInInspector]
    public CustomerMovement customerMovement;

    // Start is called before the first frame update
    void Start()
    {
        customerMovement = gameObject.GetComponent<CustomerMovement>();
        frontDeskInventory = GameObject.Find("FrontDesk").GetComponent<FrontDeskInventory>();
        shelfHolder = GameObject.Find("ShelfHolder").GetComponent<ShelfHolder>();

        tape = ScriptableObject.CreateInstance<Tape_SO>();
        tape.solution = GenerateTapeSolution();
        tape.shelf = GenerateRandomShelf();
        waitingTimeInSeconds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(customerMovement.isWaiting && !customerMovement.isExiting 
            && !GameManager.instance.IsGameOver && !GameManager.instance.IsAttendingCustomer)
        {
            waitingTimeInSeconds += Time.deltaTime;
        
            if(waitingTimeInSeconds >= maxPatienceInSeconds)
            {
                if(frontDeskInventory.CanAddToInventory(this))
                {
                    ScoreManager.instance.SubtractScore(20);
                    RemoveTapeFromCustomer();
                }

                customerMovement.LeaveStore();
            }
        }
    }

    private string GenerateTapeSolution()
    {
        string solution = "";
        string solChars = "WASD";

        for (int i = 0; i < 6; i++)
        {
            solution += solChars[Random.Range(0, 4)];
        }

        return solution;
    }

    public Shelf GenerateRandomShelf()
    {
        Shelf randomShelf = shelfHolder.listOfShelves[Random.Range(0, shelfHolder.listOfShelves.Count)];

        return (randomShelf);
    }

    public void RemoveTapeFromCustomer()
    {
        tape = null;
    }
}
