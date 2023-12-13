using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Bullet : NetworkBehaviour
{
    public float speed = 20f;


    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        //spin the prefab bullet on the y axis, without effecting direction of bullet
        transform.Rotate(0, 0, 360 * Time.deltaTime);
        Destroy(gameObject, 5f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameArea"))
        {
            Destroy(this);
        }

    }

}
