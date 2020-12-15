using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject gun;

    public bool isTaken = false;

    public GameObject GunPoint;
    
    public Transform firePoint;

    public GameObject bulletPrefab;

    public float bulletForce;

    public int bullets;

    public int reloadBullets;

    public int magazines;

    public AudioSource piou;

    public AudioSource crikcrik;

    public AudioSource recharge;

    public AudioSource cling;
    
    public AudioSource grille;
    
    public Text BulletText;
    
    public Text MagazineText;

    private void Start()
    {
        reloadBullets = bullets;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            crikcrik.Play();
            Destroy(gun.gameObject.GetComponent<BoxCollider2D>());
            isTaken = true;
        }
    }

    void Update()
    {
        BulletText.text = "";
        MagazineText.text = "";
        
        if (isTaken == true)
        {
            BulletText.text = bullets.ToString() + " Bullets left";
            MagazineText.text = magazines.ToString() + " Magazines left";
            transform.localScale = new Vector3(0.5f, 0.5f, 0f);
            transform.position = new Vector3(GunPoint.transform.position.x + 0.5f, GunPoint.transform.position.y + 0.1f, 0f);
        }

        if (Input.GetButtonDown("Fire1") && bullets > 0 && isTaken == true) 
        {
            piou.Play();
            Vector3 firePointFixed = new Vector3(firePoint.transform.position.x + 1f, firePoint.transform.position.y);
            GameObject bullet = Instantiate(bulletPrefab, firePointFixed, bulletPrefab.transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            bullets--;
        }

        if (Input.GetButtonDown("Fire1") && bullets == 0 && magazines > 0)
        {
            cling.Play();
        } 
        else if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Reload")) && bullets == 0 && magazines == 0)
        {
            if (grille.isPlaying == false)
            {
                grille.Play();
            }
        }
        
        if (Input.GetButtonDown("Reload") && magazines > 0)
        {
            recharge.Play();
            bullets = reloadBullets;
            magazines--;
        }
    }
}
