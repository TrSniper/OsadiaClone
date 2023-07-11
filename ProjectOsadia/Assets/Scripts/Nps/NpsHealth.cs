using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpsHealth : MonoBehaviour
{
    private HealthSystemComponent hpComponent;
    private HealthSystem healthSystem;
    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        hpComponent = GetComponent<HealthSystemComponent>();
        healthSystem =  hpComponent.GetHealthSystem();
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
            healthSystem.Damage(10f/*bullet.damageamount*/);
        }
    }

    private void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            Debug.Log("Caným azaldý! Þu anki caným: " + currentHealth);
        }


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Nps öldü!");
    }
}
