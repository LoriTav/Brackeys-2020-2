using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeComp : MonoBehaviour
{
    public int solutionLength = 5;
    public string solution;

    // Start is called before the first frame update
    void Start()
    {
        solution = "";
        string solChars = "WASD";

        for(int i = 0; i < solutionLength; i++)
        {
            solution += solChars[Random.Range(0, 4)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
