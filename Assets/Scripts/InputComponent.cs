using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScreenToWorldComponent))]
public class InputComponent : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to own screentoworld component
    /// </summary>
    private ScreenToWorldComponent _myScreenToWorldComp;
    /// <summary>
    /// Reference to own movement component
    /// </summary>
    private MovementComponent _myMovementComponent;
    /// <summary>
    /// Reference to own planting component
    /// </summary>
    private PlantingComponent _myPlantingComponent;
    #endregion

    #region properties
    /// <summary>
    /// Mouse position
    /// </summary>
    private Vector2 _mousePosition;
    /// <summary>
    /// Position in game world
    /// </summary>
    private Vector3 _worldPosition;
    /// <summary>
    /// Position of plant intent in world
    /// </summary>
    private Vector3 _plantPosition;
    #endregion

    /// <summary>
    /// References initialization
    /// </summary>
    void Start()
    {
        _myMovementComponent = GetComponent<MovementComponent>();
        _myScreenToWorldComp = GetComponent<ScreenToWorldComponent>();
        _myPlantingComponent = GetComponent<PlantingComponent>();
    }

    /// <summary>
    /// Receives input and calls required methods
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //si se pulsa click izdo
        {
            _mousePosition = Input.mousePosition; //guarda su posicion
            _worldPosition = _myScreenToWorldComp.ScreenToWorldPoint(_mousePosition); //pasa _mousePosition (2D) a posición en el Plane (3D)
            _myMovementComponent.GoToPoint(_worldPosition); //GoToPoint() del _worldPosition (3D)
        }

        if (Input.GetMouseButtonDown(1)) // click dcho
        {
            _plantPosition = _myScreenToWorldComp.ScreenToWorldPoint(Input.mousePosition); // 2D a 3D del intento de plantado
            _myPlantingComponent.TryPlant(_plantPosition); // intenta plantar
        }
    }
}
