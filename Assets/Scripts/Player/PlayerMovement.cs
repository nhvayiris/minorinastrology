using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDirection;
    private Animator moveAnimator;
    private Quaternion moveRotation = Quaternion.identity;
    private Rigidbody rigidBody;

    public float turnSpeed = 5f;
    public float jumpForce = 7f;

    //private CharacterController controller = null;

    private void Start()
    {
        moveAnimator = GetComponent<Animator>();
        //controller = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection.Set(horizontal, 0f, vertical);
        moveDirection.Normalize();
        
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool isRunning = hasHorizontalInput || hasVerticalInput;
        moveAnimator.SetBool("IsRunning", isRunning);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, moveDirection, turnSpeed * Time.deltaTime, 0f);
        moveRotation = Quaternion.LookRotation(desiredForward);

        if (Input.GetKeyDown(KeyCode.Space) && isRunning)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            moveAnimator.Play("Jump", -1, 0f);
        }

    }

    private void OnAnimatorMove()
    {
        rigidBody.MovePosition(rigidBody.position + moveDirection * moveAnimator.deltaPosition.magnitude);
        rigidBody.MoveRotation(moveRotation);
    }

    /*private void JumpAtAngle()
    {
        float gravity = Physics.gravity.magnitude;
        // Selected angle in radians
        float angle = initialAngle * Mathf.Deg2Rad;

        // Positions of this object and the target on the same plane
        Vector3 planarTarget = new Vector3(moveDirection.x, 0, moveDirection.z);
        Vector3 planarPostion = new Vector3(transform.position.x, 0, transform.position.z);

        // Planar distance between objects
        float distance = Vector3.Distance(planarTarget, planarPostion);
        // Distance along the y axis between objects
        float yOffset = transform.position.y - moveDirection.y;

        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        // Rotate our velocity to match the direction between the two objects
        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

        // Fire!
        rigidBody.velocity = finalVelocity;

        // Alternative way:
        // rigid.AddForce(finalVelocity * rigid.mass, ForceMode.Impulse);
    
    }*/

}
