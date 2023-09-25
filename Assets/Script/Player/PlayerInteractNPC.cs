using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractNPC : MonoBehaviour
{

    [SerializeField]
    private GameObject interactUI;

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

                    npc.Interact();
                }
            }
            
        }
    }
}
