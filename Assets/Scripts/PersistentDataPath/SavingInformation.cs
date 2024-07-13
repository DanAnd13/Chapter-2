using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SavingInformation : MonoBehaviour
{
    public TMP_InputField inputText;
    public TextMeshProUGUI outputText;
    private string filePath;
    void Start()
    {
        LoadText();
    }
    public void SaveText()
    {
        string textToSave = inputText.text;
        File.WriteAllText(filePath, textToSave);

        outputText.text = textToSave;
    }
    void LoadText()
    {
        filePath = Path.Combine(Application.persistentDataPath, "savedText.txt");

        // Завантаження тексту при запуску
        if (File.Exists(filePath))
        {
            string savedText = File.ReadAllText(filePath);
            outputText.text = savedText;
        }
        else
        {
            outputText.text = "Немає збереженого тексту";
        }
    }
}
