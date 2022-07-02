
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector] public float speed;
    public float startHealth = 100;
    [HideInInspector] public float health;
    public int moneyGain = 50;

    public Image healthBar;

    public GameObject deathEffect1;

    bool isDead = false;

    private void Start()
    {   
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        PlayerStats.money += moneyGain;

        GameObject effect = (GameObject)Instantiate(deathEffect1, transform.position, Quaternion.identity);
        Destroy(effect, 2);

        Destroy(gameObject);

        WaveManager.enemiesAlive--;
    }    

    public void Slow(float slowValue)
    {
        speed = startSpeed * (1f - slowValue);
    }
}
