// Decompiled with JetBrains decompiler
// Type: LevelManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00C9A5C0-66C5-484E-A969-CDE0DF495E04
// Assembly location: E:\Programas\OneDrive - Universidad Complutense de Madrid (UCM)\UCM\S1\motores\p2\Prac2C\Mot2022_P2C_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LevelManager : MonoBehaviour
{
  [SerializeField]
  private Transform _spawnPoint;

  public void SetPlayer(GameObject player)
  {
    player.transform.position = this._spawnPoint.position;
    player.transform.rotation = this._spawnPoint.rotation;
    player.SetActive(true);
  }
}
