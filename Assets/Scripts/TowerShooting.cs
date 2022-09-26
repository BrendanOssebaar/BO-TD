using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    [SerializeField] private Transform target;

    [Header("Attributes")]

    public float range = 10f;
    public float firerate = 1f;
    public float firecountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public Transform parttorotate;
    public GameObject bulletprefab;
    public Transform firepoint;
                
    

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

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        parttorotate.rotation = lookRotation;

        if(firecountdown <= 0f)
        {
            Shoot();
            firecountdown = 1f / firerate;
        }
        firecountdown -= Time.deltaTime;

    }
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.seek(target);
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
