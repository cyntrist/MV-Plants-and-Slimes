// Decompiled with JetBrains decompiler
// Type: InputComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00C9A5C0-66C5-484E-A969-CDE0DF495E04
// Assembly location: E:\Programas\OneDrive - Universidad Complutense de Madrid (UCM)\UCM\S1\motores\p2\Prac2C\Mot2022_P2C_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (ScreenToWorldComponent))]
public class InputComponent : MonoBehaviour
{
  private ScreenToWorldComponent _myScreenToWorldComp;
  private MovementComponent _myMovementComponent;
  private PlantingComponent _myPlantingComponent;
  private Vector2 _mousePosition;

  private void Start()
  {
    this._myScreenToWorldComp = this.GetComponent<ScreenToWorldComponent>();
    this._myMovementComponent = this.GetComponent<MovementComponent>();
    this._myPlantingComponent = this.GetComponent<PlantingComponent>();
  }

  private void Update()
  {
    this._mousePosition = (Vector2) Input.mousePosition;
    if (Input.GetMouseButtonDown(0))
      this._myMovementComponent.GoToPoint(this._myScreenToWorldComp.ScreenToWorldPoint(this._mousePosition));
    if (!Input.GetMouseButtonDown(1))
      return;
    this._myPlantingComponent.TryPlant(this._myScreenToWorldComp.ScreenToWorldPoint(this._mousePosition));
  }
}
