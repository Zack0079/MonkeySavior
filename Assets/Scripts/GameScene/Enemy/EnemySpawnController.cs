using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Netcode;

public class EnemySpawnController : NetworkBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyElitePrefab;
    public GameObject player;

    public float radius = 10.0f;
    public int numberOfEnemies = 10;
    public float spawnDelay = 10.0f;
    public int waves = 3;
    int spawnedMonkey = 0;
    int difficulty = 1;

    public int eliteEnemyRatioToEnemy = 5;


    private GameManager gameManager;
    private MainManager mainManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        GameObject tmp  = GameObject.Find("MainManager"); 
        if(tmp != null){
          mainManager = tmp.GetComponent<MainManager>();
          difficulty = mainManager.difficulty;
        }

        numberOfEnemies = numberOfEnemies * difficulty;


        InvokeRepeating("SpawnEnemies", 0f, spawnDelay);
        gameManager.totalEnemies = numberOfEnemies*waves;
    }

    void SpawnEnemies()
    {
      if(mainManager.mulitplayerMode && !IsServer){return;}

      if(spawnedMonkey < waves*numberOfEnemies){
        for (int i = 0; i < numberOfEnemies; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfEnemies;
            Vector3 spawnPosition = player.transform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            
            GameObject tmp = (i+1)%eliteEnemyRatioToEnemy > 0 ? enemyPrefab : enemyElitePrefab;
            
            Instantiate(tmp, spawnPosition, Quaternion.identity);
            spawnedMonkey++;

            SpawnEnemyClientRpc((i+1)%eliteEnemyRatioToEnemy > 0,spawnPosition);

        }
      }
    }


    
    [ClientRpc]
    private void SpawnEnemyClientRpc(bool value, Vector3 spawnPosition){
      GameObject tmp = value ? enemyPrefab : enemyElitePrefab;
        Instantiate(tmp, spawnPosition, Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.transform.position, radius);

    }
}
