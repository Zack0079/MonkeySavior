using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private ScoreController scoreController;
    public int pointsByKill = 1;
    private int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //find player
        player = GameObject.Find("Player");
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);

        if (health <= 0)
        {
            scoreController.AddScore(pointsByKill);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health--;
        }
    }
}
