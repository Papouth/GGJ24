using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public int randInt;


    public void RandomInt()
    {
        randInt = Random.Range(0, spawnPoints.Length);
    }

    public void Update()
    {
        RandomInt();
    }
}