using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to Goal Data Text
    /// </summary>
    [SerializeField] private TMP_Text _goalTMP;
    /// <summary>
    /// Reference to Current amount of apples Text
    /// </summary>
    [SerializeField] private TMP_Text _currentTMP;
    /// <summary>
    /// Reference to Remaining Time Text
    /// </summary>
    [SerializeField] private TMP_Text _remainingTimeTMP;
    /// <summary>
    /// Reference to number of rounds Text
    /// </summary>
    [SerializeField] private TMP_Text _nRoundTMP;
    /// <summary>
    /// Reference to Main Menu object
    /// </summary>
    [SerializeField] private GameObject _mainMenu;
    /// <summary>
    /// Reference to Gameplay HUD object
    /// </summary>
    [SerializeField] private GameObject _gameplayHUD;
    /// <summary>
    /// Reference to Game Over Menu object
    /// </summary>
    [SerializeField] private GameObject _gameOverMenu;
    #endregion

    #region properties
    /// <summary>
    /// Reference to active menu Game State
    /// </summary>
    private GameManager.GameStates _activeMenu;
    /// <summary>
    /// Menus array
    /// </summary>
    private GameObject[] _menus;
    #endregion

    #region methods
    /// <summary>
    /// Requests new state to GameManager
    /// </summary>
    /// <param name="newState"></param>
    public void RequestStateChange(int newState)
    {
        GameManager.Instance.RequestStateChange((GameManager.GameStates)newState);
    }
    /// <summary>
    /// Update in game HUD
    /// </summary>
    /// <param name="currentApples">Current number of collected apples</param>
    /// <param name="remainingTime">Current remaining time</param>
    public void UpdateGameHUD(int currentApples, float remainingTime)
    {
        //TODO
    }
    /// <summary>
    /// Sets up HUD after Level's load
    /// </summary>
    /// <param name="nRound">Round number</param>
    /// <param name="goal">Level goal</param>
    /// <param name="remainingTime">Remaining time</param>
    public void SetUpGameHUD(int nRound, int goal, float remainingTime)
    {
        //TOD
    }
    /// <summary>
    /// Sets the required menu according to Game State
    /// </summary>
    /// <param name="newMenu">New menu Game State</param>
    public void SetMenu(GameManager.GameStates newMenu)
    {
        //TOD
    }
    #endregion

    /// <summary>
    /// Menus array initialization and UI Manager registration
    /// </summary>
    void Start()
    {
        
    }
}
