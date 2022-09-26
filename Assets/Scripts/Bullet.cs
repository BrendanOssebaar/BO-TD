using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed;

    public void seek(Transform _target)
    {
        target = _target;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distancethisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distancethisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distancethisFrame,Space.World);
    }

    void HitTarget()
    {
        Debug.Log("Hit");
        Destroy(gameObject);
        Destroy(target);
        return;
    }



}
