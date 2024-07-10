using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderNormalizeDirection : MonoBehaviour
{
    float speed = 2.0f;
    public Vector3 direction = new Vector3(1, 0, 0);
    void CylinderMovement()
    {
        Vector3 movement = direction * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    void Start()
    {
        direction = direction.normalized;
    }

    void Update()
    {
        CylinderMovement();
    }
}
