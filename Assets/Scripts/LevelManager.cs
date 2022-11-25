using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Spawn point for player
    /// </summary>
    [SerializeField] private Transform _spawnPoint;
    #endregion

    #region methods
    /// <summary>
    /// Sets player position and rotation. Enables player.
    /// </summary>
    /// <param name="player"></param>
    public void SetPlayer(GameObject player)
    {
        player.transform.position = _spawnPoint.transform.position;
        player.SetActive(true);
    }
    #endregion
}
