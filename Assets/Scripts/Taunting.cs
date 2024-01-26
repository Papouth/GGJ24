using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taunting : MonoBehaviour
{
    private Animator animator;
    private InputManager inputManager;


    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        PlayerTaunt();
    }

    private void PlayerTaunt()
    {
        if (inputManager.canTaunt)
        {
            inputManager.canTaunt = false;

            animator.ResetTrigger("Rire");
            animator.SetTrigger("Rire");
        }
    }
}