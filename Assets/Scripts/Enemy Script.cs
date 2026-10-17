using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemySO globalEnemyData;
    public PlayerSO player1Data;

    public int currentHealth;

    public void Start()
    {
        currentHealth = globalEnemyData.maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player1Data.PlayerTakeDamage();
        }

        if (collision.collider.CompareTag("Bullet"))
        {
            globalEnemyData.numberOfEnemies --;
            Destroy(collision.gameObject);
            Destroy(gameObject); // Destroys both the enemy and the bullet
        }
    }
}
