using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public float maxPatienceInSeconds = 10.0f;
    public Tape_SO tape;

    private CustomerMovement customerMovement;
    private float waitingTimeInSeconds;

    // Start is called before the first frame update
    void Start()
    {
        customerMovement = gameObject.GetComponent<CustomerMovement>();
        waitingTimeInSeconds = 0;

        tape = ScriptableObject.CreateInstance<Tape_SO>();
        tape.solution = GenerateTapeSolution();
    }

    // Update is called once per frame
    void Update()
    {
        if(customerMovement.isWaiting)
        {
            waitingTimeInSeconds += Time.deltaTime;
        
            if(waitingTimeInSeconds >= maxPatienceInSeconds)
            {
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
}
