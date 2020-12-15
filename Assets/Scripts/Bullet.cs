using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(bullet);
    }

    private void Update()
    {
        if (transform.position.y < -10f)
        {
            Destroy(bullet);
        }
    }
}
