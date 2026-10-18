using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public EnemySO globalEnemyData;

    public float health;
    public Vector2 speed;
    public float fov = 90f;
    public float viewDistance = 10f;

    public void PlayerTakeDamage()
    {
        health = health - globalEnemyData.damage;
    }
}
