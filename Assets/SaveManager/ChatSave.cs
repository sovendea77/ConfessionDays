using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static ChatSave;

public class ChatSave : MonoBehaviour
{
    [Serializable]
    public class ChatData
    {
        public int sTime;
        public List<string> qMessages;
        public List<string> aMessages;
    }
    public ChatData mChatData = new ChatData();

    public void SaveChat()
    {

        string filePath = Application.dataPath + "/InerData/chatdata.json";
        mChatData.sTime = Chat.saintTime;
        mChatData.qMessages = GetHistory.hQuestion;
        mChatData.aMessages = GetHistory.hAnswer;
        string jsonStr = JsonUtility.ToJson(mChatData);
        File.WriteAllText(filePath, jsonStr);
    }

    public void LoadChat()
    {
        string filePath = Application.dataPath + "/InerData/chatdata.json";
        if (File.Exists(filePath))
        {
            string jsonStr = File.ReadAllText(filePath);
            mChatData = JsonUtility.FromJson<ChatData>(jsonStr);
            Chat.saintTime = mChatData.sTime;
            GetHistory.hQuestion = mChatData.qMessages;
            GetHistory.hAnswer = mChatData.aMessages;
        }
        else
        {
            Debug.Log("ÔÝÎÞ´æµµ£¡");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
