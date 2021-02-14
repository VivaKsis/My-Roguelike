using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private RaycastEmitter _raycastEmitter;
    public RaycastEmitter _RaycastEmitter => _raycastEmitter;

    [SerializeField] private LevelGenerator _levelGenerator;
    public LevelGenerator _LevelGenerator => _levelGenerator;

    private RaycastHit _raycastHit;

    public void GenerateLevel()
    {
        _levelGenerator.Generate();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(pos: Input.mousePosition);

        if (_raycastEmitter.Raycast(ray: ray, raycastHit: out _raycastHit))
        {
            Debug.Log(_raycastHit.point);
        }
    }
}
