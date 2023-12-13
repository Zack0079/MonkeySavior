using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Unity.Netcode;

public class EnemyEliteController : EnemyController
{
   
    private enum State {
        IDLE,
        CHASE,
        ATTACK
    }
    private State currentState = State.IDLE;
    public GameObject bulletPrefab;
    public float shootPeriodTime = 5f;
    private float shoottime = 0f;
    private float aniamtionNeedTime = 0.23f;
    private float aniamtionTimer = 0;


    public float shootDistance = 8f;
    private bool throwAnim = true;

    void Update()
    {

        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        shoottime += Time.deltaTime;

        if (animator != null)
        {
            switch(currentState){
                case State.IDLE:
                    animator.SetBool("isRunning", false);
                    if(player.activeSelf){
                        currentState = distance > shootDistance ? State.CHASE: State.ATTACK;
                    }
                    break;
                
                case State.CHASE:
                    agent.SetDestination(player.transform.position);
                    agent.stoppingDistance = shootDistance;

                    animator.SetBool("isRunning", true);

                    if(player.activeSelf){
                        currentState = distance > shootDistance ? State.CHASE: State.ATTACK;
                    }else{
                        currentState = State.IDLE;
                    }
                    break;

                case State.ATTACK:
                    Shoot();
                    if(!throwAnim){
                        aniamtionTimer += Time.deltaTime;
                    }
                    if(player.activeSelf){
                        currentState = distance > shootDistance ? State.CHASE: State.ATTACK;
                    }
                    break;
            }
        }
        


        if (health <= 0)
        {
            scoreController.AddScore(pointsByKill);
            Destroy(gameObject);
            gameManager.defeadEnemies += 1;
        }
    }

    void Shoot()
    {

        if(throwAnim){
            animator.SetTrigger("Throw");
            throwAnim = false;
            aniamtionTimer = 0f;
        }

        if(shoottime >= shootPeriodTime && aniamtionTimer >= aniamtionNeedTime && !throwAnim){
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, rotation);
            Bullet bull = bullet.AddComponent<Bullet>();
            bull.speed = 5f;
            throwAnim = true;
            shoottime = 0f;
            aniamtionTimer = 0f;
        }

    }

}
