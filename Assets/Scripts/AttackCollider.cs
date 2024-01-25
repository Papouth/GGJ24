using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private PlayerManager playerManager;
    private Animator animator;


    private void Start()
    {
        playerManager = GetComponentInParent<PlayerManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // On soustrait un poisson au joueur
            playerManager.RemoveFish(1);

            animator = other.GetComponentInParent<Animator>();
            animator.ResetTrigger("Rire");
            animator.SetTrigger("Rire");
        }
    }
}