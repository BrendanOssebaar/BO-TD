using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 1;
    private Transform target;
    private int waypointindex = 0;
    public float health;
    public bool armor;
    public bool Eshield;
    public bool AcidPlating;
    public bool fireProofing;
    public HPBar hpbar;
    public float maxValue;
    public float currentHP;

    
    void Start()
    {
        target = GotoPoint.points[0];
        maxValue = 100;
        hpbar.setMaxLife(maxValue);
        currentHP = maxValue;
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
    public void getdmg(float getDMG)
    {
        currentHP -= getDMG;
        hpbar.setLife(currentHP);
    }
    void checkHP()
    {
        
        if(health <= 0)
        {
            Destroy(gameObject);
            
        }
    }
}
