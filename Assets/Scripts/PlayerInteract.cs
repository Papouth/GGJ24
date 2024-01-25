using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    #region Variables
    private InputManager inputManager;
    [SerializeField] private float distanceInteraction = 4;
    #endregion


    #region Built-In Methods
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        Interaction();
    }
    #endregion


    #region Customs Methods
    private void Interaction()
    {
        // Random Color - Test Interaction
        if (inputManager.canInteract)
        {         
            if (Physics.Raycast(transform.position, Vector3.forward, out var hit, distanceInteraction, 1<<6))
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "FishingPol":
                        Debug.Log("Je pêche.");
                        GetComponent<PlayerManager>().AddFish();
                        break;
                    case "Fish":
                        Debug.Log("Pîchon");
                        GetComponent<PlayerManager>().AddFish();
                        break;
                }
            }
        }
    }
    #endregion
}