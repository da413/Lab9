using System;
using UnityEngine;

[System.Serializable]
public class TransformData
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public string saveID;
}

public class TransformSaver : MonoBehaviour, IJsonSaveable
{
    [SerializeField, HideInInspector]
    private string saveID = Guid.NewGuid().ToString();
    public string SaveID => saveID;

    private void OnValidate()
    {
        if (string.IsNullOrEmpty(saveID))
        {
            saveID = Guid.NewGuid().ToString();
        }
    }

    private void Awake()
    {
        if (string.IsNullOrEmpty(saveID))
        {
            saveID = Guid.NewGuid().ToString();
        }
    }

    public string SaveData()
    {
        TransformData data = new TransformData
        {
            position = transform.position,
            rotation = transform.rotation,
            scale = transform.localScale,
            saveID = SaveID
        };

        return JsonUtility.ToJson(data);
    }
    
    public void LoadData(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            Debug.LogWarning("Save data is empty!");
            return;
        }

        TransformData loadedData = JsonUtility.FromJson<TransformData>(data);

        transform.position = loadedData.position;
        transform.rotation = loadedData.rotation;
        transform.localScale = loadedData.scale;
    }
}
