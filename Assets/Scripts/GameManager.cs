using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameObject textRejouer;
    [SerializeField] private GameObject textStartGame;

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
        textRejouer.SetActive(false);
        textStartGame.SetActive(true);
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
        if (_playersContainer.Count > 0) Timer();

        TextStartHide();
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
            _playersContainer[0].GetComponent<PlayerSkin>().ShowCrown();


            for (int i = 0; i < _playersContainer.Count; i++)
            {
                _playersContainer[i].transform.position = rankList[3 - i].position;
                _playersContainer[i].transform.rotation = rankList[3 - i].localRotation;

                _playersContainer[i].GetComponent<PlayerController>().enabled = false;

                if (_playersContainer.Count == 2)
                {
                    if (i == 1)
                    {
                        _playersContainer[i].GetComponentInChildren<Animator>().SetTrigger("Lose");
                    }
                    else
                    {
                        _playersContainer[i].GetComponentInChildren<Animator>().SetTrigger("Win");
                    }
                }
                else if (_playersContainer.Count == 3)
                {
                    if (i == 2)
                    {
                        _playersContainer[i].GetComponentInChildren<Animator>().SetTrigger("Lose");
                    }
                    else
                    {
                        _playersContainer[i].GetComponentInChildren<Animator>().SetTrigger("Win");
                    }
                }
                else if (_playersContainer.Count == 4)
                {
                    if (i == 3)
                    {
                        _playersContainer[i].GetComponentInChildren<Animator>().SetTrigger("Lose");
                    }
                    else
                    {
                        _playersContainer[i].GetComponentInChildren<Animator>().SetTrigger("Win");
                    }
                }
            }

            textRejouer.SetActive(true);
            Invoke("AutoRestart", 12f);
        }
        else
        {
            _actualTimer = Mathf.Clamp(_actualTimer + Time.deltaTime, 0f, timerInSeconds);
            _uiManager.UpdateTimerUI(_actualTimer, timerInSeconds);
        }
    }

    private void AutoRestart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void TextStartHide()
    {
        if (_playersContainer.Count > 0)
        textStartGame.SetActive(false);
    }

    #endregion
}