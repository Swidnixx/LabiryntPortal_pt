using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    [HideInInspector]
    public Transform receiver;
    Transform player;
    public Portal parentPortal { get; private set; }
    [HideInInspector]
    public Portal otherPortal;

    private void Start()
    {
        parentPortal = GetComponentInParent<Portal>();
    }

    private void FixedUpdate()
    {
        if(player)
        {
            Vector3 portalForward = transform.up;
            Vector3 portalToPlayer = player.position - transform.position;
            float dot = Vector3.Dot(portalForward, portalToPlayer);
            if(dot < 0)
            {
                portalToPlayer = transform.parent.InverseTransformDirection(portalToPlayer);
                portalToPlayer = receiver.parent.TransformDirection(portalToPlayer);
                player.position = receiver.position + portalToPlayer;

                Vector3 playerForward = player.forward;
                //zamiana kierunku na przestrzeñ portalu do którego wchodzimy
                playerForward = transform.parent.InverseTransformDirection(playerForward);
                //zamiana kierunku na przestrzeñ  portalu którym wychodzimy
                playerForward = receiver.parent.TransformDirection(playerForward);

                player.forward = playerForward;

                player = null;

                //Optimalisation
                otherPortal.Activate();
                parentPortal.Deactivate();
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
