using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 7.7f;
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    float velocity_y;
    bool grounded;
    bool input_jump;
    void Update()
    {
        //Chodzenie
        float inputx = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");

        Vector3 motion = transform.right * inputx + transform.forward * inputy;
        motion = motion.normalized * speed * Time.deltaTime;

        //motion = transform.TransformDirection(motion); // to jest niepotrzebne


        //Grawitacja
        input_jump |= Input.GetButtonDown("Jump");
        grounded = velocity_y < 0 && ((controller.collisionFlags & CollisionFlags.Below) != 0);
        if(grounded)
        {
            if(input_jump)
            {
                input_jump = false;
                velocity_y = 7;
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
