using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal otherPortal;

    UnityEngine.Camera myCamera;

    public Renderer renderSurface;
    Transform playerHead;

    [HideInInspector]
    public PortalTeleport pt;

    private void Awake()
    {
        myCamera = GetComponentInChildren<UnityEngine.Camera>();
        pt = GetComponentInChildren<PortalTeleport>();
    }

    private void Start()
    {
        otherPortal.pt.receiver = pt.transform;

        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 0);
        myCamera.targetTexture = rt;
        otherPortal.renderSurface.material.SetTexture("_MainTex", rt);

        playerHead = UnityEngine.Camera.main.transform;
    }

    private void Update()
    {
        Matrix4x4 m = transform.localToWorldMatrix *
            otherPortal.transform.worldToLocalMatrix *
            playerHead.localToWorldMatrix;

        myCamera.transform.SetPositionAndRotation(m.GetPosition(), m.rotation);

        Vector3 cameraToPortal = transform.position - myCamera.transform.position;
        float nearPlane = cameraToPortal.magnitude - 2.5f;
        nearPlane = Mathf.Clamp(nearPlane, 0.01f, 50);
        myCamera.nearClipPlane = nearPlane;
    }
}
