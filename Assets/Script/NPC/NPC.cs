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

    [SerializeField]
    private Animator animator;
    
    private bool hasDrink = false;

    private bool wantsPint = false;
    private bool wantsBottle = false;

    //UI Stuff
    [SerializeField]
    private GameObject UIPint;
        
    [SerializeField]
    private GameObject UIBottle;

    [SerializeField]
    private GameObject UIThanks;

    public void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerPickUp = GameObject.Find("First Person Player").GetComponent<PlayerPickUp>();
        //animator = GetComponent<Animator>();

        //Randomise what drink they want
        int drink = Random.Range(0, 2);
        if (drink == 0)
        {
            wantsPint = true;
        }
        else
        {
            wantsBottle = true;
        }
    }

    public void Update()
    {

        
        if (wantsPint || wantsBottle)
        {
            if (!hasDrink)
            {
                // navMeshAgent.SetDestination(destination.position);#
                navMeshAgent.destination = moveTransformPosition.position;

                
            }
            
        }
        
        if(navMeshAgent.remainingDistance > 0.1f)
        {
            //Debug.Log("Walking");
            animator.SetBool("isWalking", true);
        }
        else
        {
            //Debug.Log("Idle");
            animator.SetBool("isWalking", false); 
        }
    }

    public void Interact(int x)
    {
        if(!hasDrink)
        {
            if(wantsPint)
            {
                UIPint.SetActive(true);
                Invoke("UIHandler", 2f);
                Debug.Log("Wrong Drink");
            }

            if(wantsBottle)
            {
                UIBottle.SetActive(true);
                Invoke("UIHandler", 2f);
                Debug.Log("Wrong Drink");
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
                    UIThanks.SetActive(true);

                    playerPickUp.AddMoney();
                    Invoke("UIHandler", 2f);
                    
                    Invoke("NextCustomer", Random.Range(3f, 5f));
                    //gameManager.NextCustomer();
                }
                else if(x == 0)
                {
                    UIPint.SetActive(true);
                    Invoke("UIHandler", 2f);
                    Debug.Log("Wrong Drink");
                }
                else if (x == 2)
                {
                    UIPint.SetActive(true);
                    Invoke("UIHandler", 2f);
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
                    UIThanks.SetActive(true);

                    playerPickUp.AddMoney();
                    Invoke("UIHandler", 2f);

                    Invoke("NextCustomer", Random.Range(3f, 5f));
                    //gameManager.NextCustomer();

                }
                else
                {
                    UIBottle.SetActive(true);
                    Invoke("UIHandler", 2f);
                    Debug.Log("Wrong Drink");
                }
            }
        }
            
        else
        {
            Debug.Log("NPC already has a drink.");
        }
    }

    public void NextCustomer()
    {
        gameManager.NextCustomer();
    }
    
    public void UIHandler()
    {
        UIPint.SetActive(false);
        UIBottle.SetActive(false);
        UIThanks.SetActive(false);
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
