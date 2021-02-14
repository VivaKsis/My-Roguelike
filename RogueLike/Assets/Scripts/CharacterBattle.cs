using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    [SerializeField] private HealthSystem _healthSystem;
    public HealthSystem _HealthSystem => _healthSystem;
    [SerializeField] private SpriteAnimator _spriteAnimator;
    public SpriteAnimator _SpriteAnimator => _spriteAnimator;

    //TODO take from SO
    public int maxHealth, damage;

    public bool IsDead => _healthSystem.IsDead;

    public void Start()
    {
        _healthSystem.SetMaxHealth(maxHealth);
    }

    public void DealDamage(CharacterBattle target)
    {
        Debug.Log("Hit " + target.name + " with " + damage);
        target._HealthSystem.TakeDamage(damage);
        if (target.IsDead)
        {
            target._spriteAnimator.CharacterState = SpriteAnimator.State.dead;
        }
    }

    public void Attack(CharacterBattle target, Action onAttackComplete)
    {
        if (IsDead)
        {
            onAttackComplete();
            return;
        }
        if (_spriteAnimator != null)
        {
            _spriteAnimator.Attack(() =>
            {
                DealDamage(target);
                onAttackComplete();
            });
        }
        else
        {
            DealDamage(target);
            onAttackComplete();
        }
    }
}
