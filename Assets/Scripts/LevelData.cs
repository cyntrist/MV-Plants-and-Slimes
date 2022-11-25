using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    #region parameters
    public int _matchDuration = 60;
    public int _levelGoal = 10;
    #endregion

    #region references
    public GameObject _levelPrefab;
    #endregion
}
