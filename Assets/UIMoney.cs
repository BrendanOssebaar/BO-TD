using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMoney : MonoBehaviour
{
    public Text Money;
    public Money mons;
    public Text Health;
    public PlayerHealth playerHealth;
    void Update()
    {
        Money.text = mons.money.ToString();
        Health.text = playerHealth.PlayerHP.ToString();
    }
}
