using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPrefabFromResources : MonoBehaviour
{
    private GameObject spawnPoint;
    private GameObject prefab;

    void Start()
    {
        GetObjectFromResources();
    }
    void GetObjectFromResources()
    {
        spawnPoint = GetComponent<Transform>().gameObject;
        prefab = Resources.Load<GameObject>("Player");
        if (prefab != null)
        {
            Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
