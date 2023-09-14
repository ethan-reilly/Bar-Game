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
        if(Physics.Raycast(playerCameraTransform.position,
            playerCameraTransform.forward,
            out hit,
            hitRange,
            pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            pickUpUI.SetActive(true);
        }
    }

}
