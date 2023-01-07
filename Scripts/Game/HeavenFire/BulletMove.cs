using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    float bulletSpeed;
    Vector3 bulletDir;
    void Start()
    {
        bulletSpeed = 50;
        bulletDir = Camera.main.transform.forward;
    }

    void Update()
    {
        this.gameObject.transform.position += bulletDir * bulletSpeed * Time.deltaTime;
        Destroy(this.gameObject, 60);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
