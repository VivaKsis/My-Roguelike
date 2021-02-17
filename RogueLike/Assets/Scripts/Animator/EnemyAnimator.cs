using System;
using UnityEngine;

public class EnemyAnimator : SpriteAnimator
{
    [SerializeField] private Sprite idleFrame, deadFrame;

    public State CharacterState = State.idle;

    public enum State
    {
        idle, 
        attack,
        dead
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Idle()
    {
        spriteRenderer.sprite = idleFrame;
    }

    private void Dead()
    {
        spriteRenderer.sprite = deadFrame;
    }

    private void Update()
    {
        switch (CharacterState)
        {
            case State.idle:
                Idle();
                break;
            case State.attack:
                AnimateAttack();
                break;
            case State.dead:
                Dead();
                break;
            default:
                break;
        }
    }

    public override void Attack(Action onAttackComplete)
    {
        timer = 0;
        currentFrameIndex = 0;

        this.onAttackComplete = () =>
        {
            CharacterState = State.idle;
            onAttackComplete();
        };

        CharacterState = State.attack;
    }
}
