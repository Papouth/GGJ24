using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobing : MonoBehaviour
{
    [SerializeField] private float bobPosSpeed = 0.4f;
    [SerializeField] private float bobPosAmount = 1.2f;


    private void Update()
    {
        Bob();
    }

    private void Bob()
    {
        float addToPos = (Mathf.Sin(Time.time * bobPosSpeed) * bobPosAmount);
        transform.position += Vector3.up * addToPos * Time.deltaTime;
    }
}