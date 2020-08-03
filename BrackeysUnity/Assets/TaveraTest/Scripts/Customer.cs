using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public float maxPatienceInSeconds = 10.0f;

    private CustomerMovement customerMovement;
    private float waitingTimeInSeconds;

    // Start is called before the first frame update
    void Start()
    {
        customerMovement = gameObject.GetComponent<CustomerMovement>();
        waitingTimeInSeconds = 0;
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
}
