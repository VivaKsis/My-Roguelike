using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : SpriteAnimator
{
    private Camera _mainCamera;
    private GameObject attackAnimation;
    private bool onAttack = false;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private Vector3 GetAttackPosition()
    {
        Vector3 position = Input.mousePosition;
        return _mainCamera.ScreenToWorldPoint(new Vector3(position.x, position.y, position.z += 10f)); // for proper ScreenToWorldPoint() work, otherwise it will return camera coordinates but not the dot
    }

    private void Update()
    {
        if (onAttack)
        {
            AnimateAttack();
        }
    }

    public override void Attack(Action onAttackComplete)
    {
        timer = 0;
        currentFrameIndex = 0;
        Cursor.visible = false;

        //TODO pool
        attackAnimation = new GameObject("Attack Animation");
        attackAnimation.transform.position = GetAttackPosition();
        attackAnimation.transform.localScale = new Vector3((float)0.1, (float)0.1, (float)0.1);
        spriteRenderer = attackAnimation.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = attackFrameArray[currentFrameIndex];

        this.onAttackComplete = () =>
        {
            Cursor.visible = true;
            Destroy(attackAnimation);
            onAttack = false;
            onAttackComplete();
        };

        onAttack = true;
    }
}
