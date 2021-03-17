using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Character/Basic")]
public class Character : ScriptableObject
{
    [SerializeField] private int _maxHealth;
    public int _MaxHealth => _maxHealth;

    [SerializeField] private int _damage;
    public int _Damage => _damage;

    [SerializeField] private AttackCommand _attackCommand;
    public AttackCommand _AttackCommand => _attackCommand;

    [SerializeField] private HealCommand _healCommand;
    public HealCommand _HealCommand => _healCommand;

    // TODO AI
    public Command NextCommand(float currentHealthPercent)
    {
        if(_healCommand._CanHeal && currentHealthPercent < 0.5)
        {
            return _healCommand;
        }
        return _attackCommand;
    }
}
