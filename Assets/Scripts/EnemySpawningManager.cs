using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawningManager : MonoBehaviour
{
    public EnemySO globalEnemyData;
    public Transform player;
    public Transform aimTransform;

    List<GameObject> enemySpawnPoints = new();
    public GameObject enemySpawnPoint1;
    public GameObject enemySpawnPoint2;
    public GameObject enemySpawnPoint3;
    public GameObject enemy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalEnemyData.numberOfEnemies = 0; //The data within the asset doesn't reset when exiting/restarting, so it must be done here
        enemySpawnPoints.Add(enemySpawnPoint1);
        enemySpawnPoints.Add(enemySpawnPoint2);
        enemySpawnPoints.Add(enemySpawnPoint3);

    }

    // Update is called once per frame
    void Update()
    {
        if(globalEnemyData.numberOfEnemies < globalEnemyData.maxNumberOfEnemies)
        {
            SpawnEnemy();
        }
    }
    public void SpawnEnemy()
    {
        int chosenSpawnPoint = UnityEngine.Random.Range(0, enemySpawnPoints.Count);
        GameObject spawnPoint = enemySpawnPoints[chosenSpawnPoint];
        GameObject clone = Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
        globalEnemyData.numberOfEnemies ++;

        VisionVisibility vision = clone.GetComponent<VisionVisibility>(); //FovVisibility
        vision.player = player;
        vision.aimTransform = aimTransform;
    }
}
