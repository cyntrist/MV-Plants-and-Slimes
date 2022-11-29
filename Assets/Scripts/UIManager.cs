using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    public void UpdateGameHUD(int currentApples, float remainingTime) // Actualiza en cada frame el valor del tiempo y las manzanas
    {
        _currentTMP.text = "Manzanas: " + currentApples.ToString();
        _remainingTimeTMP.text = "Tiempo restante: " + (int) remainingTime;
    }
    /// <summary>
    /// Sets up HUD after Level's load
    /// </summary>
    /// <param name="nRound">Round number</param>
    /// <param name="goal">Level goal</param>
    /// <param name="remainingTime">Remaining time</param>
    public void SetUpGameHUD(int nRound, int goal, float remainingTime) // Actualiza *s�lo cada vez que se carga un nivel* los datos de ese nivel (Ronda y meta)
    {
        _nRoundTMP.text = "Ronda: " + nRound.ToString();
        _goalTMP.text = "Meta: " + goal.ToString();
        _remainingTimeTMP.text = "Tiempo restante: " + remainingTime.ToString();
    }
    /// <summary>
    /// Sets the required menu according to Game State
    /// </summary>
    /// <param name="newMenu">New menu Game State</param>
    public void SetMenu(GameManager.GameStates newMenu)
    { // desactiva el men� anterior, actualiza el actual y activa el actual
        _menus[(int) _activeMenu].SetActive(false);
        _activeMenu = newMenu;
        _menus[(int)_activeMenu].SetActive(true); 
    }
    #endregion

    /// <summary>
    /// Menus array initialization and UI Manager registration
    /// </summary>
    void Start()
    {
        _menus = new GameObject[3]; // creaci�n del array de men�s y asignaci�n
        _menus[0] = _mainMenu;
        _menus[1] = _gameplayHUD;
        _menus[2] = _gameOverMenu;
        _activeMenu = GameManager.Instance.CurrentState; // asocia el men� actual con el estado actual

        GameManager.Instance.RegisterUIManager(this); // registra este UI manager con la instancia del Game manager
    }
}
