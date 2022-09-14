using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "heal")
        {
            Debug.Log("health");
            Destroy(collider.gameObject);
            // + 1 health
        }
        if (collider.gameObject.tag == "armour")
        {
            Debug.Log("armour");
            Destroy(collider.gameObject);
            // + 1 armour
        }
    }
}
