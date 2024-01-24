using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Variables.

    // Players container.
    private List<GameObject> _playersContainer;

    // Instance variable.
    private static GameManager _instance;

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


    /**
     * <summary>
     * Increment the player' fish counter.
     * </summary>
     * <param name="player">The actual Player.</param>
     */
    public void AddFishToPlayer(GameObject player)
    {
        // TO-DO: Make the function.
        //player.GetComponent<PlayerController>().AddFish();
    }

    #endregion

}
