using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_PowerUp : Projectile
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(-0.7f,0,0);
    }
}
