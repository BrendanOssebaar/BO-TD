using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{
    public GameObject SpikePrefab;
    public GameObject Player;
    public GameObject firePoint;

    public float fireRateSpike;
    private float nextSpike;

    public float range;
    private float distToPlayer;

    private void Awake()
    {
        Player = GameObject.Find("player");
    }

    private void ShootSpike()
    {
        Instantiate(SpikePrefab, firePoint.transform.position, firePoint.transform.rotation);
        nextSpike = Time.time + fireRateSpike;
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, Player.transform.position);

        if (distToPlayer <= range && Time.time > nextSpike)
        {
            Debug.Log("shoot");
            ShootSpike();
        }

        
    }
}
