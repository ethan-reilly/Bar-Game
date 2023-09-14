using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    
    [SerializeField]
    public float mouseSensitivity = 100f; // Mouse sensitivity

    public Transform playerBody;
    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor in the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse X axis
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        // Get the mouse Y axis
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; // Rotate the camera on the X axis
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the camera on the X axis


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotate the camera on the X axis
        playerBody.Rotate(Vector3.up * mouseX); // Rotate the player body on the Y axis

    }
}
