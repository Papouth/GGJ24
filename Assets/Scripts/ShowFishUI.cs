using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFishUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> fishList;
    public PlayerManager playerManager;
    private int prevFish;
    private int actualFish;


    private void Start()
    {
        // On cache les poissons au start
        for (int i = 0; i < fishList.Count; i++)
        {
            fishList[i].SetActive(false);
        }

        prevFish = playerManager.Fish;
    }

    private void Update()
    {
        actualFish = playerManager.Fish;

        if (prevFish != actualFish)
        {
            prevFish = actualFish;
            UpdateFishUI(actualFish);
        }
    }

    public void UpdateFishUI(int fish)
    {
        for (int i = 0; i < fishList.Count; i++)
        {
            fishList[i].SetActive(false);
        }

        for (int i = 0; i < fish; i++)
        {
            fishList[i].SetActive(true);
        }
    }
}