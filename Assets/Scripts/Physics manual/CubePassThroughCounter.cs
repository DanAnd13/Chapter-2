using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubePassThroughCounter : MonoBehaviour
{
    int throughCounter;
    bool isSphereLayer(Collider sphereObject)
    {
        if (sphereObject.gameObject.layer == LayerMask.NameToLayer("Sphere"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void CountOfPassThrough()
    {
        throughCounter++;
        Debug.Log("Count of pass through: " + throughCounter);
    }
    void Start()
    {
        throughCounter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isSphereLayer(other))
        {
            CountOfPassThrough();
        }
    }
}
