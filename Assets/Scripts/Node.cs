using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Color startColor;
    public Color hoverColor;
    private Renderer rend;
    private GameObject turret;
    public GameObject TurretToBuild;
    public bool canvas;



    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        canvas = false;
    }
    private void OnMouseDown()
    {







        /*if(turret != null)
        {
            canvas = true;
            //Instantiate(turret);
        }
        GameObject turretToBuild = TurretToBuild;
        turret = (GameObject)Instantiate(turretToBuild);
        turret.transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);*/
    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
