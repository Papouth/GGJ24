using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotation : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
    }
}