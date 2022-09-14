using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

	public int damage2 = 20;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start()
	{

	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		//PlayerHealth Player = hitInfo.GetComponent<PlayerHealth>();
		PlayerArmour Player2 = hitInfo.GetComponent<PlayerArmour>();
		if (Player2 != null)
		{
			Player2.TakeDamagesh(damage2);

		}
		//if (Player != null)
		//{
		//	Player.TakeDamage(damage2);
		//}


		//Instantiate(impactEffect, transform.position, transform.rotation);

	}

}
