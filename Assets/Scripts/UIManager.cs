using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIManager : MonoBehaviour
{
    #region Variables

    [Header("ScoreBoard Parameters")]
    [SerializeField] private List<GameObject> backgroundList;
    [SerializeField] private List<GameObject> profilePicList;
    [SerializeField] private List<TextMeshProUGUI> classementTextList;
    [SerializeField] private List<GameObject> imageWinList;
    private List<GameObject> saveJoueur = new List<GameObject>();

    [Header("Timer Parameters")]
    [SerializeField] private Image imgTimer;
    [SerializeField] private Color colorStart;
    [SerializeField] private Color colorEnd;

    [SerializeField] private List<Image> jaugeList;
    [SerializeField] private List<Sprite> skinsImgList;
    private int indexPLayer = 0;

    // Instance variable.
    private static UIManager _instance;
    [SerializeField] private GameManager _gameManager;


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
        if (_instance) Destroy(this);
        _instance = this;

        for (int i = 0; i < backgroundList.Count; i++)
        {
            backgroundList[i].SetActive(false);
        }

        for (int i = 0; i < imageWinList.Count; i++)
        {
            imageWinList[i].SetActive(false);
        }
    }

    #endregion

    #region Custom Methods

    /**
     * <summary>
     * Update the scoreboard on the UI.
     * </summary>
     * <param name="players">A list of the players.</param>
     */
    public void UpdateScoreboardUI(GameObject player, int skinChiffre)
    {
        backgroundList[indexPLayer].SetActive(true);

        // On met le bon skin sur le background du joueur
        profilePicList[indexPLayer].GetComponent<Image>().sprite = skinsImgList[skinChiffre];

        // On attribue la jauge du joueur
        player.GetComponent<PlayerInteract>().spamBarUi = jaugeList[indexPLayer];


        // On attribue le player manager au fishUI correspondant
        backgroundList[indexPLayer].GetComponentInChildren<ShowFishUI>().playerManager = player.GetComponent<PlayerManager>();

        saveJoueur.Add(player);

        indexPLayer++;
    }

    /**
     * <summary>
     * Update the timer on the UI.
     * </summary>
     * <param name="timerActual">The actual timer.</param>
     * <param name="timerMax">The max value.</param>
     */
    public void UpdateTimerUI(float timerActual, float timerMax)
    {
        imgTimer.fillAmount = timerActual / timerMax;
        StartCoroutine(ChangeTimerColor(timerActual, timerMax));
    }

    public void UpdateClassement()
    {
        for (int i = 0; i < _gameManager._playersContainer.Count; i++)
        {
            saveJoueur[i] = _gameManager._playersContainer[i];
        }


        // Le joueur qui a le plus de poissons se retrouve en haut de la liste
        _gameManager._playersContainer = _gameManager._playersContainer.OrderByDescending(player => player.GetComponent<PlayerManager>().Fish).ToList();


        for (int i = 0; i < _gameManager._playersContainer.Count; i++)
        {
            for (int j = 0; j < saveJoueur.Count; j++)
            {
                if (_gameManager._playersContainer[i] == saveJoueur[j])
                {
                    classementTextList[j].text = (i + 1).ToString();
                }
            }

            imageWinList[i].SetActive(false);
        }


        // On affiche une courrone pour le meilleur
        for (int i = 0; i < classementTextList.Count; i++)
        {
            if (classementTextList[i].text == "1")
            {
                imageWinList[i].SetActive(true);
            }
        }
    }

    /**
     * <summary>
     * Change the color of the timer.
     * </summary>
     * <param name="timerActual">The actual timer.</param>
     * <param name="timerMax">The max value.</param>
     */
    private IEnumerator ChangeTimerColor(float timerActual, float timerMax)
    {
        Color timerColor = Color.Lerp(colorStart, colorEnd, timerActual / timerMax);

        imgTimer.color = Color.Lerp(imgTimer.color, timerColor, 1f);
        yield return null;
    }

    #endregion
}