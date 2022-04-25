using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 50f;
    public LayerMask groundMask;
    public float JumpForce = 12f;

    Vector3 velocity;
    bool isGrounded;
    bool running;
    bool jump;
    bool isWalking = true;
    

    // Update is called once per frame



    void Update()
    {


        jump = Input.GetKeyDown(KeyCode.Space);


        velocity.y += gravity * Time.deltaTime;

        running = false;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -8;
            speed = 6.3f;
 
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        if (Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
        }


        if (isGrounded == true)
        {
           

            if (jump && isGrounded)
            {
                
                velocity.y += JumpForce;
                speed = 4f;

            }
        }

        if (running == true)
        {
        

            Vector3 move = transform.right * x * 1.7f + transform.forward * z * 1.7f;

            controller.Move(move * speed * Time.deltaTime);

            controller.Move(velocity * Time.deltaTime);
        }

        else
        {
           

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            controller.Move(velocity * Time.deltaTime);

        }

        /* Vector3 move = transform.right * x  + transform.forward * z; */

        /*if (isGrounded == true)
        {
            Vector3 move = transform.right * x * 2f + transform.forward * z * 2f;
        }*/

       /* Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime; 

        controller.Move(velocity * Time.deltaTime);*/

       
    }
}
