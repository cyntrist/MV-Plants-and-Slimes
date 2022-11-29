using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Movement speed magnitude
    /// </summary>
    [SerializeField] private float _movementSpeed;
    /// <summary>
    /// Distance to target to stop movement
    /// </summary>
    [SerializeField] private float _stopDistance;
    #endregion

    #region refrences
    /// <summary>
    /// Reference to own transform
    /// </summary>
    private Transform _myTransform;
    /// /// <summary>
    /// Reference to own character controller
    /// </summary>
    private CharacterController _myCharacterController;
    #endregion

    #region properties
    /// <summary>
    /// Target point the player wants to move towards
    /// </summary>
    private Vector3 _myTargetPoint;
    /// <summary>
    /// Movement speed vector
    /// </summary>
    private Vector3 _movementSpeedVector; // UNUSED
    #endregion

    #region methods
    /// <summary>
    /// Method to move towards desired point
    /// </summary>
    /// <param name="targetPoint"></param>
    public void GoToPoint(Vector3 targetPoint) 
    {
        _myTargetPoint = targetPoint;
        enabled = true; //cuando reciba input, se activara
    }
    #endregion

    /// <summary>
    /// References initialization
    /// </summary>
    void Start()
    {
        _myTransform = GetComponent<Transform>();
        _myCharacterController = GetComponent<CharacterController>();
        enabled = false; // desactiva este componente al empezar
    }

    /// <summary>
    /// Move with desired speed and direction
    /// </summary>
    void Update()
    {
        var offset = _myTargetPoint - _myTransform.position; //resta target a posicion actual del transform
        if (offset.magnitude > _stopDistance) // si el valor positivo de la distancia entre player y targetPoint es mayor que la distancia a la que se para 
        {
            offset = offset.normalized * _movementSpeed; // sentido * velocidad a la que queremos ir
            _myCharacterController.Move(offset * Time.deltaTime);
        }
        else
        {
            enabled = false;
        }
    }
}
