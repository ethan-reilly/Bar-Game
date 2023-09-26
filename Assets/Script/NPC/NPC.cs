using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private Transform moveTransformPosition;

    [SerializeField]
    private GameObject inHandItem = null;

    private NavMeshAgent navMeshAgent;
    
    private bool hasDrink = false;

    private bool wantsPint = false;
    private bool wantsBottle = false;

    public void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {

        // Need to randomise what drink wants
        // For now just wants pint
        SetWantsPint(true);
        
        if (wantsPint || wantsBottle)
        {
            if (!hasDrink)
            {
                // navMeshAgent.SetDestination(destination.position);#
                navMeshAgent.destination = moveTransformPosition.position;

                
            }
            
        }
    }

    public void Interact(int x)
    {
        //Debug.Log("Interacting with NPC.");
        if (!hasDrink)
        {
            if (wantsPint)
            {
                if(x == 1)
                {
                    Debug.Log("Correct Drink");
                }
                else
                {
                    Debug.Log("Wrong Drink");
                }
            }

            if(wantsBottle)
            {
                if (x == 2)
                {
                    Debug.Log("Correct Drink");
                }
                else
                {
                    Debug.Log("Wrong Drink");
                }
            }
        }
            
        else
        {
            Debug.Log("NPC already has a drink.");
        }
    }


    // Getters and Setters
    public bool GetDrink()
    {
        return hasDrink;
    }

    public void SetDrink(bool drink)
    {
        hasDrink = drink;
    }

    public bool WantsPint()
    {
        return wantsPint;
    }

    public void SetWantsPint(bool drink)
    {
        wantsPint = drink;
    }

    public bool WantsBottle()
    {
        return wantsBottle;
    }

    public void SetWantsBottle(bool drink)
    {
        wantsBottle = drink;
    }
    
}
