using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingComponent : MonoBehaviour
{
    #region references
    /// <summary>
    /// Plant prefab to instantiate
    /// </summary>
    [SerializeField] private GameObject _plantPrefab;
    /// <summary>
    /// Reference to camera
    /// </summary>
    private Camera _camera;
    /// <summary>
    /// Reference to own movement component
    /// </summary>
    private MovementComponent _myMovementComponent;
    /// <summary>
    /// Reference to own input component
    /// </summary>
    private InputComponent _myInputComponent;
    /// <summary>
    /// Reference to desired soil
    /// </summary>
    private SoilComponent _desiredSoilComponent;
    #endregion

    #region properties
    /// <summary>
    /// Hit info to store hit info
    /// </summary>
    private RaycastHit _myHitInfo;
    /// <summary>
    /// Layermast to filter desired layer
    /// </summary>
    private LayerMask _myLayerMask;
    /// <summary>
    /// Indicates the planting state
    /// </summary>
    private PlantingStates _plantingState;
    #endregion

    #region enums
    /// <summary>
    /// Defined planting states
    /// </summary>
    public enum PlantingStates { None, IsPlanting };
    #endregion

    #region methods
    /// <summary>
    /// Detects if the player has clicked a valid soil area and returns corresponding component
    /// </summary>
    /// <param name="pointToEvaluate">Point to be evaluated</param>
    /// <returns></returns>
    private SoilComponent EvaluatePoint(Vector3 pointToEvaluate) // Devuelve el SoilComponent del Soil colisionado por el raycast 
    {
        Ray ray = new(_camera.transform.position, (pointToEvaluate - _camera.transform.position).normalized);
        if (Physics.Raycast(ray, out _myHitInfo, Mathf.Infinity, _myLayerMask))
        { // raycast desde la posición de la cámara en dirección del vector normal hacia el punto a evaluar  (layer soil: 8)
            return _myHitInfo.collider.GetComponent<SoilComponent>(); 
        }
        return null; // si no colisiona con nada
    }

    /// <summary>
    /// Tries to plant in a point. If valid point, sotres the component and goes to desired point
    /// </summary>
    /// <param name="plantingPoint">Point where the player wants to plant in</param>

    public void TryPlant(Vector3 plantingPoint) // Si el punto es valido, va hasta el hasta que colisione y se ejecute OnTriggerEnter
    {
        _desiredSoilComponent = EvaluatePoint(plantingPoint); // Raycast
        if (GameManager.Instance.Current > 0 && _plantingState == PlantingStates.None && !_desiredSoilComponent.IsPlanted && _desiredSoilComponent != null)
        { // Si tiene manzanas, Player no está plantando y el suelo no está plantado ni es nulo
            _myMovementComponent.GoToPoint(plantingPoint); // Movimiento
            _myInputComponent.enabled = false; // si cambia de trayecto en el camino nunca vuelve al estado inicial
            _plantingState = PlantingStates.IsPlanting; // Cambio de estado
        }
    }

    /// <summary>
    /// Detects Soil Component. If it is the desired soil, it gets planted.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SoilComponent>() == _desiredSoilComponent && _plantingState == PlantingStates.IsPlanting)
        { // si el soil con el que colisiona es el deseado y el estado es el de plantando
            _desiredSoilComponent.Plant(_plantPrefab); // instanciación de planta
            _myInputComponent.enabled = true; // reactiva input
            _plantingState = PlantingStates.None; // vuelta al estado anterior
        }
    }
    #endregion

    /// <summary>
    /// Initialization of references, raycasthit and layermask.
    /// </summary
    void Start()
    {
        _camera = Camera.main;
        _myLayerMask = 1 << 8;
        _myMovementComponent = GetComponent<MovementComponent>();
        _myInputComponent = GetComponent<InputComponent>();
        _plantingState = PlantingStates.None;
    }
}
