using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private float modifiateGravity = -4f;
    private Rigidbody rb;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rb = other.GetComponent<Rigidbody>();
            //rb.velocity = Vector3.zero;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rb.AddForce(Vector3.up * rb.mass * modifiateGravity);
        }
    }
}