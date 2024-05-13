using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float gravity = -9.81f;
    public float playerSpeed = 5.0f;
    public float jumpHeight = 1.5f;
    public float acceleration = 1f; // The rate at which the player's speed increases
    public float maxSpeed = 10f; // The maximum speed the player can reach
    public float deceleration = 0.9f; // The rate at which the player slows down when not moving


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        // Calculate the speed of the player

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }
    public void ProcessMovement(Vector2 direction)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = direction.x;
        moveDirection.z = direction.y;

        if (moveDirection != Vector3.zero)
        {
            // Increase the player's speed
            playerSpeed += acceleration * Time.deltaTime;
            playerSpeed = Mathf.Min(playerSpeed, maxSpeed);
        }
        else
        {
            // Gradually slow down the player (slide)
            playerSpeed = Mathf.Lerp(playerSpeed, 0, deceleration * Time.deltaTime);
        }

        controller.Move(transform.TransformDirection(moveDirection) * playerSpeed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -0f;
        }

        controller.Move(playerVelocity * Time.deltaTime);

        // Remove debug logs
        // Debug.Log("PlayerMotor.ProcessMovement: " + playerVelocity.y);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

}
