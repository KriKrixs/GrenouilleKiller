using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public Camera camera;

    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -30);
    }
}
