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
        public int cCount;
        public List<string> qMessages;
        public List<string> aMessages;
    }
    public ChatData mChatData = new ChatData();

    public static int stTime = 1;
    public static int caCount = 1;

    public void SaveChat()
    {
        //persistentDataPath
        string filePath = Path.Combine(Application.persistentDataPath, "chatdata.json");

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        mChatData.sTime = Chat.saintTime;
        mChatData.cCount = Chat.caseCount;
        mChatData.qMessages = GetHistory.hQuestion;
        mChatData.aMessages = GetHistory.hAnswer;
        string jsonStr = JsonUtility.ToJson(mChatData);
        File.WriteAllText(filePath, jsonStr);
    }

    public void LoadChat()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "chatdata.json");
        if (File.Exists(filePath))
        {
            string jsonStr = File.ReadAllText(filePath);
            ChatData nChatData = JsonUtility.FromJson<ChatData>(jsonStr);
            Chat.saintTime = stTime = nChatData.sTime;
            Chat.caseCount = caCount = nChatData.cCount;
            GetHistory.hQuestion = nChatData.qMessages;
            GetHistory.hAnswer = nChatData.aMessages;

        }
        else
        {
            stTime = 1;
            caCount = 1;
            GetHistory.hQuestion.Clear();
            GetHistory.hAnswer.Clear();
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
