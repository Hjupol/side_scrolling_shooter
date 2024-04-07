using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Missile : Projectile
{
    private Rigidbody rb;
    private RaycastHit hit;

    public Vector3 normalForce;
    public Vector3 collidingForce;
    public Vector3 wallForce;

    private bool wallColliding, floorColiding;


    private Quaternion initialRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        wallColliding = false;
        floorColiding = false;
        initialRotation = transform.rotation;
        Physics.IgnoreLayerCollision(9, 9);
    }

    public override void Update()
    {
        if (Physics.Raycast(transform.position,Vector3.right, out hit, 3))
        {
            Debug.DrawRay(transform.position, Vector3.right * hit.distance, Color.yellow);
            this.transform.localRotation = new Quaternion(transform.localRotation.x,transform.localRotation.y,hit.collider.GetComponent<Transform>().localRotation.z-initialRotation.z,transform.localRotation.w);
            wallForce = new Vector3(wallForce.x, hit.collider.GetComponent<Transform>().rotation.z*30,wallForce.z );
            wallColliding = true;
        }
        else
        {
            wallColliding = false;
            Debug.DrawRay(transform.position, Vector3.right * 3, Color.white);
            //this.transform.rotation = initialRotation;
        }
        base.Update();
    }

    void FixedUpdate()
    {
        if (wallColliding)
        {
            rb.AddForce(wallForce);
        }
        else
        {
            this.transform.rotation = initialRotation;
            if (floorColiding)
            {
                rb.AddForce(collidingForce);
            }
            else
            {
                rb.AddForce(normalForce);
            }
        }
    }


    internal override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            floorColiding = true;
            normalForce = new Vector3(normalForce.x, -10, normalForce.z);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            floorColiding = false;
            normalForce = new Vector3(normalForce.x, -30, normalForce.z);
        }
    }
}
