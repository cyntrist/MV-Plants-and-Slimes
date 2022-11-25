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
    private LayerMask _myLayerMask = 1 << 8;
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
    private SoilComponent EvaluatePoint(Vector3 pointToEvaluate) // Devuelve el SoilComponent del Soil clicado solo si es soil
    {
        Ray ray;

        if (Physics.Raycast(_camera.transform.position, (pointToEvaluate - _camera.transform.position).normalized, out _myHitInfo, Mathf.Infinity, _myLayerMask))
        { // raycast desde la posición de la cámara en dirección del vector normal hacia el punto a evaluar  (layer soil: 8)
            Debug.Log("La colisión es con un soil válido.");
            return _myHitInfo.collider.GetComponent<SoilComponent>(); 
        }
        Debug.Log("No es válido.");
        return null;
    }
    /// <summary>
    /// Tries to plant in a point. If valid point, sotres the component and goes to desired point
    /// </summary>
    /// <param name="plantingPoint">Point where the player wants to plant in</param>

    public void TryPlant(Vector3 plantingPoint) // Si el punto es valido, va hasta el hasta que colisione y se ejecute OnTriggerEnter
    {
        if (EvaluatePoint(plantingPoint) != null)
        {
            //Debug.Log("Intento de plantado.");
            _myMovementComponent.GoToPoint(plantingPoint);
        } 
        //TODO
    }

    /// <summary>
    /// Detects Soil Component. If it is the desired soil, it gets planted.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //TODO // Si tengo manzana y pulso el clic derecho en un soil, la planta una vez colisiona con el desired soil.
    }
    #endregion

    /// <summary>
    /// Initialization of references, raycasthit and layermask.
    /// </summary
    void Start()
    {
        _camera = Camera.main;
        _myMovementComponent = GetComponent<MovementComponent>();
        _myInputComponent = GetComponent<InputComponent>(); 
        _desiredSoilComponent = GetComponent<SoilComponent>();

        //_myLayerMask = LayerMask.GetMask("Soil");
        _plantingState = PlantingStates.None;
    }
}
