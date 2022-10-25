using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyType enemytype;
    public float speed = 1;
    private Transform target;
    private int waypointindex = 0;
    public HPBar hpbar;
    public float maxValue = 100;
    public float currentHP;
    public float worth;
    [SerializeField]
    private float resistance = 2;
    public Money mons;

    
    void Start()
    {
        target = GotoPoint.points[0];
        hpbar.setMaxLife(maxValue);
        currentHP = maxValue;
        mons = FindObjectOfType<Money>();
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
    public void getdmg(float getDMG, EnemyType type)
    {
        if(enemytype == type)
        {
            currentHP -= getDMG / resistance;
        }
        else
        {
            currentHP -= getDMG;
        }

        hpbar.setLife(currentHP);
    }
    void checkHP()
    {
        
        if(currentHP <= 0)
        {
            Destroy(gameObject);
            mons.money += worth;
        }
    }
}
