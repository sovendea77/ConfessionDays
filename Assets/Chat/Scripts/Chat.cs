using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;


[Serializable]
public class PostData
{
    public string model;
    //public int max_tokens;
    public List<SendData> messages;
}

[Serializable]
public class SendData
{
    public string role;
    public string content;
    public SendData() { }
    public SendData(string mrole, string mcontent)
    {
        role = mrole;
        content = mcontent;
    }

}
[Serializable]
public class BackMessage
{
    public string id;
    public string created;
    public string model;
    public List<MessageBody> choices;
}
[Serializable]
public class MessageBody
{
    public Message message;
    public string finish_reason;
    public string index;
}
[Serializable]
public class Message
{
    public string role;
    public string content;
}


public class WebReqSkipCert : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}

public class Chat : MonoBehaviour
{
    public TMP_InputField mInput;
    public TMP_Text bText;

    private string apiKey = "//apikey在上传git时不要暴露，会被禁用";
    public string apiUrl = "http://aiopen.deno.dev/v1/chat/completions";
    public string mModel = "gpt-3.5-turbo";
    public string prompt;

    [SerializeField] public List<SendData> dataList = new List<SendData>();

    private void Start()
    {
        dataList.Add(new SendData("system", prompt));
    }

    public IEnumerator GetPostData(string postWord, string apiKey)
    {
        dataList.Add(new SendData("user", postWord));
        GetHistory.hQuestion.Add(postWord);

        using (UnityWebRequest request = new UnityWebRequest(apiUrl, "POST"))
        {
            PostData postData = new PostData
            {
                model = mModel,
                //max_tokens = 100,
                messages = dataList
            };

            string jsonText = JsonUtility.ToJson(postData);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonText);
            request.uploadHandler = new UploadHandlerRaw(data);
            request.downloadHandler = new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", string.Format("Bearer {0}", apiKey));
            //request.SetRequestHeader("Authorization", "Bearer " + _openAI_Key);
            yield return request.SendWebRequest();
            //Debug.Log(jsonText);

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                //PlanB
                Debug.LogError(request.error);
            }
            else
            {
                string backmessage = request.downloadHandler.text;
                BackMessage backtext = JsonUtility.FromJson<BackMessage>(backmessage);
                {

                    string thmessage = backtext.choices[0].message.content;
                    dataList.Add(new SendData("assistant", thmessage));
                    bText.text = thmessage;
                    GetHistory.hAnswer.Add(thmessage);
                }
            }

        }
    }

    void Awake()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string input = mInput.text;
            StartCoroutine(GetPostData(input, apiKey));
            mInput.text = "";
        }
    }

}