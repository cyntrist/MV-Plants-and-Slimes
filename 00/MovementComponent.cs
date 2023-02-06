// Decompiled with JetBrains decompiler
// Type: MovementComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00C9A5C0-66C5-484E-A969-CDE0DF495E04
// Assembly location: E:\Programas\OneDrive - Universidad Complutense de Madrid (UCM)\UCM\S1\motores\p2\Prac2C\Mot2022_P2C_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MovementComponent : MonoBehaviour
{
  [SerializeField]
  private float _movementSpeed = 1f;
  [SerializeField]
  private float _stopDistance = 1f;
  private Transform _myTransform;
  private CharacterController _myCharacterController;
  private Vector3 _myTargetPoint;
  private Vector3 _movementSpeedVector;

  public void GoToPoint(Vector3 targetPoint)
  {
    this._myTargetPoint = targetPoint;
    this._movementSpeedVector = this._movementSpeed * (this._myTargetPoint - this._myTransform.position).normalized;
    this.enabled = true;
  }

  private void Start()
  {
    this._myTransform = this.transform;
    this._myCharacterController = this.GetComponent<CharacterController>();
    this.enabled = false;
  }

  private void Update()
  {
    if ((double) (this._myTargetPoint - this._myTransform.position).magnitude > (double) this._stopDistance)
      this._myCharacterController.SimpleMove(this._movementSpeedVector);
    else
      this.enabled = false;
  }
}
