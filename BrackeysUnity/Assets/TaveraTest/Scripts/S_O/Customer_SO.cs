using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Customer", menuName = "Customer/New Animal")]
public class Customer_SO : ScriptableObject
{
    public RuntimeAnimatorController backView_controller;
    public RuntimeAnimatorController frontView_controller;
    public RuntimeAnimatorController sideView_controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
