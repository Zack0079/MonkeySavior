using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int health = 3;
    public AudioClip damageSound;
    private AudioSource audioSource;


    // create a ui for health
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: " + health;
        audioSource = GetComponent<AudioSource>(); // And this line
    }

    void Update()
    {
        healthText.text = "Health: " + health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        audioSource.PlayOneShot(damageSound);
    }

    public void AddHealth(int amount)
    {
        health += amount;
    }

}
