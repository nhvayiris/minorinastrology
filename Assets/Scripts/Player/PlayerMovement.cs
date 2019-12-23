using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDirection;
    private Animator moveAnimator;
    private Quaternion moveRotation = Quaternion.identity;
    private Rigidbody rigidBody;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;

    public float MoveSpeed;
    public float TurnSpeed = 5f;
    public float JumpForce = 7f;

    //private CharacterController controller = null;

    private void Start()
    {
        moveAnimator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        Move();
        
    }
    private void FixedUpdate()
    {
        rigidBody.velocity = moveVelocity;
    }
    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveInput = new Vector3(horizontal, 0f, vertical);
        moveVelocity = moveInput * MoveSpeed;
        moveDirection.Set(horizontal, 0f, vertical);
        moveDirection.Normalize();
        
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool isRunning = hasHorizontalInput || hasVerticalInput;
        moveAnimator.SetBool("IsRunning", isRunning);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, moveDirection, TurnSpeed * Time.deltaTime, 0f);
        moveRotation = Quaternion.LookRotation(desiredForward);

        if (Input.GetKeyDown(KeyCode.Space) && isRunning)
        {
            rigidBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            moveAnimator.Play("Jump", -1, 0f);
        }

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    private void OnAnimatorMove()
    {
        rigidBody.MovePosition(rigidBody.position + moveDirection * moveAnimator.deltaPosition.magnitude);
        rigidBody.MoveRotation(moveRotation);
    }

    
}
