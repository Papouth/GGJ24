using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField] private GameObject[] skins;
    public int num;
    [SerializeField] private GameObject winnerCrown;


    private void Awake()
    {
        num = Random.Range(0, skins.Length);

        skins[num].SetActive(true);

        if (winnerCrown != null) winnerCrown.SetActive(false);
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