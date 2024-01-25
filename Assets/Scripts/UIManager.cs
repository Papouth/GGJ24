using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    #region Variables

    [Header("ScoreBoard Parameters")] 
    [SerializeField] private List<TMP_Text> scoreboardList;
    [SerializeField] private List<Image> jaugeList;
    
    // Instance variable.
    private static UIManager _instance;

    #endregion

    #region Properties

    public static UIManager Instance => _instance;

    #endregion

    #region Built-In Methods.

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

    #endregion

    #region Custom Methods

    /**
     * <summary>
     * Update the scoreboard on the UI.
     * </summary>
     * <param name="players">A list of the players.</param>
     */
    public void UpdateScoreboardUI(List<GameObject> players)
    {
        for(int i = 0; i < players.Count; i++)
        {
            scoreboardList[i].text = "Joueur " + i;
            players[i].GetComponent<PlayerInteract>().spamBarUi = jaugeList[i];
        }
    }

    #endregion

}
