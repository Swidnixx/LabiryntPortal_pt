using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform receiver;
    Transform player;

    private void FixedUpdate()
    {
        if(player)
        {
            Vector3 portalForward = transform.up;
            Vector3 portalToPlayer = player.position - transform.position;
            float dot = Vector3.Dot(portalForward, portalToPlayer);
            if(dot < 0)
            {
                player.position = receiver.position;

                Vector3 playerForward = player.forward;
                //zamiana kierunku na przestrzeñ portalu do którego wchodzimy
                playerForward = transform.parent.InverseTransformDirection(playerForward);
                //zamiana kierunku na przestrzeñ  portalu którym wychodzimy
                playerForward = receiver.parent.TransformDirection(playerForward);

                player.forward = playerForward;

                player = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }
}
