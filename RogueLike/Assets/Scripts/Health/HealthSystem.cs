using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    public HealthBar _HealthBar => _healthBar;
    [SerializeField] private HealingEffect _healingEffect;
    public HealingEffect _HealingEffect => _healingEffect;

    private int currentHealth, maxHealth;

    public float GetHealthPercent => (float)currentHealth / maxHealth;
    public bool IsDead => currentHealth > 0 ? false : true;

    public void SetMaxHealth(int health)
    {
        maxHealth = currentHealth = health;
    }

    private void SetHealthBar()
    {
        _healthBar.SetSizeX((float)currentHealth  / maxHealth);
    }

    public void TakeDamage(int hitPoints)
    {
        currentHealth -= hitPoints;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        SetHealthBar();
    }

    public void Heal(int hitPoints)
    {
        currentHealth += hitPoints;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        SetHealthBar();
    }
}
