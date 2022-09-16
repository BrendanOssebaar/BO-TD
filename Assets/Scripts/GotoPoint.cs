using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoPoint : MonoBehaviour
{
    public GameObject[] waypoints;
    public float speed = 1;
    void Update()
    {
        
        for(int i = 0; i < waypoints.Length; i++)
        {
            transform.position = waypoints[i].transform.position* speed * Time.deltaTime;
        }

    }
    void Start()
    {
        
    }

    
}
