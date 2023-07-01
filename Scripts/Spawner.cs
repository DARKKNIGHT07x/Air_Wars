using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Enemy;
    //public Transform[] spawnPoints;
    public float respawnTime = 7f;
    public int Enemy_SpawnCount = 10;
    public GameController gameController;
    public PlayerMovementClamp Player;
    private bool LastEnemySpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        if (LastEnemySpawned && FindObjectOfType<Enemy_Shoot>() == null )
        {
            StartCoroutine(gameController.LevelCompletePanel());
        }
    }
    IEnumerator EnemySpawner()
    {
        for(int i = 0; i< Enemy_SpawnCount; i++)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
        LastEnemySpawned = true ;
        

        
        
    }
    void SpawnEnemy()
    {
        int RandomEnemy = Random.Range(0,Enemy.Length);
        // double max = 1.6;
        // float min = -1.6;
        int Random_X_Position = Random.Range(-2,2);
        Instantiate(Enemy[RandomEnemy], new Vector2(Random_X_Position,transform.position.y), Quaternion.identity);
    }
}
