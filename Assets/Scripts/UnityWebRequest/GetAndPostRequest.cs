using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetAndPostRequest : MonoBehaviour
{
    private string getUrl = "https://jsonplaceholder.typicode.com/posts/1"; // «м≥нити на потр≥бний URL
    private string postUrl = "https://jsonplaceholder.typicode.com/posts";

    void Start()
    {
        //StartCoroutine(GetRequest(getUrl));
        StartCoroutine(PostRequest(postUrl));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                string jsonResponse = webRequest.downloadHandler.text;
                Post post = JsonUtility.FromJson<Post>(jsonResponse);
                Debug.Log("Title: " + post.title);
                Debug.Log("Body: " + post.body);
            }
        }
    }
    IEnumerator PostRequest(string uri)
    {
        Post postData = new Post { title = "some information", body = "Example", userId = 1 };
        string json = JsonUtility.ToJson(postData);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, "application/json"))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            webRequest.uploadHandler = new UploadHandlerRaw(jsonToSend);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                string jsonResponse = webRequest.downloadHandler.text;
                Post responsePost = JsonUtility.FromJson<Post>(jsonResponse);
                Debug.Log("Title: " + responsePost.title);
                Debug.Log("Body: " + responsePost.body);
            }
        }
    }
    [System.Serializable]
    public struct Post
    {
        public int userId;
        public int id;
        public string title;
        public string body;
    }
}
