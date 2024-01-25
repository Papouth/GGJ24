using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Variables
    private InputManager inputManager;
    public float speed = 5f;
    public float rotSpeed = 10f;
    private Quaternion toRot;

    private Rigidbody rb;
    public float forceDash = 4f;
    private float timerDash = 5f;
    private float saveTimer;
    private bool resetDashBool;

    private RandomSpawn RS;
    private Animator animator;
    #endregion


    #region Built-In Methods
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        saveTimer = timerDash;

        RS = FindObjectOfType<RandomSpawn>();

        transform.position = RS.spawnPoints[RS.randInt].position;
    }

    private void Update()
    {
        Movement();

        PlayerRotate();

        Dash();

        if (resetDashBool) ResetDash();
    }
    #endregion


    #region Customs Methods
    private void ResetDash()
    {
        timerDash -= Time.deltaTime;
        if (timerDash <= 0)
        {
            // On reset le Dash
            resetDashBool = false;
            timerDash = saveTimer;
        }
    }

    private void Movement()
    {
        rb.velocity = (rb.velocity + new Vector3(inputManager.movementInput.x, 0, inputManager.movementInput.y) * speed * Time.deltaTime);
    }

    private void PlayerRotate()
    {
        Vector3 moveDir = new Vector3(inputManager.movementInput.x, 0, inputManager.movementInput.y);
        moveDir.Normalize();

        if (rb.velocity != Vector3.zero && moveDir != Vector3.zero)
        {
            toRot = Quaternion.LookRotation(moveDir, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRot, rotSpeed * Time.deltaTime);
        }
    }

    private void Dash()
    {
        if (inputManager.canDash && !resetDashBool)
        {
            inputManager.canDash = false;
            resetDashBool = true;

            animator.SetBool("Glisse", true);

            rb.AddForce(transform.forward * forceDash, ForceMode.Impulse);

            Invoke("DashAnimReset", 1.2f);
        }
    }

    private void DashAnimReset()
    {
        animator.SetBool("Glisse", false);
    }
    #endregion
}