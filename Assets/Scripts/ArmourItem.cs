using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourItem : MonoBehaviour
{

	public int amount3 = 20;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start()
	{

	}


	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		PlayerArmour Player2 = hitInfo.GetComponent<PlayerArmour>();
		if (Player2 != null)
		{
			Player2.armour(amount3);
			Destroy(gameObject);
		}

		Instantiate(impactEffect, transform.position, transform.rotation);

	}

}
