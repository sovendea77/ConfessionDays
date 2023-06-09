using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

[Serializable]
public class Answer
{
    public int character;
    public int time;
    public int place;
    public int crime;
}

[Serializable]
public class Option
{
    public List<string> charaOps;
    public List<string> timeOps;
    public List<string> placeOps;
    public List<string> crimeOps;
}

[Serializable]
public class AnswerList
{
    public List<Answer> answers;
}

[Serializable]
public class OptionList
{
    public List<Option> options;
}

public class Judge : MonoBehaviour
{
    public TMP_Dropdown cCharacter;
    public TMP_Dropdown cTime;
    public TMP_Dropdown cPlace;
    public TMP_Dropdown cCrime;
    public TMP_Text cText;
    public TMP_Text tText;
    public TMP_Text pText;
    public TMP_Text crText;

    public GameObject judgeCanvas;
    public static bool iscorrect;
    public static bool prePlay;
    public static bool isEnd;

    public Sprite dark1;
    public Sprite dark2;
    public GameObject background;
    public Animator curtain;
    public TMP_Text cNumber;

    public GameObject cgCanvas;
    public GameObject black;
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource bgm;
    public Texture shade;

    public GameObject courseCanvas;
    public GameObject introCanvas;
    public GameObject guideBack;
    public GameObject introduce;
    public TMP_Text guide;

    [SerializeField] public List<Answer> answers;
    [SerializeField] public List<Option> options;

    public void SetPuzzle(string name)
    {
        //dataPath
        //streamingAssetsPath
        //Path.GetDirectoryName(Application.dataPath)
        //Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        string getPath = Application.streamingAssetsPath + "/InerData/Puzzle/" + name;
        string setPath = Path.GetDirectoryName(Application.dataPath) + "/" + name;
        File.Copy(getPath, setPath, true);
    }
    
    public void ChangeCase()
    {
        if (Chat.caseCount < 7)
        {
            Chat.caseCount++;
            cNumber.text = "Case " + Chat.caseCount.ToString();
            Chat.saintTime = 0;
            SetOptions();
            Invoke("PlayCG", 1f);
        }
        else if (Chat.end != 0)
        {
            Invoke("PlayEnd", 2f);
        }
    }
    public void PlayEnd()
    {
        iscorrect = false;
        cgCanvas.SetActive(true);
        black.SetActive(true);
        string path = "CG/cg7";
        VideoClip vedio = Resources.Load<VideoClip>(path);
        videoPlayer.clip = vedio;
        prePlay = true;
        bgm.Pause();
        isEnd = true;



    }
    public void TurnEnd()
    {
        SceneManager.LoadScene("End");
    }
    public void PlayCG()
    {
        iscorrect = false;
        cgCanvas.SetActive(true);
        black.SetActive(true);
        string path = "CG/cg" + (Chat.caseCount-1).ToString();
        VideoClip vedio = Resources.Load<VideoClip>(path);
        videoPlayer.clip = vedio;
        prePlay = true;
        bgm.Pause();

    }
    public void Skip()
    {
        videoPlayer.Pause();
        finishCG(videoPlayer);
    }

    private void finishCG(VideoPlayer player)
    {
        cgCanvas.SetActive(false);
        rawImage.color = new Color(1, 1, 1, 0);
        rawImage.texture = shade;
        black.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0);
        bgm.Play();

        if(isEnd)
        {
            SceneManager.LoadScene("End");
        }
        else
        {
            Invoke("GetCourse", 0.5f);
        }
    }

    public void GetCourse()
    {
        Debug.Log("GetCourse");
        courseCanvas.SetActive(true);
        guideBack.SetActive(false);
        introCanvas.SetActive(true);
        introduce.SetActive(true);
        CanvasUtils.FadeIn(this, courseCanvas.GetComponent<CanvasGroup>(), 0.5f);
        string sPath = "Intro/intro" + Chat.caseCount.ToString();
        string tPath = Application.streamingAssetsPath + "/InerData/Intro/intro" + Chat.caseCount.ToString() + ".txt";
        Sprite sprite = Resources.Load<Sprite>(sPath);
        string gText = File.ReadAllText(tPath);
        introduce.GetComponent<UnityEngine.UI.Image>().sprite = sprite;
        guide.text = gText;
    }
    public void SetOptions()
    {
        Option tOption = options[Chat.caseCount - 1];
        List<string> chara = tOption.charaOps;
        List<string> time = tOption.timeOps;
        List<string> place = tOption.placeOps;
        List<string> crime = tOption.crimeOps;
        Debug.Log("cg");

        cCharacter.options.Clear();
        cTime.options.Clear();
        cPlace.options.Clear();
        cCrime.options.Clear();

        foreach(string s in chara)
        {
            cCharacter.options.Add(new TMP_Dropdown.OptionData(s));
        }
        foreach(string s in time)
        {
            cTime.options.Add(new TMP_Dropdown.OptionData(s));
        }
        foreach (string s in place)
        {
            cPlace.options.Add(new TMP_Dropdown.OptionData(s));
        }
        foreach (string s in crime)
        {
            cCrime.options.Add(new TMP_Dropdown.OptionData(s));
        }
        cText.text = cCharacter.options[cCharacter.value].text;
        tText.text = cTime.options[cTime.value].text;
        pText.text = cPlace.options[cPlace.value].text;
        crText.text = cCrime.options[cCrime.value].text;
    }

    public void StartJudge()
    {
        judgeCanvas.SetActive(true);
    }
    public bool CheckAnswer(int character, int time, int place, int crime)
    {
        Answer answer = answers[Chat.caseCount - 1];

        if (character == answer.character && time == answer.time && place == answer.place && crime == answer.crime)
        {
            return true;
            
        }

        return false;
    }

    public void FinishJdge()
    {
        if(Chat.saintTime%4 == 0 && !Chat.isAnswer)
        {
            if (CheckAnswer(cCharacter.value, cTime.value, cPlace.value, cCrime.value))
            {
                iscorrect = true;
                if (Chat.caseCount == 1)
                {
                    SetPuzzle("PLEASE_READ_ME.txt");
                }
                else if(Chat.caseCount == 2)
                {
                    SetPuzzle("ANGCITY_NEWSPAPER_3004TH.txt");
                    background.GetComponent<UnityEngine.UI.Image>().sprite = dark1;
                }
                else if (Chat.caseCount == 4)
                {
                    SetPuzzle("JOIN_US_NOW.png");
                    background.GetComponent<UnityEngine.UI.Image>().sprite = dark2;
                }
                else if (Chat.caseCount == 6)
                {
                    SetPuzzle("BOTTOM_SALVATION_OPERATION.png");
                    curtain.SetBool("dark", true);
                }
                    ChangeCase();

            }
            else
            {
                Debug.Log("���cw");
                iscorrect = false;
                Chat.wrongCount++;


            }
        }
        


    }
    void Start()
    {
        videoPlayer.targetTexture = new RenderTexture((int)rawImage.rectTransform.rect.width, (int)rawImage.rectTransform.rect.height, 0);
        rawImage.texture = videoPlayer.targetTexture;
        videoPlayer.loopPointReached += finishCG;

        // streamingAssetsPath
        string aPath = Application.streamingAssetsPath + "/InerData/Answer.json";
        string jsontext1 = File.ReadAllText(aPath);
        AnswerList answerList = JsonUtility.FromJson<AnswerList>(jsontext1);
        answers = answerList.answers;

        string oPath = Application.streamingAssetsPath + "/InerData/Option.json";
        string jsontext2 = File.ReadAllText(oPath);
        OptionList optionList = JsonUtility.FromJson<OptionList>(jsontext2);
        options = optionList.options;

        curtain.SetBool("dark", false);

        SetOptions();
    }


    void Update()
    {
        if(prePlay)
        {
            float color = black.GetComponent<UnityEngine.UI.Image>().color.a;
            float a = Mathf.Lerp(color, 1, 0.7f * Time.deltaTime);
            black.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, a);
            if(a > 0.9f)
            {
                black.SetActive(false);
                prePlay = false;
                rawImage.color = new Color(1, 1, 1, 1);
                videoPlayer.targetTexture = new RenderTexture((int)rawImage.rectTransform.rect.width, (int)rawImage.rectTransform.rect.height, 0);
                rawImage.texture = videoPlayer.targetTexture;
                videoPlayer.Play();
            }
        }
        cNumber.text = "Case " + Chat.caseCount.ToString();
        SetOptions();
        

    }
}
