using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing_Platform : MonoBehaviour
{
    [SerializeField] private float pushForce;

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hit someting");
        if(other.transform.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player_Movement>().SetRagdoll();
            other.gameObject.GetComponent<Rigidbody>().AddForceAtPosition((other.transform.position - transform.position)*pushForce,other.contacts[0].point);
        }     
    }
}
