using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingEffect : Bar
{
    [SerializeField] private float animationRate;

    private bool animationOn;
    private Action onAnimationComplete;

    public void StartAnimation(Action onAnimationComplete)
    {
        this.onAnimationComplete = onAnimationComplete;
        animationOn = true;
    }

    public void StopAnimation()
    {
        animationOn = false;
        SetSizeY(0);
        onAnimationComplete?.Invoke();
    }

    private void Update()
    {
        if (animationOn)
        {
            SetSizeY(_bar.localScale.y + animationRate * Time.deltaTime);
            if (_bar.localScale.y >= 1)
            {
                StopAnimation();
            }
        }
    }
}
