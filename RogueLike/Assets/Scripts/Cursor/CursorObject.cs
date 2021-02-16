using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorObject : MonoBehaviour
{
    [SerializeField] private CursorManager.CursorType cursorType;

    private CursorManager cursorManager;

    private void Awake()
    {
        cursorManager = FindObjectOfType<CursorManager>();
    }

    private void OnMouseEnter()
    {
        cursorManager.SetActiveCursorType(cursorType);
    }

    private void OnMouseExit()
    {
        cursorManager.SetActiveCursorType(CursorManager.CursorType.arrow);
    }
}
