using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioFromStreamingAssetsPath : MonoBehaviour
{
    private string filePath;
    private AudioSource audioSource;

    void Start()
    {
        FindeAndPlayAudio();
    }
    void FindeAndPlayAudio()
    {
        audioSource = GetComponent<AudioSource>();
        filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "Menu_arkanoid.mp3");
        StartCoroutine(LoadAndPlayAudio(filePath));
    }

    private IEnumerator LoadAndPlayAudio(string path)
    {
        string url = path;
        using (var www = UnityEngine.Networking.UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityEngine.Networking.UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                AudioClip audioClip = UnityEngine.Networking.DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }
}
