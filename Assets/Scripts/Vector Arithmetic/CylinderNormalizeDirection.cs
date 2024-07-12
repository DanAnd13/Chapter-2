using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderNormalizeDirection : MonoBehaviour
{
    public Vector3 direction = new Vector3(1, 0, 0);
    float speed = 2.0f;
    void Start()
    {
        direction = direction.normalized;
    }
    void Update()
    {
        CylinderMovement();
    }
    void CylinderMovement()
    {
        Vector3 movement = direction * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}
