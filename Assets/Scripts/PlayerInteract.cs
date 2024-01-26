using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    #region Variables

    [Header("Interaction parameters")] 
    [SerializeField] private float distanceInteraction = 4f;
    
    [Header("Fishing parameters")] 
    [SerializeField] private float fillAmountNeeded = 100f;
    [SerializeField] private float fillAmountAdd = 5f;
    [SerializeField] private float fillAmountRemove = 2.5f;
    [SerializeField] private float timeBetweenFishing = 5f;
    public Image spamBarUi;
    
    // Fishing variables.
    private float _fillAmountActual;
    private bool _isFishing;
    private bool _canFish = true;
    private GameObject _selectedFishingRod;
    
    private InputManager inputManager;
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
        if (Physics.Raycast(transform.position, transform.forward, out var hit, distanceInteraction, 1<<6))
        {
            switch (hit.collider.gameObject.tag)
            {
                case "FishingPol":
                    Fishing(hit.collider.gameObject);
                    break;
                case "Fish":
                    if (inputManager.canInteract)
                    {
                        // On détruit le poisson
                        GetComponent<PlayerManager>().AddFish();
                        Destroy(hit.collider.gameObject);
                        inputManager.canInteract = false;
                    }
                    break;
            }
        }
        else
        {
            ResetSpamBar();
        }
        
        // Random Color - Test Interaction
        if (inputManager.canInteract)
        {
            //spamBarUi.fillAmount += 0.4f;
        }
    }

    /**
     * <summary>
     * Fishing controller.
     * </summary>
     * <param name="fishingRod">The fishing rod.</param>
     */
    private void Fishing(GameObject fishingRod)
    {
        _selectedFishingRod = fishingRod;

        float distancePlayerRod = Vector3.Distance(transform.position, _selectedFishingRod.transform.position);
        bool isInDistance = distancePlayerRod <= distanceInteraction;

        if (!isInDistance)
        {
            ResetSpamBar();
        }
        if (_canFish && isInDistance)
        {
            _isFishing = true;
            
            if (_fillAmountActual >= fillAmountNeeded)
            {
                StartCoroutine(WaitForFish());
                ResetSpamBar();
                GetComponent<PlayerManager>().AddFish();
            }

            if (inputManager.canInteract && _isFishing)
            {
                UpdateSpamBar(fillAmountAdd);
                inputManager.canInteract = false;
            }
            else
                UpdateSpamBar(-fillAmountRemove);
        }
    }
    

    /**
     * <summary>
     * Wait a defined time for the player to fish.
     * </summary>
     */
    private IEnumerator WaitForFish()
    {
        _canFish = false;
        yield return new WaitForSeconds(timeBetweenFishing);
        _canFish = true;
    }


    /**
     * <summary>
     * Update the spam bar.
     * </summary>
     * <param name="amount">The amount to modify.</param>
     */
    private void UpdateSpamBar(float amount)
    {
        _fillAmountActual = Mathf.Clamp(_fillAmountActual + amount, 0f, fillAmountNeeded);
        spamBarUi.fillAmount = _fillAmountActual / fillAmountNeeded;
    }


    /**
     * <summary>
     * 
     * </summary>
     */
    private void ResetSpamBar()
    {
        _isFishing = false;
        _fillAmountActual = 0f;
        spamBarUi.fillAmount = _fillAmountActual / fillAmountNeeded;
    }
    #endregion
}