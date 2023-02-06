// Decompiled with JetBrains decompiler
// Type: PlantingComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00C9A5C0-66C5-484E-A969-CDE0DF495E04
// Assembly location: E:\Programas\OneDrive - Universidad Complutense de Madrid (UCM)\UCM\S1\motores\p2\Prac2C\Mot2022_P2C_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PlantingComponent : MonoBehaviour
{
  [SerializeField]
  private GameObject _plantPrefab;
  private Camera _camera;
  private MovementComponent _myMovementComponent;
  private InputComponent _myInputComponent;
  private SoilComponent _desiredSoilComponent;
  private RaycastHit _myHitInfo;
  private LayerMask _myLayerMask;
  private PlantingComponent.PlantingStates _plantingState;

  private SoilComponent EvaluatePoint(Vector3 pointToEvaluate)
  {
    Vector3 position = this._camera.transform.position;
    Vector3 normalized = (pointToEvaluate - this._camera.transform.position).normalized;
    float magnitude = (pointToEvaluate - this._camera.transform.position).magnitude;
    Vector3 direction = normalized;
    ref RaycastHit local = ref this._myHitInfo;
    double maxDistance = (double) magnitude;
    int layerMask = (int) this._myLayerMask;
    return Physics.Raycast(position, direction, out local, (float) maxDistance, layerMask) ? this._myHitInfo.collider.GetComponent<SoilComponent>() : (SoilComponent) null;
  }

  public void TryPlant(Vector3 plantingPoint)
  {
    if (GameManager.Instance.Current <= 0 || this._plantingState != PlantingComponent.PlantingStates.None)
      return;
    SoilComponent point = this.EvaluatePoint(plantingPoint);
    if (!((Object) point != (Object) null))
      return;
    this._desiredSoilComponent = point;
    this._myInputComponent.enabled = false;
    this._myMovementComponent.GoToPoint(plantingPoint);
    this._plantingState = PlantingComponent.PlantingStates.IsPlanting;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (this._plantingState != PlantingComponent.PlantingStates.IsPlanting || !((Object) other.GetComponent<SoilComponent>() == (Object) this._desiredSoilComponent))
      return;
    this._desiredSoilComponent.Plant(this._plantPrefab);
    this._plantingState = PlantingComponent.PlantingStates.None;
    this._myInputComponent.enabled = true;
  }

  private void Start()
  {
    this._camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    this._myHitInfo = new RaycastHit();
    this._myLayerMask = (LayerMask) LayerMask.GetMask("Ground");
    this._myInputComponent = this.GetComponent<InputComponent>();
    this._myMovementComponent = this.GetComponent<MovementComponent>();
  }

  public enum PlantingStates
  {
    None,
    IsPlanting,
  }
}
