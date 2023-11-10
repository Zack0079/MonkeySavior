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

        // Shoot
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            onTakeDamage.Invoke();
        }
    }
}
