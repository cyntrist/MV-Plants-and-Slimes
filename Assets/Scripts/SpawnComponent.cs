using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Min time to spawn a new apple
    /// </summary>
    [SerializeField] private float _minSpawnInterval;
    /// <summary>
    /// Mast time to spawn a new apple
    /// </summary>
    [SerializeField] private float _maxSpawnInterval;
    #endregion

    #region references
    /// <summary>
    /// Apple prefab to be instantiated
    /// </summary>
    [SerializeField] private GameObject _applePrefab;
    /// <summary>
    /// Reference to last instantiated apple
    /// </summary>
    private GameObject _apple;
    /// <summary>
    /// Reference to own transform
    /// </summary>
    private Transform _myTransform;
    #endregion

    #region properties
    /// <summary>
    /// Time for next spawm
    /// </summary>
    private float _timeToSpawn;
    #endregion

    /// <summary>
    /// Initialization of references and stuff
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Spawning logic
    /// </summary>
    void Update()
    {
        
    }
}
