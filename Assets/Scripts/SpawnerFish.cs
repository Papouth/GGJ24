using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFish : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    private int numPoint;
    private float timerSpawnFish;
    [SerializeField] private float minimumTimer = 10f;
    [SerializeField] private float maximumTimer = 20f;
    [SerializeField] private GameObject fishPrefab;
    private GameObject clone;



    private void Start()
    {
        numPoint = Random.Range(0, spawnPoints.Length);
        timerSpawnFish = Random.Range(minimumTimer, maximumTimer);
    }

    private void Update()
    {
        RandomSpawnFish();
    }

    private void RandomSpawnFish()
    {
        timerSpawnFish -= Time.deltaTime;
        if (timerSpawnFish <= 0)
        {
            // On instantie un poisson à un endroit pas occupé, si tout les endroits sont pris, alors pas de spawn de poissons
            if (spawnPoints[numPoint].transform.childCount == 0)
            {
                clone = Instantiate(fishPrefab, spawnPoints[numPoint].transform.position, fishPrefab.transform.rotation, spawnPoints[numPoint].transform);
            }

            // Reset du timer
            timerSpawnFish = Random.Range(minimumTimer, maximumTimer);
            numPoint = Random.Range(0, spawnPoints.Length);
        }
    }
}