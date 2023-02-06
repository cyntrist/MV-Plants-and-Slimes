// Decompiled with JetBrains decompiler
// Type: FollowCamera
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00C9A5C0-66C5-484E-A969-CDE0DF495E04
// Assembly location: E:\Programas\OneDrive - Universidad Complutense de Madrid (UCM)\UCM\S1\motores\p2\Prac2C\Mot2022_P2C_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FollowCamera : MonoBehaviour
{
  [SerializeField]
  private float _horizontalOffset = 1f;
  [SerializeField]
  private float _verticalOffset = 1f;
  [SerializeField]
  private float _lookatVerticalOffset = 1f;
  [SerializeField]
  private float _followFactor = 1f;
  [SerializeField]
  private Transform _targetTransform;
  private Transform _myTransform;

  private void Start()
  {
    this._myTransform = this.transform;
    Vector3 vector3 = this._targetTransform.position - this._horizontalOffset * this._targetTransform.forward + this._verticalOffset * Vector3.up;
    Vector3 worldPosition = this._targetTransform.position + this._lookatVerticalOffset * Vector3.up;
    this._myTransform.position = vector3;
    this._myTransform.LookAt(worldPosition);
  }

  private void LateUpdate()
  {
    Vector3 b = this._targetTransform.position - this._horizontalOffset * this._targetTransform.forward + this._verticalOffset * Vector3.up;
    Vector3 vector3 = this._targetTransform.position + this._lookatVerticalOffset * Vector3.up;
    this._myTransform.position = Vector3.Lerp(this._myTransform.position, b, this._followFactor * Time.deltaTime);
  }
}
