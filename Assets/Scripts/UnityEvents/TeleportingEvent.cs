using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingEvent : MonoBehaviour
{
    public Transform floor;
    public void OnEnable()
    {
        EventManager.OnClicked += Teleport;
    }
    public void OnDisable()
    {
        EventManager.OnClicked -= Teleport;
    }
    void Teleport()
    {
        Vector3 pos = transform.position;
        pos.x = Random.Range(0, floor.lossyScale.x / 2);
        pos.z = Random.Range(0, floor.lossyScale.z / 2);
        transform.position = pos;
    }
}
