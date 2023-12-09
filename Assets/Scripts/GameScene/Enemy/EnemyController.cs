using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected GameObject player;
    protected ScoreController scoreController;
    protected Animator animator;

    protected GameManager gameManager;


    public int pointsByKill = 1;
    protected int health = 3;

    public GameObject healthPickupPrefab;
    public GameObject scorePickupPrefab;

    // sound effect
    protected AudioSource audioSource;
    public AudioClip collisionSound;

    protected void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        //on a 1/10 chance, 
        if (UnityEngine.Random.Range(0, 20) == 0)
        {
            //spawn a health pickup
            GameObject healthPickup = Instantiate(healthPickupPrefab);
            healthPickup.transform.position = this.transform.position;
            //move it to the left a bit
            healthPickup.transform.position += new Vector3(-1, 0, 0);
        }

        if (UnityEngine.Random.Range(0, 10) == 0)
        {
            GameObject scorePickup = Instantiate(scorePickupPrefab);
            scorePickup.transform.position = this.transform.position;
            scorePickup.transform.position += new Vector3(1, 0, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        //find player
        player = GameObject.Find("Player");
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeSelf)
        {
            float distance = Vector3.Distance(this.transform.position, player.transform.position);
            agent.SetDestination(player.transform.position);

            if (animator != null)
            {
                animator.SetBool("isRunning", true);
                if (distance < 2f)
                {
                    animator.SetTrigger("Attack");
                }
            }
        }


        if (health <= 0)
        {
            scoreController.AddScore(pointsByKill);
            Destroy(gameObject);
            gameManager.defeadEnemies += 1;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            audioSource.PlayOneShot(collisionSound);
            Destroy(collision.gameObject);
            health--;
        }
    }
}
