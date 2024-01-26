using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float speed = 400;
    float rot_x;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        // obrót lewo/prawo
        float mouse_x = Input.GetAxis("Mouse X");
        Transform player = transform.parent;
        float rot_y = mouse_x * Time.deltaTime * speed;
        player.Rotate( 0, rot_y, 0);

        //obrót góra/dó³
        float mouse_y = Input.GetAxis("Mouse Y");
        rot_x -= mouse_y * Time.deltaTime * speed;
        rot_x = Mathf.Clamp(rot_x, -90, 55);
        transform.localRotation = Quaternion.Euler( rot_x, 0, 0 );
    }
}
