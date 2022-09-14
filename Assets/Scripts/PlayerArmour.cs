using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmour : MonoBehaviour
{
	public GameObject deathscreen;


	public ArmourBar armourBar;
	public int currarmour;
	public int maxarmour = 100;

	public HealthBar healthBar;
	public int health;
	public int maxhealth = 100;

	public GameObject deathEffect;

	void Start()
	{
		armourBar.SetMaxArmour(currarmour);
		healthBar.SetMaxHealth(health);
	}

	public void TakeDamagesh(int damage2)
	{
		currarmour -= damage2;

		armourBar.SetArmour(currarmour);

		if (currarmour <= 0)
		{
			TakeDamege(damage2);
		}
	}

	void TakeDamege(int damage2)
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
		deathscreen.SetActive(true);
		Destroy(gameObject);
    }

	public void armour(int amount3)
	{
		currarmour += amount3;
		armourBar.SetArmour(currarmour);

		if (currarmour >= maxarmour)
		{
			currarmour = maxarmour;
		}
	}

	public void Heal(int amount2)
	{
		health += amount2;
		healthBar.SetHealth(health);

		if (health >= maxhealth)
		{
			health = maxhealth;
		}
	}

}
