// Decompiled with JetBrains decompiler
// Type: SpawnComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00C9A5C0-66C5-484E-A969-CDE0DF495E04
// Assembly location: E:\Programas\OneDrive - Universidad Complutense de Madrid (UCM)\UCM\S1\motores\p2\Prac2C\Mot2022_P2C_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
  [SerializeField]
  private float _minSpawnInterval;
  [SerializeField]
  private float _maxSpawnInterval;
  [SerializeField]
  private GameObject _applePrefab;
  private GameObject _apple;
  private Transform _myTransform;
  private float _timeToSpawn;

  private void Start()
  {
    this._timeToSpawn = Random.Range(this._minSpawnInterval, this._maxSpawnInterval);
    this._myTransform = this.transform;
  }

  private void Update()
  {
    if (!((Object) this._apple == (Object) null))
      return;
    this._timeToSpawn -= Time.deltaTime;
    if ((double) this._timeToSpawn >= 0.0)
      return;
    this._timeToSpawn = Random.Range(this._minSpawnInterval, this._maxSpawnInterval);
    this._apple = Object.Instantiate<GameObject>(this._applePrefab, this._myTransform.position, Quaternion.identity);
    this._apple.transform.parent = this._myTransform;
  }
}
