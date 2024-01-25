using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] private float modifiateGravity = -4f;
    private Rigidbody rb;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rb = other.GetComponent<Rigidbody>();
            rb.AddForce(other.transform.forward * rb.mass * modifiateGravity);
        }
    }
}