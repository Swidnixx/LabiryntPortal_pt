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

    void Update()
    {
        float inputx = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");

        Vector3 motion = transform.right * inputx + transform.forward * inputy;
        motion = motion.normalized * speed * Time.deltaTime;

        //motion = transform.TransformDirection(motion); // to jest niepotrzebne

        controller.Move( motion );
    }
}
