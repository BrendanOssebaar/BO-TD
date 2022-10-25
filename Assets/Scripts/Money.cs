using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Money : MonoBehaviour
{
    public float money;
    public WaveSpawner cash;
    
    public void SetstartMoney(float mons)
    {
        cash.startmoney = mons;
    }

    

}
