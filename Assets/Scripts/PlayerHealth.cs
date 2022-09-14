using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public HealthBar healthBar;
	public int health;
	public int maxhealth = 100;

	public GameObject deathEffect;

	void Start()
	{
		healthBar.SetMaxHealth(health);
		
	}

	public void TakeDamage(int damage2)
	{
		health -= damage2;

		healthBar.SetHealth(health);

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	public void Heal(int amount)
	{
		health += amount;
		healthBar.SetHealth(health);

		if (health >= maxhealth)
		{
			health = maxhealth;
		}
	}

	//public void armour(int amount)
	//{
	//	health += amount;

	//	if (health >= maxhealth)
	//	{
	//		health = maxhealth;
	//	}
	//}

}
