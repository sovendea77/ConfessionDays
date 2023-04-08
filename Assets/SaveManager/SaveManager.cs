using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveManager : MonoBehaviour
{
    [System.Serializable]
    public struct SaveData
    {
        public int day;
        public int errorCount;
        public List<string> messages;

        override public string ToString()
        {
            return "day: " + day + ", errorCount: " + errorCount + ", messages: " + messages;
        }
    }

    private string saveFilePath = "/save.json";

    public void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + saveFilePath, json);
    }

    public SaveData Load()
    {
        string filePath = Application.persistentDataPath + saveFilePath;
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            return default(SaveData);
        }
    }

    public void DeleteSave()
    {
        string filePath = Application.persistentDataPath + saveFilePath;
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
