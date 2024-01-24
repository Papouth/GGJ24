using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    private InputManager inputManager;
    public float speed = 5;

    private Rigidbody rb;
    #endregion


    #region Built-In Methods
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
    }
    #endregion


    #region Customs Methods
    private void Movement()
    {
        //rb.MovePosition(transform.position + new Vector3(inputManager.movementInput.x, 0, inputManager.movementInput.y) * speed * Time.deltaTime);
        rb.velocity = (rb.velocity + new Vector3(inputManager.movementInput.x, 0, inputManager.movementInput.y) * speed * Time.deltaTime);
    }
    #endregion
}