using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Player_Movement : NetworkBehaviour
{
    
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody rb;
    private float xAxis, zAxis;

    [Header("Jumping Settings")]
    [SerializeField] private float jumpForce;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    private bool canJump = false;
    private bool onCrown = false;
    public bool canControl = true;

    void Update()
    {
        if(!isOwned) return;
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(jumpKey))
        {
            canJump = true;
        }

        if(Input.GetKeyDown(KeyCode.E) && onCrown)
        {
            GetCrown();
        }
    }
    [Command]
    private void GetCrown()
    {
        GameObject.FindObjectOfType<Crown>().GetCrownCmd();
    }

    void FixedUpdate()
    {
        if(canControl)
        {
            rb.velocity = new Vector3(xAxis* moveSpeed,rb.velocity.y,zAxis* moveSpeed) ;     
            if(canJump)
            {
                canJump = false;
                rb.velocity = new Vector3(rb.velocity.x,jumpForce,rb.velocity.z);
            }   
        }
    }

    public void SetRagdoll()
    {
        canControl = false;
        rb.freezeRotation = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Crown"))
        {
            onCrown = true;
        }        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Crown"))
        {
            onCrown = false;
        }        
    }

    public override void OnStartLocalPlayer()
    {
        Debug.Log("Player connected");
    }
}
