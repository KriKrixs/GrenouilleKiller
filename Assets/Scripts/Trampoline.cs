using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public AudioSource boing;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        print("pouet");
        boing.Play();
    }
}
