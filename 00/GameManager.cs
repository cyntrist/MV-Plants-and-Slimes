// Decompiled with JetBrains decompiler
// Type: GameManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00C9A5C0-66C5-484E-A969-CDE0DF495E04
// Assembly location: E:\Programas\OneDrive - Universidad Complutense de Madrid (UCM)\UCM\S1\motores\p2\Prac2C\Mot2022_P2C_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GameManager : MonoBehaviour
{
  private UIManager _UIManager;
  private LevelManager _levelManager;
  [SerializeField]
  private GameObject _player;
  [SerializeField]
  private LevelData[] _levels;
  private static GameManager _instance;
  private GameManager.GameStates _currentState;
  private GameManager.GameStates _nextState;
  private int _goal;
  private float _remainingTime;
  private int _nRound;
  private int _current;

  public static GameManager Instance => GameManager._instance;

  public GameManager.GameStates CurrentState => this._currentState;

  public int Current => this._current;

  public void RegisterUIManager(UIManager uiManager)
  {
    if (!((Object) this._UIManager == (Object) null))
      return;
    this._UIManager = uiManager;
  }

  public void RegisterLevelManager(LevelManager levelManager)
  {
    if (!((Object) this._levelManager == (Object) null))
      return;
    this._levelManager = levelManager;
  }

  public void OnPickApple() => ++this._current;

  public void OnPlantApple() => --this._current;

  private void Awake()
  {
    if ((Object) GameManager._instance == (Object) null)
      GameManager._instance = this;
    else
      Object.Destroy((Object) this.gameObject);
  }

  private void EnterState(GameManager.GameStates newState)
  {
    switch (newState)
    {
      case GameManager.GameStates.START:
        this._UIManager.SetMenu(GameManager.GameStates.START);
        break;
      case GameManager.GameStates.GAME:
        this.LoadLevel();
        this._UIManager.SetUpGameHUD(this._nRound, this._goal, this._remainingTime);
        this._UIManager.SetMenu(GameManager.GameStates.GAME);
        break;
      case GameManager.GameStates.GAMEOVER:
        this._UIManager.SetMenu(GameManager.GameStates.GAMEOVER);
        break;
    }
  }

  private void ExitState(GameManager.GameStates newState)
  {
    switch (newState)
    {
      case GameManager.GameStates.GAME:
        this.UnloadLevel();
        break;
    }
  }

  private void UpdateState(GameManager.GameStates state)
  {
    switch (state)
    {
      case GameManager.GameStates.GAME:
        this._remainingTime -= Time.deltaTime;
        if ((double) this._remainingTime < 0.0)
          this._nextState = GameManager.GameStates.GAMEOVER;
        if (this._current >= this._goal)
        {
          this.ExitState(GameManager.GameStates.GAME);
          this.EnterState(GameManager.GameStates.GAME);
        }
        this._UIManager.UpdateGameHUD(this._current, this._remainingTime);
        break;
    }
  }

  public void RequestStateChange(GameManager.GameStates newState) => this._nextState = newState;

  private void LoadLevel()
  {
    int index = Random.Range(0, this._levels.Length);
    this._levelManager = Object.Instantiate<GameObject>(this._levels[index]._levelPrefab, Vector3.zero, Quaternion.identity).GetComponent<LevelManager>();
    this._levelManager.SetPlayer(this._player);
    this._goal = this._levels[index]._levelGoal;
    this._remainingTime = (float) this._levels[index]._matchDuration;
    this._current = 0;
    ++this._nRound;
  }

  private void UnloadLevel()
  {
    this._player.SetActive(false);
    Object.Destroy((Object) this._levelManager.gameObject);
  }

  private void Start()
  {
    this._currentState = GameManager.GameStates.GAMEOVER;
    this._nextState = GameManager.GameStates.START;
  }

  private void Update()
  {
    if (this._nextState != this._currentState)
    {
      this.ExitState(this._currentState);
      this._currentState = this._nextState;
      this.EnterState(this._nextState);
    }
    this.UpdateState(this._currentState);
  }

  public enum GameStates
  {
    START,
    GAME,
    GAMEOVER,
  }
}
