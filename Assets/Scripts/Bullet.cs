using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float lightningDMG;
    public float AcidDMG;
    public float FireDMG;
    public float DMG;
    public GameObject impactbullet;
    

    public void seek(Transform _target)
    {
        target = _target;
    }
    void Start()
    {
        DMG = DMG + lightningDMG + AcidDMG + FireDMG;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 dir = target.position - transform.position;
        float distancethisFrame = speed * Time.deltaTime;
        if (target == null)
        {
            Destroy(gameObject);

        }
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
        target.GetComponent<Enemy>().health = target.GetComponent<Enemy>().health - DMG;
        //target.GetComponent<Enemy>().getdmg(DMG);


    }


}
