using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables

    [Header("ScoreBoard Parameters")]
    [SerializeField] private List<GameObject> backgroundList;
    [SerializeField] private List<GameObject> profilePicList;

    [Header("Timer Parameters")]
    [SerializeField] private Image imgTimer;
    [SerializeField] private Color colorStart;
    [SerializeField] private Color colorEnd;

    [SerializeField] private List<Image> jaugeList;
    [SerializeField] private List<Sprite> skinsImgList;
    private int indexPLayer = 0;

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
        if (_instance) Destroy(this);
        _instance = this;

        for (int i = 0; i < backgroundList.Count; i++)
        {
            backgroundList[i].SetActive(false);
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