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
    private bool doubledhp;
    public HPBar hpbar;
    private bool tripledhp;
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
        doubledhp = false;
        tripledhp = false;
        target = GotoPoint.points[0];
        hpbar.setMaxLife(maxValue);
        currentHP = maxValue;
        mons = FindObjectOfType<Money>();
        playerHealth = GameObject.Find("Playerstats").GetComponent<PlayerHealth>();
        waveSpawner = GameObject.Find("Spawnpoint").GetComponent<WaveSpawner>();
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
    /*public float doubleHP()
    {
        if(waveSpawner.waveNumber == 3)
        {
            currentHP = currentHP * 2;
            return currentHP;
        }
    }*/
    void checkHP()
    {
        if (waveSpawner.waveNumber == 3 && doubledhp == false)
        {
            currentHP = currentHP * 2;
            doubledhp = true;
        }
        if (waveSpawner.waveNumber == 6 && tripledhp == false)
        {
            currentHP = currentHP * 2;
            tripledhp = true;
        }
        if (currentHP <= 0)
        {
            Destroy(gameObject);
            mons.money += worth;
        }
        
        
    }
}
