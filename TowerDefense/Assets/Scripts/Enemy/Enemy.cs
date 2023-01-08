using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector] public float speed;

    public float health = 100;
    public int moneyReward = 50;

    public GameObject enemyDeathFx;

    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }

    void Die()
    {
        PlayerStats.Money += moneyReward;

        GameObject fxInstance = Instantiate(enemyDeathFx, transform.position, Quaternion.identity);
        Destroy(fxInstance, 5f);
        Destroy(gameObject);
    }
}
