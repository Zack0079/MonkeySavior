using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bulletPrefab;
    // events
    public UnityEvent onTakeDamage;
    public UnityEvent onAddHealth;
    public UnityEvent onScorePickup;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        transform.position += movement * speed * Time.deltaTime;

        // shift to run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20.0f;
        }
        else
        {
            speed = 10.0f;
        }


        if (animator != null)
        {
            if (!movement.Equals(Vector3.zero))
            {
                animator.SetFloat("Speed", speed);
            }
            else
            {
                animator.SetFloat("Speed", 0);
            }
        }

        // Shoot
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y - transform.position.y));
        // Calculate the direction to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;
        transform.rotation  = Quaternion.LookRotation(direction);
    }

    void Shoot()
    {
        // Get the Mouse Position in World Space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y - transform.position.y));
        // Calculate the direction to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;
        // Calculate the rotation to the mouse position
        Quaternion rotation = Quaternion.LookRotation(direction);
        // Instantiate the bullet with the calculated rotation
        GameObject bullet = Instantiate(bulletPrefab, transform.position, rotation);
        // Add the BulletController script to the bullet
        bullet.AddComponent<Bullet>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("damage");
            onTakeDamage.Invoke();
            
            //make player invincible for a few seconds
            StartCoroutine(Invincible());
        }
    }
    
    IEnumerator Invincible()
    {
        //disable collider
        GetComponent<Collider>().enabled = false;
        //wait for 3 seconds
        yield return new WaitForSeconds(3);
        //enable collider
        GetComponent<Collider>().enabled = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Health"))
        {
            Debug.Log("Invoke AddHealth (HealController)");
            onAddHealth.Invoke();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Score"))
        {
            Debug.Log("Invoke ADDSCORE (ScoreController)");
            onScorePickup.Invoke();
            Destroy(other.gameObject);
        }
    }
}
