using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Collider playerCollider;

    public Rigidbody2D playerBody;
    
    public Vector3 jumpVector;
    
    public float movementSpeed = 5f;
    
    public bool isGrounded = true;

    public GameObject gun;

    public AudioSource boing;
    
    public AudioSource concentretoi;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<BoxCollider>();
        playerBody = GetComponent<Rigidbody2D>();   
        jumpVector = new Vector3(0.0f, 8.0f, 0.0f);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground" || other.collider.tag == "Platform")
        {
            isGrounded = true;
        }

        if (other.collider.tag == "Trampoline")
        {
            boing.Play();
            Vector3 trampolineJump = new Vector3(0f, 15f, 0f);
            playerBody.AddForce(trampolineJump * 1f, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerBody.AddForce(jumpVector * 1f, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        transform.Translate(movement * Time.deltaTime * movementSpeed);

        if (transform.position.y < -10f || Input.GetButtonDown("Reset Player"))
        {
            concentretoi.Play();
            transform.position = new Vector3(-8.5f, -2f, 0f);
            transform.rotation = Quaternion.Euler(0,0,0);
            isGrounded = true;
        }
    }
}
