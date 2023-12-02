using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class CharacterControllerMovement : MonoBehaviourPunCallbacks
{
    private CharacterController characterController;
    private PhotonView photonView;
    private SpriteRenderer spriteRenderer;

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
    public GameObject player;

    //[SerializeField]
    ////What is the ID of the pooled object that we want as a bullet
    //private string bulletId;

    //public GameObject bullet;
    bool isGrounded;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        photonView = GetComponent<PhotonView>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
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
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.GetComponent<Character>().currHealth -= 1;
            //gameObject.GetComponent<Character>().TakeDamage(1);
            //sheephealth -= 1;
            CheckHP();
        }
    }

    private void CheckHP()
    {
        if (gameObject.GetComponent<Character>().currHealth <= 0)
        {
            Debug.Log("Hi im dead");
            Die();
        }
    }

    private void Die()
    {
        PhotonNetwork.Destroy(this.gameObject);
    }
}
