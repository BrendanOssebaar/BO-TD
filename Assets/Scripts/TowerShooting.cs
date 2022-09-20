using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    [SerializeField]private Transform target;
    public float range = 10f;
    public string enemyTag = "Enemy";

    public void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    private void Update()
    {
        if(target == null)
        {
            return;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }







    /* public Transform firepoint;
     public GameObject bulletPrefab;
     public float fireRate;
     public float nextFire;
     Vector3 enemyPos;
     private Rigidbody rb;
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
         Vector3 lookDirection = enemyPos;
         float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
         rb.rotation = angle;
     }*/
}
