using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Generator")]
public class LevelGenerator : ScriptableObject
{
    [SerializeField] private GameObject[] _enemies;
    public GameObject[] _Enemies => _enemies;

    [SerializeField] private Formation[] _formations;
    public Formation[] _Formations => _formations;

    private int GetEnemyNumber()
    {
        return Random.Range(1, 6);
    }

    public void Generate()
    {
        switch (GetEnemyNumber())
        {
            case 1: 
                Debug.Log(_formations[0]);
                break;
            case 2:
                Debug.Log(_formations[1]);
                break;
            case 3:
                Debug.Log(_formations[2]);
                break;
            case 4:
                Debug.Log(_formations[3]);
                break;
            case 5:
                Debug.Log(_formations[4]);
                break;
            default:
                break;
        }
    }
}
