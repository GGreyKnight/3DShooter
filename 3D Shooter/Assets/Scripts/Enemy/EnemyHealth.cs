using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private  Slider healthbarSlider;
    [SerializeField] private  Image healthbarFillImage;
    [SerializeField] private  Color maxHealthColor;
    [SerializeField] private  Color minHealthColor;

    private int currentHealth;

    private void Start()
    {
        currentHealth = enemyStats.maxHealth;
        SetHealthBarUI();
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        CheckIfDead();
        SetHealthBarUI();
    }

    private void CheckIfDead()
    {
        if(currentHealth<=0)
        {
            Destroy(gameObject);
        }
    }

    private void SetHealthBarUI()
    {
        float healthPercentage = CalculateHealthPercentage();
        healthbarSlider.value = healthPercentage;
        healthbarFillImage.color = Color.Lerp(minHealthColor, maxHealthColor, healthPercentage/100);
    }

    private float CalculateHealthPercentage()
    {
        return ((float)currentHealth / (float)enemyStats.maxHealth)*100;
    }
}
