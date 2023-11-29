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
    
    // create a ui for health
    public TextMeshProUGUI healthText;
    
    

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: " + health;
        
        //Get the ground object from scene and spawn items on it within its area
        ground = GameObject.Find("Ground");
        Bounds bounds = ground.GetComponent<MeshRenderer>().bounds;
        
        for (int i = 0; i < item_amount; i++)
        {
            //find random position within bounds of ground
            Vector3 spawnPosition = new Vector3( Random.Range(bounds.min.x, bounds.max.x), bounds.center.y + 1, Random.Range(bounds.min.z, bounds.max.z) );
            Instantiate(healthPickupPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        healthText.text = "Health: " + health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void AddHealth(int amount)
    {
        health += amount;
    }

}
