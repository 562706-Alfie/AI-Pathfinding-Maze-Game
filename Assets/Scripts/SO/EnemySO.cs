using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/EnemySO")]
public class EnemySO : ScriptableObject
{
    public int numberOfEnemies;
    public int maxHealth;
    public int damage;
    public float attackCooldown;
}
