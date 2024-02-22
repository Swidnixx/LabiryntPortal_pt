using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal otherPortal;

    UnityEngine.Camera myCamera;

    public Renderer renderSurface;
    //public Transform portalCollider;

    private void Awake()
    {
        myCamera = GetComponentInChildren<UnityEngine.Camera>();
    }

    private void Start()
    {
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 0);
        myCamera.targetTexture = rt;
        otherPortal.renderSurface.material.SetTexture("_MainTex", rt);
    }
}
