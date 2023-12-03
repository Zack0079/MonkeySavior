using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int health = 3;
    public int item_amount = 15;
    public GameObject healthPickupPrefab;
    private GameObject ground;
    private GameObject player;
    public GameObject gameOverCanvas;

    //spawn health pack neear the player
    public float radius = 10.0f;
    public float spawnDelay = 5f;

    // create a ui for health
    public TextMeshProUGUI healthText;

    private Bounds bounds;
    public int generatedItem = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        healthText.text = "Health: " + health;

        //Get the ground object from scene and spawn items on it within its area
        ground = GameObject.Find("Ground");
        bounds = ground.GetComponent<MeshRenderer>().bounds;

        InvokeRepeating("SpawnHealthPickUp", 0f, spawnDelay);

    }

    void SpawnHealthPickUp()
    {
        if ( generatedItem < item_amount)
        {
            //find random position within bounds of ground
            // Vector3 spawnPosition = new Vector3( Random.Range(bounds.min.x, bounds.max.x), bounds.center.y + 1, Random.Range(bounds.min.z, bounds.max.z) );
            float distance = Random.Range(1f, radius);
            float angle = Random.Range(0f, Mathf.PI * 2);
            Vector3 spawnPosition = player.transform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * distance;

            spawnPosition.y = 1f;

            if (bounds.min.x > spawnPosition.x)
            {
                spawnPosition.x = bounds.min.x;
            }
            else if (bounds.max.x < spawnPosition.x)
            {
                spawnPosition.x = bounds.max.x;
            }

            if (bounds.min.z > spawnPosition.z)
            {
                spawnPosition.z = bounds.min.z;
            }
            else if (bounds.max.z < spawnPosition.z)
            {
                spawnPosition.z = bounds.max.z;
            }


            Instantiate(healthPickupPrefab, spawnPosition, Quaternion.identity);
            generatedItem+=1;
        }
    }

    void Update()
    {
        healthText.text = "Health: " + health;

        if (health <= 0)
        {
            player.SetActive(false);
            gameOverCanvas.SetActive(true);

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void AddHealth(int amount)
    {
        health += amount;
        generatedItem-=1;
    }

}
