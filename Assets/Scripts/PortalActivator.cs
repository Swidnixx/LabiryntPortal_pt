using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActivator : MonoBehaviour
{
    public LayerMask enviroMask;
    Transform player;
    Portal portal;
    Transform teleport;

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        portal = GetComponent<Portal>();
        teleport = GetComponentInChildren<PortalTeleport>().transform;

        StartCoroutine(DetectPlayer());
    }

    IEnumerator DetectPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            Vector3 pos = transform.position + teleport.forward * 0.5f;
            Vector3 portalToPlayer = player.position - pos;
            float distance = portalToPlayer.magnitude;

            Ray ray = new Ray(pos, portalToPlayer.normalized);
            bool hitSmth = Physics.Raycast(ray, distance, enviroMask, QueryTriggerInteraction.Ignore);

            if (hitSmth)
            {
                portal.Deactivate();
            }
            else
            {
                portal.Activate();
            }
        }
    }
}
