using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthBarPrefab;

    private Dictionary<EnemyHP, HealthBar> healthBars = new Dictionary<EnemyHP, HealthBar>();

    private void Awake()
    {
        EnemyHP.OnHealthAdded += AddHealthBar;
        EnemyHP.OnHealthRemoved += RemoveHealthBar;

    }

    private void AddHealthBar(EnemyHP health)
    {
        if (healthBars.ContainsKey(health) == false)
        {
            var healthBar = Instantiate(healthBarPrefab, transform);
            healthBars.Add(health, healthBar);
            healthBar.SetHealth(health);
        }
    }

    private void RemoveHealthBar(EnemyHP health)
    {
        if (healthBars.ContainsKey(health))
        {
            Destroy(healthBars[health].gameObject);
            healthBars.Remove(health);
        }
    }

}
