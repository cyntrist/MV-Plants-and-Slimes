using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Camera horizontal offset to target
    /// </summary>
    [SerializeField] private float _horizontalOffset;
    /// <summary>
    /// Camera vertica offset to target
    /// </summary>
    [SerializeField] private float _verticalOffset;
    /// <summary>
    /// Look at point vertical offset to target
    /// </summary>
    [SerializeField] private float _lookatVerticalOffset;
    /// <summary>
    /// Follow factor to regulate camera responsiveness
    /// </summary>
    [SerializeField] private float _followFactor;
    #endregion

    #region references
    /// <summary>
    /// Reference to target's transform
    /// </summary>
    [SerializeField] private Transform _targetTransform;
    /// <summary>
    /// Reference to own transform
    /// </summary>
    private Transform _myTransform;
    #endregion

    /// <summary>
    /// Initialiation of desired position and lookat point
    /// </summary>
    void Start()
    {
        _myTransform = GetComponent<Transform>();
    }

    /// <summary>
    /// Updates camera position
    /// </summary>
    void LateUpdate()
    {
        Vector3 newVector = new Vector3(_targetTransform.position.x, _targetTransform.position.y + _verticalOffset, _targetTransform.position.z - _horizontalOffset);
        _myTransform.position = Vector3.Lerp(_myTransform.position, newVector, _followFactor);
        _myTransform.LookAt(_targetTransform); // gira la rotaci�n de la c�mara
    }
}
