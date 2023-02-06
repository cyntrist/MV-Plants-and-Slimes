// Decompiled with JetBrains decompiler
// Type: ScreenToWorldComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 00C9A5C0-66C5-484E-A969-CDE0DF495E04
// Assembly location: E:\Programas\OneDrive - Universidad Complutense de Madrid (UCM)\UCM\S1\motores\p2\Prac2C\Mot2022_P2C_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ScreenToWorldComponent : MonoBehaviour
{
  [SerializeField]
  private float _maxDistance = 100f;
  private Camera _camera;
  private Transform _cameraTransform;
  private RaycastHit _myRaycastHit;
  private LayerMask _myLayerMask;

  public Vector3 ScreenToWorldPoint(Vector2 screenPoint)
  {
    if (Physics.Raycast(this._cameraTransform.position, this._camera.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, this._maxDistance)) - this._cameraTransform.position, out this._myRaycastHit, this._maxDistance, (int) this._myLayerMask))
      return this._myRaycastHit.point;
    Debug.LogError((object) (this.name + "No point found"));
    return Vector3.zero;
  }

  private void Start()
  {
    this._myRaycastHit = new RaycastHit();
    this._camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    this._cameraTransform = this._camera.transform;
    this._myLayerMask = (LayerMask) LayerMask.GetMask("Floor");
  }
}
