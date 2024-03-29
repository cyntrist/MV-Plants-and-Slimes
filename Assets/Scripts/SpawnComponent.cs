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
        _myTransform = transform;
        _timeToSpawn = Random.Range(_minSpawnInterval, _maxSpawnInterval); // intervalo aleatorio de tiempo de generaci�n de la siguiente manzana
    }

    /// <summary>
    /// Spawning logic
    /// </summary>
    void Update()
    {
        if (_apple == null) // si acaba de ser plantado o ha cogido la manzana (en general si no hay manzana plantada, solo puede haber una)
        {
            _timeToSpawn -= Time.deltaTime; // cuenta atr�s
            if (_timeToSpawn <= 0)
            {
                _apple = Object.Instantiate(_applePrefab, _myTransform.position, Quaternion.identity); // se crea la manzana 
                _apple.transform.parent = _myTransform; // para que sea hija y cree dentro de Level y se destruya en el UnloadLevel();
                _timeToSpawn = Random.Range(_minSpawnInterval, _maxSpawnInterval); // nuevo intervalo random
            }
        }
    }
}
