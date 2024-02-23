using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal otherPortal;

    UnityEngine.Camera myCamera;

    public Renderer renderSurface;
    //public Transform portalCollider;
    Transform playerCam;

    private void Awake()
    {
        myCamera = GetComponentInChildren<UnityEngine.Camera>();
        playerCam = UnityEngine.Camera.main.transform;
    }

    private void Start()
    {
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 0);
        myCamera.targetTexture = rt;
        otherPortal.renderSurface.material.SetTexture("_MainTex", rt);
    }

    private void Update()
    {
        Matrix4x4 m = transform.localToWorldMatrix *
            otherPortal.transform.worldToLocalMatrix *
            playerCam.localToWorldMatrix;

        myCamera.transform.SetPositionAndRotation(m.GetColumn(3), m.rotation);

        //cutout obstacles between camera and portal by shifting cam frustum
        Vector3 cameraToPortal = transform.position - myCamera.transform.position;
        float nearPlane = cameraToPortal.magnitude - 2.4f;
        myCamera.nearClipPlane = Mathf.Clamp(nearPlane, 0.01f, 50);
    }

    public void Deactivate()
    {
        otherPortal.myCamera.enabled = false;
    }

    public void Activate()
    {
        otherPortal.myCamera.enabled = true;
    }
}
