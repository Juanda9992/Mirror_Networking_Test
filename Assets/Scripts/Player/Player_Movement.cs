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

    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(xAxis,rb.velocity.y,zAxis).normalized * moveSpeed;        
    }
}
