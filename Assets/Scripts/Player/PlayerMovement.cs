using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Vector3 moveDirection;
    private Rigidbody rigidBody;

    private float moveSpeed = 0f;
    private float walkSpeed = 5f;
    private float runSpeed = 7f;
    private float crouchSpeed = 3f;
    private float jumpSpeed = 20f;

    private float gravity = 3f;

    

    private CharacterController controller = null;
    private PlayerStats playerStats = null;
     
    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (controller.isGrounded)
        {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

            moveDirection = new Vector3(moveX, 0f, moveZ);
            moveDirection.Normalize();
            moveDirection = transform.TransformDirection(moveDirection);

            if(!Input.GetKey(KeyCode.LeftShift) && moveDirection == Vector3.zero)
            {
                Idle();
            }
            if (!Input.GetKey(KeyCode.LeftShift) && moveDirection == Vector3.zero)
            {
                Walk();
            }
            if (!Input.GetKey(KeyCode.LeftShift) && moveDirection == Vector3.zero)
            {
                Jump();
            }

            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        moveDirection.y -= gravity;

        controller.Move(moveDirection * Time.deltaTime);
    }

    

    private void Jump()
    {
        moveDirection.y += jumpSpeed;
    }

    private void Idle()
    {
        /*if (!playerStats.idleing)
        {
            playerStats.idleing = true;
            playerStats.walking = false;
            playerStats.running = false;
        }

        moveSpeed = walkSpeed;*/
    }

    private void Walk()
    {
        /*if (!playerStats.walking)
        {
            playerStats.idleing = false;
            playerStats.walking = true;
            playerStats.running = false;
        }

        moveSpeed = walkSpeed;*/
    }

    private void Run()
    {
        /*if (!playerStats.running)
        {
            playerStats.idleing = false;
            playerStats.walking = false;
            playerStats.running = true;
        }

        moveSpeed = runSpeed;
        playerStats.RemoveStamina(playerStats.decreaseStaminaAmount * Time.detaTime);*/
    }
}
