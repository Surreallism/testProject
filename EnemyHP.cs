using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public static event Action<EnemyHP> OnHealthAdded = delegate { };
    public static event Action<EnemyHP> OnHealthRemoved = delegate { };

    [SerializeField]
    private int maxHealth = 100;
    private int currentHealth { get; set; }

    public event Action<float> OnHealthPercentChanged = delegate { };

    private void OnEnable()
    {
        currentHealth = maxHealth;
        OnHealthAdded(this);
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPercent = (float)currentHealth / (float)maxHealth;
        OnHealthPercentChanged(currentHealthPercent);
    }

    private void Update()
    {
        //todo a proper dmg system from player
        if (Input.GetKeyDown(KeyCode.Space))
            ModifyHealth(-10);
    }

    private void OnDisable()
    {
        OnHealthRemoved(this);
    }
}
