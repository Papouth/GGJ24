using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables.

    [Header("Timer")]
    [SerializeField] private float timerInSeconds;

    // Timer variable.
    private float _actualTimer;

    // Players container.
    public List<GameObject> _playersContainer = new List<GameObject>();

    // Components.
    public UIManager _uiManager;

    // Instance variable.
    private static GameManager _instance;

    [SerializeField] private GameObject camVictoire;
    [SerializeField] private GameObject panelUI;
    [SerializeField] private GameObject podiumPrefab;
    [SerializeField] private GameObject AIPrefabManager;

    [SerializeField] private List<Transform> rankList;
    private bool havestop;
    private int indexPlus;

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
        if (_instance) Destroy(this);
        _instance = this;

        camVictoire.SetActive(false);
        panelUI.SetActive(true);
        podiumPrefab.SetActive(false);
        AIPrefabManager.SetActive(true);

        indexPlus = 0;
    }


    /**
     * <summary>
     * Start is called before the first frame update.
     * </summary>
     */
    void Start()
    {
        _uiManager = UIManager.Instance;
    }


    /**
     * <summary>
     * Update is called every frame, if the MonoBehaviour is enabled.
     * </summary>
     */
    void Update()
    {
        Timer();
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


    #region Timer Management

    /**
     * <summary>
     * Timer manager.
     * </summary>
     */
    private void Timer()
    {
        if (_actualTimer >= timerInSeconds && !havestop)
        {
            havestop = true;
            // TO-DO: Victory Condition.
            camVictoire.SetActive(true);
            panelUI.SetActive(false);

            podiumPrefab.SetActive(true);
            AIPrefabManager.SetActive(false);


            for (int i = 0; i < _playersContainer.Count; i++)
            {
                if (indexPlus == 3) break;

                _playersContainer[i].transform.position = rankList[2 - indexPlus].position;
                _playersContainer[i].transform.rotation = rankList[2 - indexPlus].localRotation;

                indexPlus++;
            }
        }
        else
        {
            _actualTimer = Mathf.Clamp(_actualTimer + Time.deltaTime, 0f, timerInSeconds);
            _uiManager.UpdateTimerUI(_actualTimer, timerInSeconds);
        }
    }

    #endregion
}