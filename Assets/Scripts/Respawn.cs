using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    private PlayerManager PM;
    private GameObject IAClone;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PM = other.GetComponent<PlayerManager>();

            Invoke("RespawnPlayer", 2f);

            // Si joueur possède plus d'un poisson, on lui retire
            if (PM.Fish > 0) PM.RemoveFish(1);

            // On réinstantie sur un endroit random de la carte le poisson que le joueur viens de perdre
        }
        else if (other.CompareTag("IA"))
        {
            Invoke("RespawnIA", 2f);

            IAClone = other.gameObject;
        }
    }

    private void RespawnPlayer()
    {
        int randPoint = Random.Range(0, spawnPoints.Length);

        PM.GetComponent<Rigidbody>().velocity = Vector3.zero;

        PM.transform.rotation = Quaternion.identity;

        PM.transform.position = spawnPoints[randPoint].position;
    }

    private void RespawnIA()
    {
        int randPoint = Random.Range(0, spawnPoints.Length);

        IAClone.transform.rotation = Quaternion.identity;

        IAClone.transform.position = spawnPoints[randPoint].position;
    }
}