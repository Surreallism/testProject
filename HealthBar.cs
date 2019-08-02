using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private float updateSpeedSeconds = 0.2f;
    [SerializeField]
    private float positionOffset = 2f;

    private EnemyHP health;

    public void SetHealth(EnemyHP health)
    {
        this.health = health;
        health.OnHealthPercentChanged += HandleHealthChanged;
    }


    private void HandleHealthChanged(float percent)
    {
        StartCoroutine(ChangeToPercent(percent));
    }

    private IEnumerator ChangeToPercent(float percent)
    {
        float preChangePercent = foregroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePercent, percent, elapsed / updateSpeedSeconds);
            yield return null;
        }
        foregroundImage.fillAmount = percent;
    }

    private void LateUpdate()
    {
        //todo change camera function so it is faster
        transform.position = Camera.main.WorldToScreenPoint(health.transform.position + Vector3.up * positionOffset);
    }

    private void OnDestroy()
    {
        health.OnHealthPercentChanged -= HandleHealthChanged;
    }

}
