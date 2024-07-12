using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSaves : MonoBehaviour
{
    public Transform CurrentPlayerPosition;
    private void Start()
    {
        if (PlayerPrefs.HasKey("PosX"))
            loadPosition();
    }
    private void OnDestroy()
    {
        savePosition();
    }
    public void savePosition()
    {
        PlayerPrefs.SetFloat("PosX", CurrentPlayerPosition.position.x);
        PlayerPrefs.SetFloat("PosY", CurrentPlayerPosition.position.y);
        PlayerPrefs.SetFloat("PosZ", CurrentPlayerPosition.position.z);

        PlayerPrefs.SetFloat("AngX", CurrentPlayerPosition.eulerAngles.x);
        PlayerPrefs.SetFloat("AngY", CurrentPlayerPosition.eulerAngles.y);
    }
    public void loadPosition()
    {
        Vector3 PlayerPosition = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));
        Vector3 PlayerDirection = new Vector3(PlayerPrefs.GetFloat("AngX"), PlayerPrefs.GetFloat("AngY"), 0);

        CurrentPlayerPosition.position = PlayerPosition;
        CurrentPlayerPosition.eulerAngles = PlayerDirection;
    }
}
