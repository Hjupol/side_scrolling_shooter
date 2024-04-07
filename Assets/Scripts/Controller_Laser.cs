using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Laser : Projectile
{
    public float maxGrowth;
    public float laserSpeed;
    public bool relase;
    private Vector3 maxGrowthVector;

    private Rigidbody rb;

    public GameObject parent;

    private float relaseCounter=0.2f;

    private SphereCollider sphereCollider;

    void Start()
    {
        maxGrowthVector = new Vector3(transform.localScale.x + maxGrowth, transform.localScale.y + maxGrowth, transform.localScale.z + maxGrowth);
        rb = GetComponent<Rigidbody>();
        relase = false;
        sphereCollider = GetComponent<SphereCollider>();
    }

    public override void Update()
    {
        relaseCounter -= Time.deltaTime;
        if (relaseCounter <= 0)
        {
            relase = true;
            relaseCounter = 0.2f;
        }
        if (!relase)
        {
            sphereCollider.enabled = false;
        }
        else
        {
            sphereCollider.enabled = true;
        }
        base.Update();
    }

    void FixedUpdate()
    {
        if (!relase)
        {
            if (transform.localScale.magnitude < maxGrowthVector.magnitude)
            {
                transform.localScale=new Vector3(transform.localScale.x+0.1f, transform.localScale.y + 0.1f, transform.localScale.z + 0.1f);
            }
            transform.position = parent.transform.position;
        }
        else
        {
            rb.velocity=new Vector3(laserSpeed, 0, 0);
        }
    }
}
