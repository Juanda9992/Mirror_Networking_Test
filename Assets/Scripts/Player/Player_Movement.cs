using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody rb;
    private float xAxis, zAxis;

    [Header("Jumping Settings")]
    [SerializeField] private float jumpForce;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    private bool canJump = false;

    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(jumpKey))
        {
            canJump = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(xAxis* moveSpeed,rb.velocity.y,zAxis* moveSpeed) ;     
        if(canJump)
        {
            canJump = false;
            rb.velocity = new Vector3(rb.velocity.x,jumpForce,rb.velocity.z);
        }   
    }
}
