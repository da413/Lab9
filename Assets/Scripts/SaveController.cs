using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<string> ids = new List<string>();
    public List<string> jsonData = new List<string>();
}

public class SaveController : MonoBehaviour
{
    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "save.json");
        Debug.Log($"Save Path : {savePath}");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadSave();
        }
    }

    private void Save()
    {
        var allMono = FindObjectsOfType<MonoBehaviour>(true);
        List<IJsonSaveable> saveableList = new List<IJsonSaveable>();

        foreach (var mono in allMono)
        {
            if(mono is IJsonSaveable saveable)
            {
                saveableList.Add(saveable);
            }
        }
        
        SaveData saveData = new SaveData();

        foreach (var saveable in saveableList)
        {
            saveData.ids.Add(saveable.SaveID);
            saveData.jsonData.Add(saveable.SaveData());
        }

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(savePath, json);

        Debug.Log($"Saved {saveData.ids.Count} objects to {savePath}");
    }
    
    private void LoadSave()
    {
        if (!File.Exists(savePath))
        {
            Debug.LogWarning("No save file found!");
            return;
        }

        string json = File.ReadAllText(savePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        
        var allMono = FindObjectsOfType<MonoBehaviour>(true);
        List<IJsonSaveable> saveableList = new List<IJsonSaveable>();

        foreach (var mono in allMono)
        {
            if(mono is IJsonSaveable saveable)
            {
                saveableList.Add(saveable);
            }
        }

        int loadedCount = 0;

        for (int i = 0; i < saveData.ids.Count; i++)
        {
            string id = saveData.ids[i];
            string savedJson = saveData.jsonData[i];

            foreach (var saveable in saveableList)
            {
                if (saveable.SaveID == id)
                {
                    saveable.LoadData(savedJson);
                    loadedCount++;
                    break;
                }
            }
        }

        Debug.Log($"Loaded {loadedCount} items from save file.");
    }
}
