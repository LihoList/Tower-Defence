
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector] public float speed;
    public float health = 100;
    public int moneyGain = 50;

    public GameObject deathEffect1;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    { 
        PlayerStats.money += moneyGain;

        GameObject effect = (GameObject)Instantiate(deathEffect1, transform.position, Quaternion.identity);
        Destroy(effect, 2);

        Destroy(gameObject);
    }    

    public void Slow(float slowValue)
    {
        speed = startSpeed * (1f - slowValue);
    }
}
