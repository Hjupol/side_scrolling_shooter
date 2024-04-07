using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigzagEnemy : Controller_Enemy
{
    public bool goingUp;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (goingUp)
        {
            rb.AddForce(new Vector3(-1, 1, 0) * enemySpeed);
        }
        else
        {
            rb.AddForce(new Vector3(-1, -1, 0) * enemySpeed);
        }
    }

    internal override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            goingUp = true;
            //rb.velocity = Vector3.zero;
        }
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            goingUp = false;
            //rb.velocity = Vector3.zero;
        }
        base.OnCollisionEnter(collision);
    }
}
