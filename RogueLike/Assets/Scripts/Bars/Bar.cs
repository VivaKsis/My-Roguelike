using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] protected Transform _bar;
    public Transform _Bar => _bar;

    public void SetSizeX(float sizeNormalized)
    {
        _bar.localScale = new Vector3(sizeNormalized, 1);
    }
    public void SetSizeY(float sizeNormalized)
    {
        _bar.localScale = new Vector3(1, sizeNormalized);
    }

    public void SetSizeVector3(Vector3 size)
    {
        _bar.localScale = size;
    }
}
