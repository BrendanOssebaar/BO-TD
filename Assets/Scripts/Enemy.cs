using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1;
    private Transform target;
    private int waypointindex = 0;
    public int health;
    public bool armor;
    public bool Eshield;
    public bool AcidPlating;
    public bool fireProofing;



    void Start()
    {
        target = GotoPoint.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }
        checkHP();
    }
    void GetNextWaypoint()
    {
        //heb ik nog een volgende waypoint?
        //zo ja, ga naar die waypoint
        //zo nee, verwijder mijzelf
        if(waypointindex+1 < GotoPoint.points.Length)
        {
            waypointindex++;
            target = GotoPoint.points[waypointindex];
        }
        else
        {
            //Do dmg to player
            Destroy(gameObject);
        }



    }
    void checkHP()
    {
        
        if(health <= 0)
        {
            Destroy(gameObject);
            return;
        }
    }
}
