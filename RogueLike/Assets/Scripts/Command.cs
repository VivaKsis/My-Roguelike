using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Command
{
    [SerializeField] private AudioClip _audioClip;
    protected AudioClip _AudioClip => _audioClip;

    public abstract void Execute(CharacterBattle executor, CharacterBattle target, Action onExecuteComplete);
}

[System.Serializable]
public class AttackCommand : Command
{
    public void DealDamage(int hitPoints, CharacterBattle target)
    {
        target._HealthSystem.TakeDamage(hitPoints);
        if (target.IsDead && target._SpriteAnimator is EnemyAnimator enemyAnimator)
        {
            enemyAnimator.CharacterState = EnemyAnimator.State.dead;
        }
    }

    public override void Execute(CharacterBattle executor, CharacterBattle target, Action onExecuteComplete)
    {
        if (executor.IsDead)
        {
            onExecuteComplete();
            return;
        }

        AudioManager.PlaySoundOnGameObject(executor.gameObject, _AudioClip);

        int hitPointsDamage = executor._Character._Damage;

        executor._SpriteAnimator.Attack(() =>
        {
            Debug.Log(executor.name + " damages " + target.name + " with " + hitPointsDamage);
            DealDamage(hitPointsDamage, target);
            onExecuteComplete();
        });
    }
}

[System.Serializable]
public class HealCommand : Command
{
    [SerializeField] private bool _canHeal;
    public bool _CanHeal => _canHeal;
    public void Heal(int hitPoints, CharacterBattle target)
    {
        target._HealthSystem.Heal(hitPoints);
    }

    public override void Execute(CharacterBattle executor, CharacterBattle target, Action onExecuteComplete)
    {
         if (executor.IsDead)
        {
            onExecuteComplete();
            return;
        }

        // TODO add sound
        //AudioManager.PlaySound(_AudioClip);

        // TODO make different for each executor
        int hitPointsToHeal = 50;

        executor._HealthSystem._HealingEffect.StartAnimation(() =>
        {
            Debug.Log(executor.name + " heals " + executor.name + " with " + hitPointsToHeal);
            Heal(hitPointsToHeal, executor);
            onExecuteComplete();
        });
    }
}
