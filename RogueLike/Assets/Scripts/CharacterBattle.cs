using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    [SerializeField] private HealthSystem _healthSystem;
    public HealthSystem _HealthSystem => _healthSystem;

    [SerializeField] SpriteAnimator spriteAnimator;
    public SpriteAnimator _SpriteAnimator => spriteAnimator;

    [SerializeField] Character _character;
    public Character _Character => _character;

    [SerializeField] private GameObject selectionCircle;

    public bool IsDead => _healthSystem.IsDead;

    public void Start()
    {
        _healthSystem.SetMaxHealth(_character._MaxHealth);
        HideSelectionCircle();
    }

    public void DoMove(CharacterBattle target, Action onAttackComplete)
    {
        _character.NextCommand(_healthSystem.GetHealthPercent).Execute(this, target, onAttackComplete);
    }

    public void ShowSelectionCircle()
    {
        if (selectionCircle == null)
            return;
        selectionCircle.SetActive(true);
    }
    public void HideSelectionCircle()
    {
        if (selectionCircle == null)
            return;
        selectionCircle.SetActive(false);
    }
}
