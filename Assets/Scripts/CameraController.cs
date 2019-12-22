using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransformtarget;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool hasDirectionView = true;

    private void LateUpdate()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (playerTransformtarget == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = playerTransformtarget.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = playerTransformtarget.position + offsetPosition;
        }

        // compute rotation
        if (hasDirectionView)
        {
            transform.LookAt(playerTransformtarget);
        }
        else
        {
            transform.rotation = playerTransformtarget.rotation;
        }
    }
}
