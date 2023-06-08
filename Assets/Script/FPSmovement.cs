    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSmovement : MonoBehaviour
{
    public CharacterController controller;
    public float walkspeed = 10f;
    public float gravity = -9.81f;
    public float jumpheight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool grounded;

    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * walkspeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
                velocity.y += gravity * Time.deltaTime;
                controller.Move(velocity * Time.deltaTime);
    }
}