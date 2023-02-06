// Decompiled with JetBrains decompiler
// Type: UIManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00C9A5C0-66C5-484E-A969-CDE0DF495E04
// Assembly location: E:\Programas\OneDrive - Universidad Complutense de Madrid (UCM)\UCM\S1\motores\p2\Prac2C\Mot2022_P2C_Data\Managed\Assembly-CSharp.dll

using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  [SerializeField]
  private TMP_Text _goalTMP;
  [SerializeField]
  private TMP_Text _currentTMP;
  [SerializeField]
  private TMP_Text _remainingTimeTMP;
  [SerializeField]
  private TMP_Text _nRoundTMP;
  [SerializeField]
  private GameObject _mainMenu;
  [SerializeField]
  private GameObject _gameplayHUD;
  [SerializeField]
  private GameObject _gameOverMenu;
  private GameManager.GameStates _activeMenu;
  private GameObject[] _menus;

  public void RequestStateChange(int newState) => GameManager.Instance.RequestStateChange((GameManager.GameStates) newState);

  public void UpdateGameHUD(int currentApples, float remainingTime)
  {
    this._currentTMP.text = currentApples.ToString();
    this._remainingTimeTMP.text = remainingTime.ToString();
  }

  public void SetUpGameHUD(int nRound, int goal, float remainingTime)
  {
    this._nRoundTMP.text = nRound.ToString();
    this._goalTMP.text = goal.ToString();
    this._remainingTimeTMP.text = remainingTime.ToString();
    this._currentTMP.text = 0.ToString();
  }

  public void SetMenu(GameManager.GameStates newMenu)
  {
    if (newMenu == this._activeMenu)
      return;
    this._menus[(int) this._activeMenu].SetActive(false);
    this._activeMenu = newMenu;
    this._menus[(int) this._activeMenu].SetActive(true);
  }

  private void Start()
  {
    this._menus = new GameObject[3];
    this._menus[0] = this._mainMenu;
    this._menus[1] = this._gameplayHUD;
    this._menus[2] = this._gameOverMenu;
    this._activeMenu = GameManager.GameStates.GAMEOVER;
    GameManager.Instance.RegisterUIManager(this);
  }
}
