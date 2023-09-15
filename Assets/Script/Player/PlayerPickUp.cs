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
    private Transform playerCameraTransform;

    [SerializeField]
    private GameObject pickUpUI;

    [SerializeField]
    private Transform pickUpParent;

    [SerializeField]
    private GameObject inHandItem;

    [SerializeField]
    [Min(1)]
    private float hitRange = 3;

    private RaycastHit hit;


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
            return;
        }
        
        
        if(Physics.Raycast(playerCameraTransform.position,
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
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();

            inHandItem = hit.collider.gameObject;
            inHandItem.transform.position = Vector3.zero;
            //inHandItem.transform.rotation = Quaternion.identity;
            inHandItem.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
            inHandItem.transform.SetParent(pickUpParent.transform, false);

            //Debug.Log("In hand item " + inHandItem.transform.localPosition);
            //Debug.Log("Pick up slot " + pickUpParent.transform.position);

            if (rb != null)
            {
                rb.isKinematic = true;
            }

            return;
        }
    }
     
}

