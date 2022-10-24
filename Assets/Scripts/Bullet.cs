using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyType { Acid, Fire, Lightning, Armor, Normal}
public class Bullet : MonoBehaviour
{

    public EnemyType enemytype;
    public Transform target;
    public float speed;
    public float lightningDMG;
    public float AcidDMG;
    public float FireDMG;
    public float DMG;
    public float dmg;
    public GameObject impactbullet;
    

    public void seek(Transform _target)
    {
        target = _target;
    }
    void Start()
    {
        dmg = DMG + lightningDMG + AcidDMG + FireDMG;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distancethisFrame = speed * Time.deltaTime;
        
        if (dir.magnitude <= distancethisFrame)
        {
            HitTarget();
            
        }
        transform.Translate(dir.normalized * distancethisFrame,Space.World);
    }

    void HitTarget()
    {
        dealdmg();
        Debug.Log("Hit");
        GameObject effectIns = (GameObject)Instantiate(impactbullet, transform.position, transform.rotation);
        Destroy(effectIns, 3f);
        Destroy(gameObject);
        
    }
    public void dealdmg()
    {
        
        target.GetComponent<Enemy>().getdmg(dmg, enemytype);


    }


}
