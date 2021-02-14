using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform _bar;
    public Transform _Bar => _bar;

    public void SetSize(float sizeNormalized)
    {
        _bar.localScale = new Vector3(sizeNormalized, 1);
    }
}
