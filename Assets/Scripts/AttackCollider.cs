using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private PlayerManager playerManager;
    private Animator animator;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerManager = other.GetComponent<PlayerManager>();
            // On soustrait un poisson au joueur
            playerManager.RemoveFish(1);

            animator = other.GetComponentInChildren<Animator>();
            animator.ResetTrigger("Rire");
            animator.SetTrigger("Rire");
        }
    }
}