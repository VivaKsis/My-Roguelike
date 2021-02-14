using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateAsset/Formation")]

public class Formation : ScriptableObject
{
    [SerializeField] private Vector3[] _enemyPositions;
    public Vector3[] _EnemyPositions => _enemyPositions;
}
