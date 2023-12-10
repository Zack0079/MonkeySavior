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
    private MainManager mainManager;

    // sound effect
    public AudioClip damageSound;
    public AudioClip healingSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
        
        GameObject tmp  = GameObject.Find("MainManager"); 
        if(tmp != null){
          mainManager = tmp.GetComponent<MainManager>();
            if (mainManager.health > 3)
            {
                health = mainManager.health;
            }
        }

        audioSource = GetComponent<AudioSource>(); // And this line
        healthText.text = "Health: " + health;

        //Get the ground object from scene and spawn items on it within its area
        ground = GameObject.Find("Ground");
        // bounds = ground.GetComponent<MeshRenderer>().bounds;
    

        InvokeRepeating("SpawnHealthPickUp", 0f, spawnDelay);

    }

    void SpawnHealthPickUp()
    {
        if (generatedItem < item_amount)
        {
            //find random position within bounds of ground
            // Vector3 spawnPosition = new Vector3( Random.Range(bounds.min.x, bounds.max.x), bounds.center.y + 1, Random.Range(bounds.min.z, bounds.max.z) );
            float distance = Random.Range(1f, radius);
            float angle = Random.Range(0f, Mathf.PI * 2);
            Vector3 spawnPosition = player.transform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * distance;

            spawnPosition.y = 1f;

            // bounds.min.z and y
            float min = -50f;
            float max = 50f;
            if (min > spawnPosition.x)
            {
                spawnPosition.x = min;
            }
            else if (max < spawnPosition.x)
            {
                spawnPosition.x = max;
            }

            if (min > spawnPosition.z)
            {
                spawnPosition.z = min;
            }
            else if (max < spawnPosition.z)
            {
                spawnPosition.z = max;
            }

            GameObject pickUP= Instantiate(healthPickupPrefab, spawnPosition, Quaternion.identity);
            pickUP.transform.position = pickUP.transform.position.normalized * Mathf.Min(pickUP.transform.position.magnitude, 50f);

            generatedItem += 1;
        }
    }

    void Update()
    {
        if (health < 0)
        {
            health = 0;
        }
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
        if (mainManager != null)
        {
            mainManager.health = health;
        }

        audioSource.PlayOneShot(damageSound);
    }

    public void AddHealth(int amount)
    {
        health += amount;
        generatedItem -= 1;
        if (mainManager != null)
        {
            mainManager.health = health;
        }
        audioSource.PlayOneShot(healingSound);
    }

}
