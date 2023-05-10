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

        string filePath = Application.persistentDataPath + "/chatdata.json";
        mChatData.sTime = Chat.saintTime;
        mChatData.cCount = Chat.caseCount;
        mChatData.qMessages = GetHistory.hQuestion;
        mChatData.aMessages = GetHistory.hAnswer;
        string jsonStr = JsonUtility.ToJson(mChatData);
        File.WriteAllText(filePath, jsonStr);
    }

    public void LoadChat()
    {
        string filePath = Application.persistentDataPath + "/chatdata.json";
        Debug.Log(Chat.saintTime);
        if (File.Exists(filePath))
        {
            string jsonStr = File.ReadAllText(filePath);
            ChatData nChatData = JsonUtility.FromJson<ChatData>(jsonStr);
            stTime = nChatData.sTime;
            caCount = nChatData.cCount;
            GetHistory.hQuestion = nChatData.qMessages;
            GetHistory.hAnswer = nChatData.aMessages;
            Debug.Log(Chat.saintTime);
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
