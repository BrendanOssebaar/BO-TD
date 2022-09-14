using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;


    void Start()
    {
        rb.velocity = transform.up * speed;
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth Player = hitInfo.GetComponent<PlayerHealth>();
        if (Player != null)
        {
            Player.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.tag == "HitAble")
        {
            Destroy(gameObject);
        }

    }
}
