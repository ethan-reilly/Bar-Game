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
                   
                    // If player has glass:
                    if (playerPickUp.inHandItem.CompareTag("Glass"))
                    {
                        if (playerPickUp.inHandItem.TryGetComponent(out Glass glass))
                        {
                            // Check if glass is filled
                            if (glass.GetFilled())
                            {
                                npc.Interact(1, playerPickUp.inHandItem);
                                Debug.Log($"Item: " + playerPickUp.inHandItem.name);
                              
                                // @TODO Check if order correct before losing drink
                                // playerPickUp.inHandItem = null;
                            }
                            else
                            {
                                npc.Interact(0, playerPickUp.inHandItem);
                            }
                        }
                    }
                    else if (playerPickUp.inHandItem.CompareTag("Bottle"))
                    {
                        npc.Interact(2, playerPickUp.inHandItem);
                       // playerPickUp.inHandItem = null;

                    }
                }
                    
            }
        }
            
    }
}

    
