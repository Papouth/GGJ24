using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField] private GameObject[] skins;
    public int num;

    private void Start()
    {
        // Random skins on spawn
        num = Random.Range(0, skins.Length);
        skins[num].SetActive(true);
    }
}