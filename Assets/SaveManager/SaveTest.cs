using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
  private SaveManager saveManager;
  void Awake()
  {
    saveManager = gameObject.AddComponent<SaveManager>();
  }
  void Start()
  {
    Button loadBtn = GameObject.Find("Load").GetComponent<Button>();
    loadBtn.onClick.AddListener(load);
    Button saveBtn = GameObject.Find("Save").GetComponent<Button>();
    saveBtn.onClick.AddListener(save);
    Button deleteBtn = GameObject.Find("Delete").GetComponent<Button>();
    deleteBtn.onClick.AddListener(delete);
    
  }

  private void save()
  {
    SaveManager.SaveData newData = new SaveManager.SaveData();
    newData.day = 1;
    newData.errorCount = 2;
    newData.messages = new List<string>();
    newData.messages.Add("Hello world!");
    saveManager.Save(newData);
    Debug.Log("saved: " + newData.ToString());
  }

  private void load()
  {
    SaveManager.SaveData saveData = saveManager.Load();

    Debug.Log("loaded: " + saveData.ToString());
  }

  private void delete() {
    saveManager.DeleteSave();
    Debug.Log("deleted saveData");
  }
}

