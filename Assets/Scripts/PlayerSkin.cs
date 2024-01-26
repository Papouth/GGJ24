using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField] private GameObject[] skins;
    public int num;
    [SerializeField] private GameObject winnerCrown;


    private void Start()
    {
        num = Random.Range(0, skins.Length);
        if (winnerCrown != null) winnerCrown.SetActive(false);
        // Random skins on spawn
        skins[num].SetActive(true);
    }


    public void ShowCrown()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].SetActive(false);
        }
        winnerCrown.SetActive(true);
    }
}