using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Option : MonoBehaviour
{
    public Controller_Player parent;

    private Vector3 offset;

    private GameObject laser;
    private float missileCount;

    private void Awake()
    {
        //Controller_Player._Player.OnShooting += Shoot;
    }

    void Start()
    {
        
        Controller_Player._Player.OnShooting += Shoot;
        parent = Controller_Player._Player;
        offset = new Vector3(parent.transform.position.x - this.transform.position.x, parent.transform.position.y - this.transform.position.y, parent.transform.position.z - this.transform.position.z);
    }

    

    private void FixedUpdate()
    {
        if(parent!=null)
            transform.position = parent.transform.position - offset;
    }

    
    private void Update()
    {
        missileCount -= Time.deltaTime;
        if (parent == null)
            Destroy(this.gameObject);

        if (Input.GetKey(KeyCode.O))
        {
            if (laser != null)
            {
                laser.GetComponent<Controller_Laser>().relase = false;
            }
        }
        else
        {
            if (laser != null)
            {
                laser.GetComponent<Controller_Laser>().relase = true;
                laser = null;
            }
        }
    }

    public void Shoot()
    {
        if (parent.laserOn)
        {
            laser = Instantiate(parent.laserProjectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            laser.GetComponent<Controller_Laser>().parent = this.gameObject;
        }
        else
        {
            Instantiate(parent.projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            if (parent.doubleShoot)
            {
                parent.doubleProjectile.GetComponent<Controller_Projectile_Double>().directionUp = Controller_Player.lastKeyUp;
                Instantiate(parent.doubleProjectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            if (parent.missiles)
            {
                if (missileCount < 0)
                {
                    Instantiate(parent.missileProjectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 90));
                    missileCount = 2;
                }
            }
        }
        
        
        
    }


    //void OnEnable()
    //{
    //    Controller_Player._Player.OnShooting += Shoot;
    //}

    void OnDisable()
    {
        Controller_Player._Player.OnShooting -= Shoot;
    }
}
