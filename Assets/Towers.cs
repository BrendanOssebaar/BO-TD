using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    public GameObject towerselected;
    public GameObject boundingBox;
    
    public void OnMouseDown()
    {
        if (GetComponentInParent<Node>().cantplaceturret == false) 
        {
            GetComponentInParent<Node>().cantplaceturret = true;
            GameObject obj = Instantiate(towerselected, transform.parent.transform.position, transform.parent.transform.rotation);
            Vector3 objBounds = obj.GetComponent<Renderer>().bounds.extents;
            obj.transform.position += new Vector3(0, objBounds.y / 2, 0);
            
            GetComponentInParent<Node>().deactivateall();
        }
        else
        {
            Debug.Log("Cant build there");
            GetComponentInParent<Node>().deactivateall();
        }
    }



}
