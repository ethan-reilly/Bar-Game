using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Code based off https://www.youtube.com/watch?v=pzaxC-P3sgs&list=PLmpobDAilT3LUMrSuO25RgJSiGq3Z3ofJ&index=54&t=98s

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private LayerMask tapLayerMask;
    
    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private GameObject pickUpUI;

    [SerializeField]
    private Transform pickUpParent;

    [SerializeField]
    public GameObject inHandItem;

    [SerializeField]
    private Transform glassesEmpty;

    [SerializeField]
    private Transform bottlesEmpty;

    [SerializeField]
    [Min(1)]
    private float hitRange = 4;

    private RaycastHit hit;
    private RaycastHit hit2;


    private void Update()
    {
        
        Debug.DrawRay(playerCameraTransform.position, 
            playerCameraTransform.forward * hitRange, Color.red);

        if (hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);
        }
        
        if (inHandItem != null)
        {
            //Dropping
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Drop();
            }
            
            if (Physics.Raycast(playerCameraTransform.position,
           playerCameraTransform.forward,
           out hit2,
           hitRange,
           tapLayerMask) && inHandItem.CompareTag("Glass"))
            {
                //Debug.Log("Tap");
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);

                if (inHandItem.CompareTag("Glass") && Input.GetKeyDown(KeyCode.Q))
                //if (inHandItem == inHandItem.GetComponent<Glass>() && Input.GetKeyDown(KeyCode.Q))
                {
                    inHandItem.GetComponent<Glass>().FillGlass();
                }
                
            }

            return;
        }


        if (Physics.Raycast(playerCameraTransform.position,
            playerCameraTransform.forward,
            out hit,
            hitRange,
            pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            pickUpUI.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("Press 'E' "  + hit.collider.name);
            Interact();
            
        }

    }
 
    private void Interact()
    {
        //   Debug.Log("Picking up " + hit.collider.name);
        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<Glass>() || hit.collider.GetComponent<Bottle>())
            {
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();

                inHandItem = hit.collider.gameObject;
                
                inHandItem.transform.position = Vector3.zero;
                //inHandItem.transform.rotation = Quaternion.identity;
                inHandItem.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
                inHandItem.transform.SetParent(pickUpParent.transform, false);

                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                return;
            }

            
        }
    }
     

         private void Drop()
        { 
            //Dropping the item
            if (inHandItem !=null)
            {
                if (inHandItem.name == "Glass")
                    inHandItem.transform.SetParent(glassesEmpty);
                else
                    inHandItem.transform.SetParent(bottlesEmpty);

                inHandItem = null;
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }
             }
    
          }
             
}
