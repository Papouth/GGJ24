using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    #region Variables

    [Header("Interaction Parameters")] 
    [SerializeField] private float distanceInteraction;
    
    private InputManager inputManager;
    private MeshRenderer rend;
    #endregion


    #region Built-In Methods
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        rend = GetComponent<MeshRenderer>();
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
            inputManager.canInteract = false;
            rend.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
            
            if (Physics.Raycast(transform.position, Vector3.forward, out var hit, distanceInteraction, 1<<6))
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "FishingPol":
                        Debug.Log("Je pêche.");
                        // Do Things.
                        break;
                    case "Fish":
                        Debug.Log("Pîchon");
                        // Do Things.
                        break;
                }
            }
        }
    }
    #endregion
}