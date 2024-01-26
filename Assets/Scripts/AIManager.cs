using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    [SerializeField] private GameObject npcPrefab;
    [SerializeField] private int amountNPC;
    private RandomSpawn RS;



    private void Start()
    {
        RS = FindObjectOfType<RandomSpawn>();

        for (int i = 0; i < amountNPC; i++)
        {
            Instantiate(npcPrefab, RS.spawnPoints[i].position, Quaternion.identity, transform);
        }
    }
}