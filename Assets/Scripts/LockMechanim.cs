using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanim : MonoBehaviour
{
    public KeyColor keyColor;
    public DoorMechanim[] doorToOpen;
    Animator animator;
    bool playerInRange;
    bool alreadyOpen = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (GameManager.Instance.HasKey(keyColor))
                {
                    if(!alreadyOpen)
                    {
                        GameManager.Instance.UseKey(keyColor); // zu¿ycie klucza
                        alreadyOpen = true;
                    }
                    animator.SetTrigger("open");
                    foreach (var d in doorToOpen)
                    {
                        d.is_open = !d.is_open;
                    } 
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
