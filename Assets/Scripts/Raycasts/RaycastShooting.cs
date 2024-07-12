using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class RaycastShooting : MonoBehaviour
{
    public float rayDistance = 100f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rayOrigin = Camera.main.transform.position;
            Vector3 rayDirection = Camera.main.transform.forward;

            DrawRaycast(rayOrigin, rayDirection);
        }
    }
    void DrawRaycast(Vector3 rayOrigin, Vector3 rayDirection)
    {
        if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hitInfo, rayDistance))
        {
            Debug.Log("Raycast hit: " + hitInfo.collider.gameObject.name);
            Debug.DrawLine(rayOrigin, hitInfo.point, Color.red, 2.0f);

            PushObject(hitInfo);
        }
        else
        {
            Debug.DrawLine(rayOrigin, rayOrigin + rayDirection * rayDistance, Color.red, 2.0f);
        }
    }
    void PushObject(RaycastHit hitInfo)
    {
        Rigidbody rb = hitInfo.collider.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(-hitInfo.normal * 10f, ForceMode.Impulse);
        }
    }
}
