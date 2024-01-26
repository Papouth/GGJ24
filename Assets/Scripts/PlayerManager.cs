using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Variables

    // Inventory.
    private int _fish;
    
    // Components.
    private GameManager _gameManager;

    #endregion

    #region Properties

    public int Fish => _fish;

    #endregion

    #region Built-In Methods

    /**
     * <summary>
     * Start is called before the first frame update.
     * </summary>
     */
    void Start()
    {
        _gameManager = GameManager.Instance;
    }

    #endregion

    #region Custom Methods

    /**
     * <summary>
     * Add one fish to the player "Inventory".
     * </summary>
     */
    public void AddFish()
    {
        _fish = Mathf.Clamp(_fish + 1, 0, 10);    // Clamp between 0 and 10.
    }


    /**
     * <summary>
     * Remove fish with a quantity given.
     * </summary>
     * <param name="quantity">The quantity to remove.</param>
     */
    public void RemoveFish(int quantity)
    {
        if (_fish > 0)
        _fish = Mathf.Clamp(_fish - quantity, 0, 10);
    }

    #endregion
}