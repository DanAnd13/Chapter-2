using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToFloor : MonoBehaviour
{
    public Transform sphere;
    void CountDistanceToFloor()
    {
        float distance = Mathf.Abs(sphere.position.y - transform.position.y);
        Debug.Log("Distance to floor: " + distance);
    }
    void Start()
    {
    }
    void FixedUpdate()
    {
        CountDistanceToFloor();
    }
}