using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCounterOfBounce : MonoBehaviour
{
    int bounceCount;
    void CountOfBounce()
    {
        bounceCount++;
        Debug.Log("Count of bounce: " + bounceCount);
    }
    void Start()
    {
        bounceCount = 0;   
    }

    private void OnCollisionEnter(Collision collision)
    {
        CountOfBounce();
    }
}