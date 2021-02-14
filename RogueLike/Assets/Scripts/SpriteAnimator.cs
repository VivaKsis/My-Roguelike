using System;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private Sprite idleFrame, deadFrame;
    [SerializeField] private Sprite[] attackFrameArray;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public State CharacterState = State.idle;

    private int currentFrameIndex;
    private float timer, frameRate = .5f;
    private Action onAttackComplete;

    public enum State
    {
        idle, 
        attack,
        dead
    }

    private void Idle()
    {
        spriteRenderer.sprite = idleFrame;
    }

    private void Dead()
    {
        spriteRenderer.sprite = deadFrame;
    }

    private void AnimateAttack()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer -= frameRate;
            currentFrameIndex++;
            if(currentFrameIndex >= attackFrameArray.Length)
            {
                currentFrameIndex = 0;
                onAttackComplete();
                CharacterState = State.idle;
            }
            spriteRenderer.sprite = attackFrameArray[currentFrameIndex];
        }
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

    public void Attack(Action onAttackComplete)
    {
        timer = 0;
        currentFrameIndex = 0;
        this.onAttackComplete = onAttackComplete;
        CharacterState = State.attack;
    }
}
