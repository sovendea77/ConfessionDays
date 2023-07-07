using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using static System.Net.Mime.MediaTypeNames;

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


    public Sprite normal;
    public Sprite dark1;
    public Sprite dark2;
    public Sprite dark3;
    public Sprite dark4;
    public Sprite dark5;
    public Sprite dark6;
    public Sprite nFate;
    public Sprite dFate;
    public GameObject background;
    public GameObject fate;
    public Animator curtain;
    public TMP_Text cNumber;

    public GameObject cgCanvas;
    public GameObject black;
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource bgm;
    public Texture shade;

    public GameObject courseCanvas;
    public GameObject nextB;
    public GameObject introCanvas;
    public GameObject guideBack;
    public GameObject introduce;
    public TMP_Text guide;
    public static String tip;

    [SerializeField] public List<Answer> answers;
    [SerializeField] public List<Option> options;


    public void SetPuzzle(string name)
    {
        //dataPath
        //streamingAssetsPath
        //Path.GetDirectoryName(Application.dataPath)
        //Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        string getPath = UnityEngine.Application.streamingAssetsPath + "/InerData/Puzzle/" + name;
        string setPath = Path.GetDirectoryName(UnityEngine.Application.dataPath) + "/" + name;
        File.Copy(getPath, setPath, true);
    }
    
    public void ChangeCase()
    {
        if (Chat.caseCount < 7)
        {
            Chat.caseCount++;
            GetHistoryClue.gotClues.Clear();
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
        //string path = "CG/cg7";
        string path = "CG/cg" + (Chat.caseCount).ToString();
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
        nextB.SetActive(true);
        guideBack.SetActive(false);
        introCanvas.SetActive(true);
        introduce.SetActive(true);
        CanvasUtils.FadeIn(this, courseCanvas.GetComponent<CanvasGroup>(), 0.5f);
        string sPath = "Intro/intro" + Chat.caseCount.ToString();
        string tPath = UnityEngine.Application.streamingAssetsPath + "/InerData/Intro/intro" + Chat.caseCount.ToString() + ".txt";
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

        //if (character != answer.character)
        //{
        //    tip += "人物 ";
        //}
        //if (time != answer.time)
        //{
        //    tip += "时间 ";
        //}
        //if (place != answer.place)
        //{
        //    tip += "地点 ";
        //}
        //if (crime != answer.crime)
        //{
        //    tip += "罪行 ";
        //}


        if (character == answer.character && time == answer.time && place == answer.place && crime == answer.crime)
        {
            tip = "";
            return true;
            
        }
        else if(time == answer.time && place == answer.place)
        {
            List<string> tips = new List<string>();
            tips.Add("我想你离真相很近，接下来就请为罪人献上忏悔吧。");
            tips.Add("罪行令这片土地不再纯净，这点毋庸置疑。但真正的罪仍需你去思索、去发掘。");
            tips.Add("我想你离真相很近了。愿主保佑逝于暴雨的灵魂。");
            int n = UnityEngine.Random.Range(0, 3);
            tip = tips[n];
        }
        else if(time == answer.time || place == answer.place)
        {
            List<string> tips = new List<string>();
            tips.Add("何时，何地。这是一个需要仔细考虑的问题；");
            tips.Add("罪人于何时、何地犯下罪行？若不知道这点，则无法为其罪过忏悔。");
            tips.Add("这个猜测仍旧存在错误的地方，但我想你很接近了。");
            int n = UnityEngine.Random.Range(0, 3);
            tip = tips[n];
        }
        else if(crime == answer.crime)
        {
            List<string> tips = new List<string>();
            if(Chat.caseCount == 1)
            {
                tips.Add("人心的贪婪永无止境，如没有贪婪，或许世上就不会有如此多的罪恶了。");
                tips.Add("贪欲令人感到永无止尽的痛苦，这往往是悲剧的预兆。");
                tips.Add("我想你离真相很近了。但愿贪婪者终能获赎。");
                int n = UnityEngine.Random.Range(0, 3);
                tip = tips[n];
            }
            else
            {
                tips.Add(" 当人对他人的成就产生不平之时，便是嫉妒的产生。");
                tips.Add("如果因为嫉妒犯下了罪行，那么百年之后终将反作用到嫉妒者的身上。");
                int n = UnityEngine.Random.Range(0, 2);
                tip = tips[n];
            }
        }
        else if(character == answer.character)
        {
            List<string> tips = new List<string>();
            tips.Add("我想你离真相很近了，然罪行尚未被全局揭晓。");
            tips.Add("请再好好想想吧，罪人所犯的罪行究竟为何？");
            tips.Add("愿罪人的灵魂终能获赎，愿主保佑人们。");
            int n = UnityEngine.Random.Range(0, 3);
            tip = tips[n];
        }
        else if(character != answer.character && time != answer.time && place != answer.place && crime != answer.crime)
        {
            List<string> tips = new List<string>();
            tips.Add("真正的罪行不在此时，不在此地，亦非此人之过。请重新想想吧。");
            tips.Add("请再好好想想吧，谁才是真正的有罪之人呢？");
            tips.Add("我想这个猜测并不正确。");
            int n = UnityEngine.Random.Range(0, 3);
            tip = tips[n];
        }


        return false;
    }

    public void FinishJdge()
    {
        if (Chat.wrongCount == 2)
        {
            background.GetComponent<UnityEngine.UI.Image>().sprite = dark1;
        }
        else if (Chat.wrongCount == 4)
        {
            background.GetComponent<UnityEngine.UI.Image>().sprite = dark2;
            curtain.SetBool("dark", true);
            fate.GetComponent<UnityEngine.UI.Image>().sprite = dFate;

        }
        else if (Chat.wrongCount == 6)
        {
            background.GetComponent<UnityEngine.UI.Image>().sprite = dark3;
        }
        else if (Chat.wrongCount == 8)
        {
            background.GetComponent<UnityEngine.UI.Image>().sprite = dark4;
        }
        else if (Chat.wrongCount == 10)
        {
            background.GetComponent<UnityEngine.UI.Image>().sprite = dark5;
        }
        else if(Chat.wrongCount == 12)
        {
            background.GetComponent<UnityEngine.UI.Image>().sprite = dark6;
        }

        if(Chat.saintTime%4 == 0 && !Chat.isAnswer)
        {
            if (CheckAnswer(cCharacter.value, cTime.value, cPlace.value, cCrime.value))
            {
                iscorrect = true;
                background.GetComponent<UnityEngine.UI.Image>().sprite = normal;
                curtain.SetBool("dark", false);
                fate.GetComponent<UnityEngine.UI.Image>().sprite = nFate;
                //if (Chat.caseCount == 1)
                //{
                //    SetPuzzle("PLEASE_READ_ME.txt");
                //}
                //else if(Chat.caseCount == 2)
                //{
                //    SetPuzzle("ANGCITY_NEWSPAPER_3004TH.txt");
                //    background.GetComponent<UnityEngine.UI.Image>().sprite = dark1;
                //}
                //else if (Chat.caseCount == 4)
                //{
                //    SetPuzzle("JOIN_US_NOW.png");
                //    background.GetComponent<UnityEngine.UI.Image>().sprite = dark2;
                //}
                //else if (Chat.caseCount == 6)
                //{
                //    SetPuzzle("BOTTOM_SALVATION_OPERATION.png");
                //    curtain.SetBool("dark", true);
                //}
                //ChangeCase();
                GetHistoryClue.gotClues.Clear();
                cNumber.text = "Case " + Chat.caseCount.ToString();
                Chat.saintTime = 0;
                Invoke("PlayEnd", 1f);

            }
            else
            {
                Debug.Log("忏悔cw");
                iscorrect = false;
                Chat.wrongCount++;

            }
        }


    }
    void Start()
    {
        background.GetComponent<UnityEngine.UI.Image>().sprite = normal;

        videoPlayer.targetTexture = new RenderTexture((int)rawImage.rectTransform.rect.width, (int)rawImage.rectTransform.rect.height, 0);
        rawImage.texture = videoPlayer.targetTexture;
        videoPlayer.loopPointReached += finishCG;
        cgCanvas.SetActive(false);

        // streamingAssetsPath
        string aPath = UnityEngine.Application.streamingAssetsPath + "/InerData/Answer.json";
        string jsontext1 = File.ReadAllText(aPath);
        AnswerList answerList = JsonUtility.FromJson<AnswerList>(jsontext1);
        answers = answerList.answers;

        string oPath = UnityEngine.Application.streamingAssetsPath + "/InerData/Option.json";
        string jsontext2 = File.ReadAllText(oPath);
        OptionList optionList = JsonUtility.FromJson<OptionList>(jsontext2);
        options = optionList.options;

        curtain.SetBool("dark", false);

        SetOptions();
    }


    void Update()
    {
        if(Chat.saintTime == 0)
        {
            GetHistory.hAnswer.Clear();
            GetHistory.hQuestion.Clear();
        }

        Debug.Log(GetHistory.hAnswer.Count + "+" +
        GetHistory.hQuestion.Count);
        if (prePlay)
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
