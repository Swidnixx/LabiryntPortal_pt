using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public float speed = 100;
    public AudioClip sfxClip;

    private void Update()
    {
        transform.Rotate(0, Time.deltaTime * speed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Pick();
        }
    }

    protected virtual void Pick()
    {
        SoundManager.Instance.PlaySFX(sfxClip);
        Destroy(gameObject);
    }
}
