using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererAnimator : MonoBehaviour
{
    [Header("Sprite Param")]
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected Sprite[] _frameArray;
    [SerializeField] protected float _frameRate = 0.4f;
    [SerializeField] protected bool _loop;

    [Header("Audio Param")]
    [SerializeField] protected AudioClip audioClip;
    [SerializeField] protected int audioStartingFrameIndex = 0;

    protected int currentFrameIndex;
    protected float timer;
    protected Action onAimationCompleted;
    protected bool onAnimate;

    protected void Animate()
    {
        timer += Time.deltaTime;

        if (timer >= _frameRate)
        {
            timer -= _frameRate;

            if (currentFrameIndex == audioStartingFrameIndex)
            {
                AudioManager.PlaySoundOnGameObject(gameObject, audioClip);
            }

            currentFrameIndex++;
            if (currentFrameIndex >= _frameArray.Length)
            {
                currentFrameIndex = 0;
                if (_loop == false)
                {
                    StopAnimation();
                }
            }
            
            _spriteRenderer.sprite = _frameArray[currentFrameIndex];
        }
    }

    protected virtual void StartAnimation(Action onAimationCompleted)
    {
        timer = 0;
        currentFrameIndex = 0;
        this.onAimationCompleted = onAimationCompleted;
        onAnimate = true;
    }

    protected void StopAnimation()
    {
        onAnimate = false;
       // onAimationCompleted();
    }

    private void Start()
    {
        StartAnimation(null);
    }

    private void Update()
    {
        if (onAnimate)
        {
            Animate();
        }
    }
}
