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
    private SoilComponent EvaluatePoint(Vector3 pointToEvaluate) // Devuelve el SoilComponent del Soil colisionado por el raycast 
    {
        if (Physics.Raycast(_camera.transform.position, (pointToEvaluate - _camera.transform.position).normalized, out _myHitInfo, Mathf.Infinity, _myLayerMask))
        { // raycast desde la posición de la cámara en dirección del vector normal hacia el punto a evaluar  (layer soil: 8)
            return _myHitInfo.collider.GetComponent<SoilComponent>(); 
        }
        return null;
    }

    /// <summary>
    /// Tries to plant in a point. If valid point, sotres the component and goes to desired point
    /// </summary>
    /// <param name="plantingPoint">Point where the player wants to plant in</param>

    public void TryPlant(Vector3 plantingPoint) // Si el punto es valido, va hasta el hasta que colisione y se ejecute OnTriggerEnter
    {
        _desiredSoilComponent = EvaluatePoint(plantingPoint);
        if (_desiredSoilComponent != null)
        {
            _myMovementComponent.GoToPoint(plantingPoint);
        }
    }

    /// <summary>
    /// Detects Soil Component. If it is the desired soil, it gets planted.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SoilComponent>() == _desiredSoilComponent && _desiredSoilComponent != null && _desiredSoilComponent.IsPlanted == false)
        { // tener en cuenta que una vez vuelvas a entrar al soil no plante una segunda manzana sin querer (seguramente con los estados se solucione)
            Debug.Log("**Colisión con desired soil");
            _desiredSoilComponent.Plant(_plantPrefab);
        }
        // Si tengo manzana y pulso el clic derecho en un soil, planta la manzana una vez colisiona con el desired soil.
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

        _plantingState = PlantingStates.None;
    }
}
