using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    // Update is called once per frame
    void Update()
    {
        Vector3 portalOffest = playerCamera.position - otherPortal.position;
        transform.position = portal.position + portalOffest;

        float angleOfDifferenceBetweenPortals = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angleOfDifferenceBetweenPortals, Vector3.up);
        Vector3 newCameraDir = portalRotationDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDir, Vector3.up);

    }
}
