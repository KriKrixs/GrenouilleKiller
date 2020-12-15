using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;

    public AudioSource aboo;

    public AudioSource oof;

    public int health;

    public Text timer;

    public float timeStart;

    public bool countTime = true;

    private void Start()
    {
        timer.text = timeStart.ToString("F2");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Bullet")
        {
            if (health > 0)
            {
                oof.Play();
                health -= 25;
            }
            if (health == 0)
            {
                aboo.Play();
                Destroy(enemy.gameObject.GetComponent<BoxCollider2D>());
                Renderer r = enemy.GetComponent<Renderer>();
                Color alpha = r.material.color;
                alpha.a = 0;
                r.material.color = alpha;
                countTime = false;
            }
        }
    }

    private void Update()
    {
        if (countTime == true)
        {
            timeStart += Time.deltaTime;

            timer.text = timeStart.ToString("F2");
        }

        if (health == 0 && aboo.isPlaying == false)
        {
            Destroy(enemy);
        }
    }
}
