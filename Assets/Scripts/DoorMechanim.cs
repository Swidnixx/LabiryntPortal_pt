using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanim : MonoBehaviour
{
    public Transform door, marker_open, marker_closed;
    public bool is_open;
    public float speed = 1;

    private void Start()
    {
        door.position = is_open ? marker_open.position : marker_closed.position;
    }

    private void Update()
    {
        Vector3 target_pos = is_open ? marker_open.position : marker_closed.position;
        door.position = Vector3.MoveTowards(door.position, target_pos, Time.deltaTime * speed);
    }
}
