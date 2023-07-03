using UnityEngine;

public class ChangeHealth : MonoBehaviour,IHealth,IHealable,IDamageable
{
    // bu kod ileride de�i�ecek ve/ya b�y�k ihtimalle ortadan kalkacak, sadece demonstrasyon i�in yaz�ld�.
    // Edit: bu Class bir manager Class haline d�n��ebilir.

    //Can�m�z� g�rmek i�in ay�rd���m de�i�ken
    //[SerializeField]public static float health;

    //Hasar ve Can yenileme miktarlar�, bunlar b�y�k ihtimalle ayr�-
    //bir interface'e al�nacak ve ordaki bir metodun arg�manlar� �eklinde kullan�lacak.

    [SerializeField]private int damageAmount = 20;
    [SerializeField]private int healAmount = 10;
    [SerializeField]private int maxHealth = 100;
    public int Health { get; set; }
    public int MaxHealth { get; set; }

    public delegate void HealthChanger();
    public static event HealthChanger OnDeath;

    private void Awake()
    {
        Health = maxHealth;
        MaxHealth = maxHealth;
        //Event Atamalar�
        RunManager.OnHealed += Heal;
        RunManager.OnDamaged += TakeDamage;
        RunManager.OnShowHealth += ShowHealth;
    }
    private void ShowHealth()
    {
        Debug.Log("Can : " + Health);
        Debug.Log("Can Y�zdesi : " + (float)Health / MaxHealth);
    }
    public float GetHealthAndPercentage(bool isPercentage)
    {
        if(isPercentage)
        {
            return (float)Health/MaxHealth;
        }
        else
        {
            return (float)Health; 
        }
    }
    private void TakeDamage()
    {    
        Health -= damageAmount;
        Debug.Log("Hasar Al�nd� : " + damageAmount);
        if(Health == 0)
            OnDeath();
    }

    private void Heal()
    {
        if (!RunEnder.isDead && Health < 150f)
        {   Health += healAmount;
            Debug.Log("�yile�ildi : " + healAmount);
        }
    }
}
