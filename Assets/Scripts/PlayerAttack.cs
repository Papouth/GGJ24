using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _animator;
    private InputManager inputManager;
    [SerializeField] private GameObject colAttack;
    private bool haveAttack;
    [SerializeField] private float timerResetAttack = 3f;
    private float saveTimer;


    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        inputManager = GetComponent<InputManager>();
        colAttack.SetActive(false);
        saveTimer = timerResetAttack;
    }

    private void Update()
    {
        Attack();

        if (haveAttack)
        {
            ResetAttack();
        }
    }

    private void Attack()
    {
        if (inputManager.canAttack && !haveAttack)
        {
            _animator.SetBool("Attack", true);

            Invoke("ShowWeapon", 0.15f);
            Invoke("HideWeapon", 0.3f);
            haveAttack = true;
        }
    }

    public void ShowWeapon()
    {
        colAttack.SetActive(true);
    }

    public void HideWeapon()
    {
        _animator.SetBool("Attack", false);
        colAttack.SetActive(false);
    }

    private void ResetAttack()
    {
        timerResetAttack -= Time.deltaTime;
        if (timerResetAttack <= 0)
        {
            inputManager.canAttack = false;
            haveAttack = false;
            timerResetAttack = saveTimer;
        }
    }
}