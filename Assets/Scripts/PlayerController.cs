using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    private InputManager inputManager;
    public float speed = 5;
    #endregion


    #region Built-In Methods
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        Movement();
    }
    #endregion


    #region Customs Methods
    private void Movement()
    {
        transform.Translate(new Vector3(inputManager.movementInput.x, 0, inputManager.movementInput.y) * speed * Time.deltaTime);
    }
    #endregion
}