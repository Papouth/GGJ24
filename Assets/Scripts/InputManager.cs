using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region Variables
    public Vector2 movementInput;
    public bool canInteract;
    public bool canDash;
    #endregion


    #region Functions
    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnInteract(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            canInteract = true;
        }
        else canInteract = false;
    }

    public void OnDash(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            canDash = true;
        }
        else canDash = false;
    }
    #endregion
}