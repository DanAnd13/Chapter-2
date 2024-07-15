using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveJsonToStreamingAssets : MonoBehaviour
{
    [System.Serializable]
    public struct UserData
    {
        public string userName;
        public string dateTime;
    }

    [System.Serializable]
    public class UserDataWrapper
    {
        public List<UserData> users = new List<UserData>();
    }

    public TMP_InputField userNameField;
    public TextMeshProUGUI outputData;
    private string filePath;
    private UserDataWrapper userDataWrapper = new UserDataWrapper();
    string json;

    void Start()
    {
        filePath = Path.Combine(Application.streamingAssetsPath, "userData.json");
        LoadData();
        UpdateOutputData();
    }

    void Update()
    {
        UpdateOutputData();
    }

    void Create()
    {
        UserData userData = new UserData();
        userData.userName = userNameField.text;
        userData.dateTime = DateTime.Now.ToString();
        userDataWrapper.users.Add(userData);
        json = JsonUtility.ToJson(userDataWrapper, true);
        SaveData();
        UpdateOutputData();
    }

    public void WriteToJSON()
    {
        Create();
        LoadData();
    }

    void LoadData()
    {
        if (File.Exists(filePath))
        {
            json = File.ReadAllText(filePath);
            userDataWrapper = JsonUtility.FromJson<UserDataWrapper>(json);
        }
    }

    void SaveData()
    {
        File.WriteAllText(filePath, json);
    }

    void UpdateOutputData()
    {
        outputData.text = "";
        foreach (UserData user in userDataWrapper.users)
        {
            outputData.text += user.userName + " " + user.dateTime + "\n";
        }
    }
}
