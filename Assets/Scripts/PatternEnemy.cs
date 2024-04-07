using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternEnemy : Controller_Enemy
{
    public bool goingUp;

    public bool forward;

    private float timer=1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    override public void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            rb.velocity = Vector3.zero;
            if (forward)
            {
                forward = false;
            }
            else
            {
                goingUp = !goingUp;
                forward = true;
            }
            timer = 1f;
        }
        base.Update();
    }

    void FixedUpdate()
    {
        if (forward)
        {
            rb.AddForce(new Vector3(-1, 0, 0) * enemySpeed,ForceMode.Impulse);
        }
        else
        {
            if (goingUp)
            {
                rb.AddForce(new Vector3(-1, -1, 0) * enemySpeed, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(new Vector3(-1, 1, 0) * enemySpeed, ForceMode.Impulse);
            }
        }

    }
}
