using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    private CharacterController characterController;

    private float gravity = -9.8f;

    [SerializeField]
    private float moveSpeed = 4.0f;
    [SerializeField]
    private float gravityScale = 1.0f;
    [SerializeField]
    private float jumpHeight = 3.0f;

    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0.0f)
        {
            velocity.y = -2.0f;
        }

        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.right * xMove) + (transform.forward * zMove);

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity * gravityScale);
        }

        velocity.y += gravity * gravityScale * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}
