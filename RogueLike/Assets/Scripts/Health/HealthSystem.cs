using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    public HealthBar _HealthBar => _healthBar;

    private int currentHealth, maxHealth;

    public bool IsDead => currentHealth > 0 ? false : true;

    public void SetMaxHealth(int health)
    {
        maxHealth = currentHealth = health;
    }

    private void SetHealthBar()
    {
        _healthBar.SetSize((float)currentHealth  / maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        SetHealthBar();
    }
}
