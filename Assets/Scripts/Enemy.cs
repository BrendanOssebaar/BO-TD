using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyType enemytype;
    public WaveSpawner waveSpawner;
    public float speed;
    public int playerdmg;
    [SerializeField]
    private Transform target;
    private int waypointindex = 0;
    public HPBar hpbar;
    public int maxValue;
    public float currentHP;
    public float worth;
    [SerializeField]
    private float resistance = 2;
    public Money mons;
    public PlayerHealth playerHealth;
    public float turnspeed = 1f;
    

    
    void Start()
    {
        target = GotoPoint.points[0];
        hpbar.setMaxLife(maxValue);
        currentHP = maxValue;
        mons = FindObjectOfType<Money>();
        playerHealth = GameObject.Find("Playerstats").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        Vector3 turntotarget = target.position - transform.position;
        float turnstep = turnspeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, turntotarget, turnstep, 1f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
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
            dealDMG();
            Destroy(gameObject);
        }



    }
    public void dealDMG()
    {
        Debug.Log(playerHealth);
        playerHealth.PlayerHP = playerHealth.PlayerHP -= playerdmg;
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
