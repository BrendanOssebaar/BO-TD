using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public float fireRate;
    public float nextFire;
    void Start()
    {
        
    }
    public void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        nextFire = Time.time + fireRate;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Shoot();
        }
    }
}
