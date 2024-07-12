using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SphereCastRadius : MonoBehaviour
{
    [Range(0.5f, 2f)]
    public float radius = 0.5f;
    [Range(0f, 360f)]
    public float angle = 0f;
    Vector3 rotation;
    Vector3 direction;
    void Update()
    {
        rotation = new Vector3 (0, angle, 0);
        transform.rotation = Quaternion.Euler(rotation);
        direction = transform.forward;
        DrawSphereCast();
    }
    void DrawSphereCast()
    {
        if (Physics.SphereCast(transform.position, radius, direction, out RaycastHit hitInfo))
        {
            Debug.Log("SphereCast hit: " + hitInfo.collider.gameObject.name);
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);

            Debug.DrawRay(hitInfo.point, hitInfo.normal * radius, Color.green);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + direction * radius, Color.red);
        }
    }
}
