using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public ParticleSystem particle;
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
        {

            ParticleSystem obj = Instantiate(particle);
            Destroy(obj, 10);
           
        }
    }
}
