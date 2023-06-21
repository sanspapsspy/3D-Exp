using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public float speed = 10f;

    public float run = 20f;

    public CharacterController characterController;

    Vector3 move;

    Vector3 velocity;

    public float gravity = -22f;

    public Transform groundCheck;

    public float groundDistance = 0.5f;

    public LayerMask groundMask;

    bool isGrounded;

    public float jumpHight = 5f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //move = transform.right * horizontal + transform.forward * vertical;
        if (isGrounded == true)
        {
            move = transform.right * horizontal + transform.forward * vertical;
        }

        //characterController.Move(move * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded == true)
        {
            characterController.Move(move * run * Time.deltaTime);
        }
        else
        {
            characterController.Move(move * speed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 1)
        {
            velocity.y = -2f;
        }
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            if (isGrounded == true)
            {
                velocity.y = Mathf.Sqrt(jumpHight * -2 * gravity);
            }
        }
    }
}
