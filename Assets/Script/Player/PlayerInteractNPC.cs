using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractNPC : MonoBehaviour
{
    
    [SerializeField]
    private GameObject interactUI;

    PlayerPickUp playerPickUp;

    void Awake()
    {
        playerPickUp = GetComponent<PlayerPickUp>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;

            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in colliderArray)
            {
               if(collider.TryGetComponent(out NPC npc))
                {
                    // Debug.Log("Interacting with NPC.");

                    if (playerPickUp.inHandItem == null)
                    {
                        npc.Interact(0);
                    }
                    // If player has glass:
                    else if (playerPickUp.inHandItem.CompareTag("Glass"))
                    {
                        if (playerPickUp.inHandItem.TryGetComponent(out Glass glass))
                        {
                            // Check if glass is filled
                            if (glass.GetFilled())
                            {
                                if(npc.WantsPint() & !npc.GetDrink())
                                {
                                    npc.Interact(1, playerPickUp.inHandItem);
                                    //Debug.Log($"Item: " + playerPickUp.inHandItem.name);
                                    playerPickUp.inHandItem = null;

                                    Debug.Log($"inHandItem" + playerPickUp.inHandItem);
                                }
                                else 
                                {
                                    npc.Interact(1, playerPickUp.inHandItem);
                                }
                            }
                            else
                            {
                                npc.Interact(0, playerPickUp.inHandItem);
                            }
                        }
                    }
                    else if (playerPickUp.inHandItem.CompareTag("Bottle"))
                    {
                        if (npc.WantsBottle() & !npc.GetDrink())
                        {
                            npc.Interact(2, playerPickUp.inHandItem);
                            playerPickUp.inHandItem = null;
                        }

                        if (npc.WantsPint() & !npc.GetDrink())
                        {
                            npc.Interact(2, playerPickUp.inHandItem);
                        }
                    }
                
                }
                    
            }
        }
            
    }
}

    
