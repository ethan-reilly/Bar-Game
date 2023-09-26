using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Glass : MonoBehaviour
{
    private int amount = 0;
    private bool filled = false;

    [SerializeField]
    GameObject drink01;

    [SerializeField]
    GameObject drink02;


    public void Start()
    {
        drink01.SetActive(false);
        drink02.SetActive(false);
    }

    public void FillGlass()
    {
        if(filled == false)
        {
            //Debug.Log("Filling Glass");
            amount += 50;
        }
            
    }


    public void Update()
    {

        if(amount == 50)
        {
            //Debug.Log($"Amount : {amount}");
            drink01.SetActive(true);
        }
        else if (amount >= 100)
        {
            //Debug.Log("Filled");
            //Debug.Log($"Amount : {amount}");
            filled = true;
            drink02.SetActive(true);
        }
    }


    public void EmptyGlass()
    {
        amount = 0;
        filled = false;
        drink01.SetActive(false);
        drink02.SetActive(false);
    }

    public bool GetFilled()
    {
        return filled;
    }

}
