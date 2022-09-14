using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;
    

    void Start()
    {
        rb.velocity = transform.up * speed;
        Destroy(gameObject, 1f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        Destroy(gameObject);
        }
        if (hitInfo.gameObject.tag == "HitAble")
        {
            Destroy(gameObject);
        }

    }
}
