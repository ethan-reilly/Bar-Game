using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code based on https://www.youtube.com/watch?v=_QajrabyTJc&t=1003s

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    [SerializeField]
    public float speed = 12f; // Player speed

    [SerializeField]
    public float jumpHeight = 3f; // Jump height

    Vector3 velocity; // Velocity for gravity
    public float gravity = -9.81f; // Gravity

    // Resetting the velocity when the player is on the ground
    public Transform groundCheck; // Ground check empty
    public float groundDistance = 0.4f; // Ground check radius
    public LayerMask groundMask; // Ground layer

    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance,
            groundMask); // Check if the player is on the ground

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset the velocity
        }


        float xMov = Input.GetAxis("Horizontal");
        float zMov = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xMov + transform.forward * zMov;

        //Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * (speed * 1.4f) * Time.deltaTime);
            
        }
            controller.Move(move * speed * Time.deltaTime);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Jump formula
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); // Apply gravity, Time.deltaTime multiplied twice because
                                                    // time is squared

     

    }
}
