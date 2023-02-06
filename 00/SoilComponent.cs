// Decompiled with JetBrains decompiler
// Type: SoilComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00C9A5C0-66C5-484E-A969-CDE0DF495E04
// Assembly location: E:\Programas\OneDrive - Universidad Complutense de Madrid (UCM)\UCM\S1\motores\p2\Prac2C\Mot2022_P2C_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SoilComponent : MonoBehaviour
{
  private Transform _myTransform;
  private bool _isPlanted;

  public bool IsPlanted => this._isPlanted;

  public void Plant(GameObject newPlantPrefab)
  {
    if (this._isPlanted)
      return;
    Object.Instantiate<GameObject>(newPlantPrefab, this._myTransform.position, Quaternion.identity).transform.parent = this._myTransform;
    this._isPlanted = true;
    GameManager.Instance.OnPlantApple();
  }

  private void Start() => this._myTransform = this.transform;
}
