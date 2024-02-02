using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask walkableMask;
    public float regularSpeed = 7.77f, fastSpeed = 14.14f, slowSpeed = 4.5f;
    public float jumpSpeed = 9.81f;

    CharacterController controller;
    float speed;
    float velocity_y;
    bool grounded;
    bool input_jump;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Walking_Jumping();
        GroundTest();
    }

    void GroundTest()
    {
        float sphereCast_radius = 0.5f;
        Vector3 origin = transform.position 
            + Vector3.down * (controller.height * 0.5f - sphereCast_radius);
        Ray ray = new Ray(origin, Vector3.down);
        RaycastHit info;
        bool grounded = Physics.SphereCast(ray, sphereCast_radius, out info, 0.1f, walkableMask);
    
        if(grounded)
        {
            switch (info.collider.tag)
            {
                case "Fast": speed = fastSpeed; break;
                case "Slow": speed = slowSpeed; break;
                case "Jump": velocity_y = jumpSpeed; break;
                default: speed = regularSpeed; break;
            }
        }
    }
    void Walking_Jumping()
    {
        //Chodzenie
        float inputx = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");

        Vector3 motion = transform.right * inputx + transform.forward * inputy;
        motion = motion.normalized * speed * Time.deltaTime;

        //Grawitacja
        //input_jump |= Input.GetButtonDown("Jump"); // jumping turned off
        grounded = velocity_y < 0 && ((controller.collisionFlags & CollisionFlags.Below) != 0);
        if(grounded)
        {
            if(input_jump)
            {
                input_jump = false;
                //velocity_y = 7; // we turned off jumping
            }
            else
            {
                velocity_y = 0;
            }
        }
        else
        {
            velocity_y += Physics.gravity.y * Time.deltaTime;
        }

        motion.y = velocity_y * Time.deltaTime;
        controller.Move(motion);
    }
}
