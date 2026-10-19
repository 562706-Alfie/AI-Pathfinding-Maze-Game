using UnityEngine;
using TMPro;

public class PlayerGeneral : MonoBehaviour
{
    public PlayerSO player1Data;
    public GameObject gameOver;
    public GameObject camera;
    //public GameObject gameOver

    [SerializeField] private TextMeshProUGUI health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1Data.health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + player1Data.health;

        if (player1Data.health <= 0)
        {
            camera.transform.position = new Vector3(1000, 1000, 0);
            gameOver.SetActive(true);
            gameOver.transform.position = new Vector3(1000, 1000, 0);
            player1Data.GameOver();
        }
    }
}
