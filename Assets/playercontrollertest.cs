using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrollertest : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody PlayerRb;
    private Vector3 MoveInput;
    private Vector3 MoveVelocity;

    private Camera mainCamera;

    private void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }
    void Update()
    {
        MoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        MoveVelocity = MoveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x,transform.position.y,pointToLook.z));
        }

    }

    void FixedUpdate()
    {
        PlayerRb.velocity = MoveVelocity;
    }
}
