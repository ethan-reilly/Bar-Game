using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private Transform moveTransformPosition;

    private NavMeshAgent navMeshAgent;
    
    private bool hasDrink = false;

    private bool wantsDrink = false;

    public void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        if (true)
        {
            // navMeshAgent.SetDestination(destination.position);#
            navMeshAgent.destination = moveTransformPosition.position;
            
        }
    }

    public void Interact()
    {
       //Debug.Log("Interacting with NPC.");
       
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

    public bool WantsDrink()
    {
        return wantsDrink;
    }

    public void SetWantsDrink(bool drink)
    {
        wantsDrink = drink;
    }
}
