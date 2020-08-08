using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public List<GameObject> customers;
    public float spawnRate = 4.0f;
    public GameObject customerPrefab;
    public GameObject[] lineSpots;
    public Customer_SO[] animalVariations;
    public float customerAdditionalTime = 5;

    private AudioSource audioSource;
    private float spawnTimer;

    private void Awake()
    {
        // TODO Move this line to a manager
        Physics2D.gravity = new Vector2(0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        customers = new List<GameObject>();
        spawnTimer = spawnRate;
        
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = SoundManager.instance.volume;
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0 && customers.Count < lineSpots.Length 
            && !GameManager.instance.IsGameOver && !GameManager.instance.IsAttendingCustomer)
        {
            GameObject newCustomer = Instantiate(customerPrefab, transform.position, transform.rotation);
            customers.Add(newCustomer);

            newCustomer.GetComponent<Customer>().additionalTime = (customers.Count - 1) * customerAdditionalTime;
            newCustomer.GetComponent<CustomerMovement>().destination = lineSpots[customers.Count - 1].transform;
            newCustomer.GetComponent<CustomerMovement>().animalVariation = GenerateRandomAnimal();

            spawnTimer = spawnRate;
            
            if(SoundManager.instance.enableSoundEfx)
            {
                audioSource.Play();
            }
        }

        spawnTimer -= Time.deltaTime;
    }

    void UpdateCustomerSpots()
    {
        for (int i = 0; i < customers.Count; i++)
        {
            customers[i].GetComponent<CustomerMovement>().destination = lineSpots[i].transform;
        }
    }

    public void RemoveCustomer(GameObject customerToRemove)
    {
        customers.Remove(customerToRemove);
        UpdateCustomerSpots();

        spawnTimer = spawnRate;
    }

    private Customer_SO GenerateRandomAnimal()
    {
        int rndIdx = Random.Range(0, animalVariations.Length);

        return animalVariations[rndIdx];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Customer")
        {
            GameObject customer = collision.gameObject;
            
            if(customer.GetComponent<CustomerMovement>().isExiting)
            {
                Destroy(collision.gameObject, 1f);
            }
        }
    }

}
