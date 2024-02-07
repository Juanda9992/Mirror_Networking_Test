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
    [SerializeField] private AudioSource thisSource;
    private bool canJump = false;
    private bool onCrown = false;
    public bool canControl = true;

    private bool isFalling;
    private Vector3 initialPos;

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
        if(transform.position.y < -15 && !isFalling)
        {
            isFalling = true;
            StartCoroutine("ResetPos");
        }
    }

    private IEnumerator ResetPos()
    {
        yield return new WaitForSeconds(1.5f);
        transform.position = initialPos;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        isFalling = false;
        ResetRagDoll();
    }

    private void ResetRagDoll()
    {
        rb.freezeRotation = true;
        transform.rotation = Quaternion.Euler(Vector3.up * transform.rotation.y);
        rb.velocity = Vector3.zero;
        canControl = true;
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
        Invoke("ResetRagDoll",2);
        thisSource.Play();
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
        initialPos = transform.position;
        Debug.Log("Player connected");
    }
}
