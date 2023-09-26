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
                    Debug.Log("Interacting with NPC.");

                    if (playerPickUp.inHandItem.CompareTag("Glass"))
                            {
                        //npc.Interact();
                    }
                    
                }
            }
            
        }
    }

    
}
