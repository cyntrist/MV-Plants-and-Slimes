using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilComponent : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to own transform
    /// </summary>
    private Transform _myTransform;
    #endregion

    #region properties
    /// <summary>
    /// Stores if the Soil has a plant or not
    /// </summary>
    private bool _isPlanted;
    /// <summary>
    /// Public access to planted state
    /// </summary>
    public bool IsPlanted
    {
        get { return _isPlanted; }
    }
    #endregion

    #region methods
    /// <summary>
    /// Instantiates the plant and informs GameManager
    /// </summary>
    /// <param name="newPlantPrefab"></param>
    public void Plant(GameObject newPlantPrefab)
    {
        if (!_isPlanted && GameManager.Instance.Current > 0) // Si no hay nada plantado y tiene manzanas
        {
            GameManager.Instance.OnPlantApple(); // Resta una manzana
            _isPlanted = true; // Este soil queda plantado
            Instantiate(newPlantPrefab, _myTransform.position, Quaternion.Euler(0, 180f, 0)).transform.parent = _myTransform; // Instanciación del prefab Plant a 180º de su ángulo normal (mótivos meramente estéticos) en la posición del Soil
        }
    }
    #endregion

    /// <summary>
    /// Initialize references
    /// </summary>
    void Start()
    {
        _myTransform = transform;
        _isPlanted = false;
    }
}
