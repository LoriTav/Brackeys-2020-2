using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public float maxPatienceInSeconds = 10.0f;
    public Tape_SO tape;
    public ShelfHolder shelfHolder;
    public Sprite tapeSprite;
    public Color furiousColor;

    private float patienceInSeconds;
    private FrontDeskInventory frontDeskInventory;
    private SpriteRenderer spriteRenderer;
    private bool changingColor;

    [HideInInspector]
    public float additionalTime = 0;

    [HideInInspector]
    public CustomerMovement customerMovement;

    // Start is called before the first frame update
    void Start()
    {
        customerMovement = gameObject.GetComponent<CustomerMovement>();
        frontDeskInventory = GameObject.Find("TapePile").GetComponent<FrontDeskInventory>();
        shelfHolder = GameObject.Find("ShelfHolder").GetComponent<ShelfHolder>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        tape = ScriptableObject.CreateInstance<Tape_SO>();
        tape.solution = GenerateTapeSolution();
        tape.shelf = GenerateRandomShelf();
        tape.sprite = tapeSprite;

        patienceInSeconds = 0;
        changingColor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(customerMovement.isWaiting && !customerMovement.isExiting)
        {
            patienceInSeconds += Time.deltaTime;

            if (patienceInSeconds >= (maxPatienceInSeconds + additionalTime))
            {
                if(frontDeskInventory.CanAddCustomerTapeToInventory(this))
                {
                    ScoreManager.instance.SubtractScore(20);
                    RemoveTapeFromCustomer();
                    frontDeskInventory.gameObject.GetComponent<TapePile>().PlayTapeDropOff();
                }

                customerMovement.LeaveStore();
            }
        }

        if(customerMovement.isWaiting)
        {
            StartCoroutine(LerpColor(spriteRenderer, spriteRenderer.color, furiousColor));
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

    IEnumerator LerpColor(SpriteRenderer targetImage, Color fromColor, Color toColor)
    {
        if (changingColor)
        {
            yield break;
        }

        changingColor = true;
        float counter = 0;

        while (counter < (maxPatienceInSeconds + additionalTime))
        {
            counter += Time.deltaTime;

            float colorTime = counter / (maxPatienceInSeconds + additionalTime);

            //Change color
            targetImage.color = Color.Lerp(fromColor, toColor, counter / (maxPatienceInSeconds + additionalTime));

            //Wait for a frame
            yield return null;
        }

        changingColor = false;
    }
}
