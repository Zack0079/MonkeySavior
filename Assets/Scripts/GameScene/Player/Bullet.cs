using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
}
