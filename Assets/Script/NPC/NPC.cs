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

    [SerializeField]
    private Transform pickUpNpc;

    PlayerPickUp playerPickUp;
    GameManager gameManager;

    private NavMeshAgent navMeshAgent;
    
    private bool hasDrink = false;

    private bool wantsPint = false;
    private bool wantsBottle = false;

    public void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Update()
    {

        // Need to randomise what drink wants
        // For now just wants pint:
        
        SetWantsPint(true);
        //SetWantsBottle(true);
        
        if (wantsPint || wantsBottle)
        {
            if (!hasDrink)
            {
                // navMeshAgent.SetDestination(destination.position);#
                navMeshAgent.destination = moveTransformPosition.position;

                
            }
            
        }
    }

    
    public void Interact(int x, GameObject item)
    {
        //Debug.Log("Interacting with NPC.");
        if (!hasDrink)
        {
            if (wantsPint)
            {
                if(x == 1)
                {
                    Debug.Log("Correct Drink");
                    hasDrink = true;

                    inHandItem = item;
                    //Debug.Log($"Glass Pos A: " + inHandItem.transform.position);

                    //inHandItem.transform.position = Vector3.zero;
                    //Debug.Log($"Glass Pos B: " + inHandItem.transform.position);
                    
                    //inHandItem.transform.rotation = Quaternion.identity;
                    inHandItem.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
                    inHandItem.transform.SetParent(pickUpNpc.transform, false);

                    navMeshAgent.destination = gameManager.GenerateWaypoint().position;
                    inHandItem.layer = 0;

                }
                else if(x == 0)
                {
                    Debug.Log("Wrong Drink");
                }
                else if (x == 2)
                {
                    Debug.Log("Wring Drink");
                }
            }

            if(wantsBottle)
            {
                if (x == 2)
                {
                    Debug.Log("Correct Drink");
                    hasDrink = true;

                    inHandItem = item;
                    //Debug.Log($"Glass Pos A: " + inHandItem.transform.position);

                    //inHandItem.transform.position = Vector3.zero;
                    //Debug.Log($"Glass Pos B: " + inHandItem.transform.position);

                    //inHandItem.transform.rotation = Quaternion.identity;
                    inHandItem.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
                    inHandItem.transform.SetParent(pickUpNpc.transform, false);

                    navMeshAgent.destination = gameManager.GenerateWaypoint().position;

                    inHandItem.layer = 0;
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
