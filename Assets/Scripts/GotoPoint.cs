using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoPoint : MonoBehaviour
{
    public static Transform[] points;
    

    private void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }


    /*void Update()
    {
        
        if(transform.position == waypoints[i])
        {
            transform.position = waypoints[i].transform.position* speed * Time.deltaTime;
        }

    }
    void Start()
    {
        
    }*/

    
}
