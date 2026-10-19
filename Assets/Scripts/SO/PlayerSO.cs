using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public EnemySO globalEnemyData;

    public float health;
    public Vector2 speed;
    public float fov = 90f;
    public float viewDistance = 10f;

    /*
    // This method is not the method from MonoBehaviour, it is instead activated in 'Player general' start(), which is a method from MonoBehaviour.
    public void Start()
    {
        gameOver = GameObject.Find("Game Over");
    }
    */
    public void PlayerTakeDamage()
    {
        health = health - globalEnemyData.damage;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
    }

    public void ChangeFieldOfView()
    {
        if (fov == 120 && viewDistance == 15)
        {
            fov = 60;
            viewDistance = 30;
        }
        else
        {
            fov = 120;
            viewDistance = 15;
        }
    }
}
