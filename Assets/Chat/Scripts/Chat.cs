using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

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
    public GameObject bTextBody;
    public GameObject inputBody;
    public GameObject confirmButton;
    public Animator anim;
    public GameObject saintB;
    public GameObject black;

    public static int saintTime = 1;
    public static int caseCount = 1;
    public static int end = 0;
    public static int wrongCount;

    public static bool isAnswer;
    //apikey不要上传git
    private string apiKey = "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";
    public string apiUrl = "http://aiopen.deno.dev/v1/chat/completions";
    public string mModel = "gpt-3.5-turbo";
    public string prompt;

    [SerializeField] public List<SendData> dataList = new List<SendData>();

    public string[] keywords;

    private void Start()
    {
        //Application.streamingAssetsPath
        //Application.dataPath
        GetClues();
        GetKeywords();
    }



    IEnumerator PutText(string text)
    {
        for (int j = 0; j < text.Length; j++)
        {
            string word = text.Substring(0, j);
            bText.text = word;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        confirmButton.SetActive(true);
        mInput.interactable = true;

    }

    public void GetClues()
    {
        dataList.Clear();
        dataList.Add(new SendData("system", prompt));
        string textPath = Application.dataPath + "/InerData/Test/test" + caseCount.ToString() + ".txt";
        string knowledgeText = File.ReadAllText(textPath);
        Debug.Log(knowledgeText);
        dataList.Add(new SendData("user", knowledgeText));
    }
    public void GetKeywords()
    {
        string kwPath = Application.dataPath + "/InerData/Keyword/keywords" + caseCount.ToString() + ".txt"; ;
        string kwText = File.ReadAllText(kwPath);
        keywords = kwText.Split(';');
       
    }
    public bool CheckKeyword(string input)
    {
        foreach(string keyword in keywords)
        {
            if(input.Contains(keyword))
            {
                Debug.Log(keyword);
                return true;
            }
        }
        return false;
    }
    public IEnumerator GetPostData(string inputWord, string apiKey)
    {
        string postWord = "default";

        if (CheckKeyword(inputWord))
        {
            postWord = inputWord;
        }

        dataList.Add(new SendData("user", postWord));

        Debug.Log(postWord);
        if (saintTime % 4 == 0)
        {
            GetHistory.hQuestion.Clear();
        }

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
                int n = UnityEngine.Random.Range(1, 10);
                anim.SetTrigger("ex" + n.ToString());
                bTextBody.SetActive(true);
                isAnswer = true;
                if (inputWord != "")
                {
                    StartCoroutine(PutText("网络错误，请重试。"));
                }
                else
                {
                    StartCoroutine(PutText("…………"));
                }
                
                
                //saintTime--;
            }
            else
            {
                string backmessage = request.downloadHandler.text;
                BackMessage backtext = JsonUtility.FromJson<BackMessage>(backmessage);
                {
                    if (saintTime % 4 == 0)
                    {
                        GetHistory.hAnswer.Clear();
                        dataList.Clear();
                        dataList.Add(new SendData("system", prompt));
                        string textPath = Application.dataPath + "/InerData/Test/test"+caseCount.ToString()+ ".txt";
                        string knowledgeText = File.ReadAllText(textPath);
                        Debug.Log(knowledgeText);
                        dataList.Add(new SendData("user", knowledgeText));
                        dataList.Add(new SendData("user", postWord));
                    }
                    int n = UnityEngine.Random.Range(1, 10);
                    anim.SetTrigger("ex" + n.ToString());
                    string thmessage = backtext.choices[0].message.content;
                    dataList.Add(new SendData("assistant", thmessage));

                    GetHistory.hAnswer.Add(thmessage);
                    GetHistory.hQuestion.Add(inputWord);
                    bTextBody.SetActive(true);
                    isAnswer = true;
                    if(inputWord != "" || inputWord != "")
                    {
                        StartCoroutine(PutText(thmessage));
                    }
                    else
                    {
                        StartCoroutine(PutText("…………"));
                    }

                }
            }

        }
    }

    public void StartChat()
    {
        string input = mInput.text;
        StartCoroutine(GetPostData(input, apiKey));
        mInput.text = "";

    }

    public void CheckChat()
    {
        if (isAnswer)
        {
            bText.text = " ";
            bTextBody.SetActive(false);
            saintTime++;
            if (saintTime % 4 == 0 && caseCount != 7)
            {
                mInput.interactable = false;
            }
            else
            {
                mInput.interactable = true;
            }
            isAnswer = false;

        }
        else
        {
            if(saintTime % 4 != 0)
            {
                confirmButton.SetActive(false);
                mInput.interactable = false;
            }
            StartChat();
            

        }
    }

    public void CheckEnd()
    {
        string key = "AD2879Silentsentinel7603SDhN";
        string input = mInput.text;

        if (wrongCount >= 3)
        {
            SceneManager.LoadScene ("End");
            end = 3;
        }

        if (caseCount == 7 && saintTime % 4 == 0 && !isAnswer)
        {
            if (input.ToUpper() == key.ToUpper())
            {
                end = 1;
            }
            else
            {
                end = 2;
            }
        }

    }
    void Awake()
    {
        Judge.iscorrect = false;
        black.SetActive(false);
        saintTime = ChatSave.stTime;
        caseCount = ChatSave.caCount;
        //caseCount = 7;
        this.GetComponent<AudioSource>().Play();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) && !isAnswer && !Buttons.isSaint)
        {
            CheckChat();
        }
        
        if(isAnswer)
        {
            inputBody.SetActive(false);
        }
        else
        {
            inputBody.SetActive(true);
        }
        
        if(saintTime%4 == 0 && !isAnswer)
        {
            saintB.SetActive(true);
        }
        else
        {
            saintB.SetActive(false);
        }

        //if (Judge.iscorrect)
        //{
        //    black.SetActive(true);
        //    float color = black.GetComponent<RawImage>().color.a;
        //    float a = Mathf.Lerp(color, 1, 0.7f * Time.deltaTime);
        //    black.GetComponent<RawImage>().color = new UnityEngine.Color(0, 0, 0, a);
        //}

        if (Judge.iscorrect)
        {
            GetClues();
            GetKeywords();
        }

        Debug.Log("case"+caseCount);
        Debug.Log("saint"+saintTime);
        Debug.Log("end" + end);
    }


}