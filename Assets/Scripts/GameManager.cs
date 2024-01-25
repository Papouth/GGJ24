using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Variables.

    // Players container.
    public List<GameObject> _playersContainer = new List<GameObject>();

    // Components.
    public UIManager _uiManager;
    
    // Instance variable.
    private static GameManager _instance;

    #endregion

    #region Properties

    public static GameManager Instance => _instance;

    #endregion

    #region Built-In Methods

    /**
     * <summary>
     * Awake is called when an enabled script instance is being loaded.
     * </summary>
     */
    void Awake()
    {
        if(_instance) Destroy(this);
        _instance = this;
    }
    
    
    /**
     * <summary>
     * Start is called before the first frame update.
     * </summary>
     */
    void Start()
    {
        _uiManager = UIManager.Instance;
        _uiManager.UpdateScoreboardUI(_playersContainer);
    }

    #endregion

    #region Players Methods

    /**
     * <summary>
     * Add the player to the container.
     * </summary>
     * <param name="player">The actual Player.</param>
     */
    public void AddPlayerToContainer(GameObject player)
    {
        _playersContainer.Add(player);
    }

    #endregion

    #region Score Methods

    /**
     * <summary>
     * Update the players list order.
     * </summary>
     */
    public void UpdateList()
    {
        _playersContainer = _playersContainer.OrderByDescending(o => o.GetComponent<PlayerManager>().Fish).ToList();
        _uiManager.UpdateScoreboardUI(_playersContainer);
    }

    #endregion

}
