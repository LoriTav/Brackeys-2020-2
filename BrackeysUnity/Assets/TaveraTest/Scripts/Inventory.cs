using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Tape_SO> tapes;

    // Start is called before the first frame update
    void Start()
    {
        tapes = new List<Tape_SO>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && tapes.Count > 0)
        {
            foreach(var t in tapes)
            {
                Debug.Log(t.solution);
            }
        }
    }

    public bool CanAddToInventory(Tape_SO tapeToAdd)
    {
        if(!tapes.Contains(tapeToAdd))
        {
            tapes.Add(tapeToAdd);
            return true;
        }

        return false;
    }
}
