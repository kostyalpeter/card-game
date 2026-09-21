using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    private string saveFilePath;

    private void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/save.json";
    }

    public void SaveGame()
    {
        Save data = new Save();

        IEnumerable<ISaveable> saveables = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<ISaveable>();
        foreach (ISaveable saveable in saveables)
        {
            saveable.SaveData(data);
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);

    }

    public void LoadGame()
    {
        if (!File.Exists(saveFilePath))
        {
            return;
        }

        string json = File.ReadAllText(saveFilePath);
        Save data = JsonUtility.FromJson<Save>(json);

        IEnumerable<ISaveable> saveables = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<ISaveable>();
        foreach (ISaveable saveable in saveables)
        {
            saveable.LoadData(data);
        }

    }
}