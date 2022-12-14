using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Color startColor;
    public Color hoverColor;
    private Renderer rend;
    public GameObject[] turretbuildbuttons;
    public GameObject buildMenu;
    public GameObject buildMenuFire;
    public GameObject buildMenuLightning;
    public GameObject buildMenuNormal;
    public GameObject buildMenuAcid;
    public bool cantplaceturret = false;
    public GameObject canvas;

    public void deactivateall()
    {
        buildMenu.SetActive(false);
        buildMenuFire.SetActive(false);
        buildMenuAcid.SetActive(false);
        buildMenuLightning.SetActive(false);
        buildMenuNormal.SetActive(false);
        canvas.SetActive(false);
    }
    public void activateall()
    {
        buildMenu.SetActive(true);
        buildMenuFire.SetActive(true);
        buildMenuAcid.SetActive(true);
        buildMenuLightning.SetActive(true);
        buildMenuNormal.SetActive(true);
        canvas.SetActive(true);
    }
    
    
    void Start()
    {
        deactivateall();
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        
    }
    private void OnMouseDown()
    {
        activateall();
       
        



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
