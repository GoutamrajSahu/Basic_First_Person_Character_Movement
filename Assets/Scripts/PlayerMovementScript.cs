using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] public CharacterController controller;
    [SerializeField] float speed = 12f;
    [SerializeField] float gravity = -9.5f;
    private Vector3 velocity;

    [SerializeField] Transform groundCheck;
    private float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] private bool isGrounded;

    float jumpHeight = 3f;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // will create a invisible sphear at the bottom of the player to check if it is touhing to the given layer(ground) and on touch it will return true else false.

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(speed * Time.deltaTime * move);

        velocity.y += gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);// Formula fro jump V = sqrt(jumpHeight * -2 * gravity)
        }

        controller.Move(velocity * Time.deltaTime); // Formula fro freefall deltaY = (1/2) * gravity * (time*time) 
    }
}
