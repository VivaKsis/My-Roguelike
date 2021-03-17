using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpriteAnimator : MonoBehaviour
{
    [SerializeField] protected Sprite[] attackFrameArray;
    [SerializeField] protected float frameRate = 0.4f;

    protected int currentFrameIndex;
    protected float timer;
    protected Action onAttackComplete;
    protected SpriteRenderer spriteRenderer;

    protected void AnimateAttack()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer -= frameRate;
            currentFrameIndex++;
            if (currentFrameIndex >= attackFrameArray.Length)
            {
                currentFrameIndex = 0;
                onAttackComplete();
            }
            spriteRenderer.sprite = attackFrameArray[currentFrameIndex];
        }
    }

    public abstract void Attack(Action onAttackComplete);
}
