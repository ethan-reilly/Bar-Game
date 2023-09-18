using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Glass : MonoBehaviour
{
    private int amount = 0;
    private bool filled = false;


    public void FillGlass()
    {
        if(filled == false)
        {
            Debug.Log("Filling Glass");
            amount += 25;
        }
            
    }

    public void Drop()
    {
        
    }

    public void Update()
    {
        if(amount >= 100)
        {
            Debug.Log("Filling");
            filled = true;
        }
    }


}
