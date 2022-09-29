using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject turretToBuild;
    public static BuildManager instance;
    public GameObject standardTurretPrefab;

    public void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Multiple Buildmanagers detected");
            return;
        }
    }
    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
