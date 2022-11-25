using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToWorldComponent : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Max distance for world point
    /// </summary>
    [SerializeField] private float _maxDistance;
    #endregion

    #region references
    /// <summary>
    /// Reference to camera
    /// </summary>
    private Camera _camera;
    /// <summary>
    /// References to camera transform
    /// </summary>
    private Transform _cameraTransform;
    #endregion

    #region properties
    /// <summary>
    /// RaycastHit to store hit information
    /// </summary>
    private RaycastHit _myRaycastHit;
    /// <summary>
    /// Layermask to filter desired layer
    /// </summary>
    private LayerMask _myLayerMask = 1 << 0; // Colision entre capas (semantica rara)
    #endregion

    #region methods
    /// <summary>
    /// Converts a screen point to a world point corresponding to the floor
    /// </summary>
    /// <param name="screenPoint"></param>
    /// <returns></returns>
    public Vector3 ScreenToWorldPoint(Vector2 screenPoint) //crea Vector3D (en el plano) desde Vector2D (de la pantalla)
    {
        Ray ray = _camera.ScreenPointToRay(screenPoint);
        if (Physics.Raycast(ray, out _myRaycastHit, _maxDistance, _myLayerMask))
        {
            //Debug.Log("La colisión del raycast es en: " + _myRaycastHit.transform + ", " + _myRaycastHit.point);
            return _myRaycastHit.point;
        }
        else //new
        {
            //Debug.Log("No hay colisión del raycast.");
            return transform.position; 
        }
    }
    #endregion

    /// <summary>
    /// Initialize references and properties
    /// </summary>
    void Start()
    {
        _camera = Camera.main;
        _cameraTransform = _camera.transform;
    }
}
