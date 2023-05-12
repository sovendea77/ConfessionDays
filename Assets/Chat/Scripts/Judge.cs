using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

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
    public GameObject judgeCanvas;
    public static bool iscorrect;

    [SerializeField] public List<Answer> answers;
    [SerializeField] public List<Option> options;

    public void ChangeCase()
    {
        if (Chat.caseCount < 7)
        {
            Chat.caseCount++;
            iscorrect = false;
            Chat.saintTime = 1;
            SetOptions();
            Invoke("PlayCG", 1f);
        }
        else if (Chat.caseCount == 7)
        {
            Invoke("PlayEnd", 1f);
        }
    }
    public void PlayEnd()
    {

    }
    public void PlayCG()
    {

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
        if(Chat.saintTime%4 == 0)
        {
            if (CheckAnswer(cCharacter.value, cTime.value, cPlace.value, cCrime.value))
            {
                Debug.Log("âã»ÚÕýÈ·");
                iscorrect = true;
                ChangeCase();

            }
            else
            {
                Debug.Log("âã»Úcw");
                iscorrect = false;

            }
        }
        


    }
    void Start()
    {
        // streamingAssetsPath
        string aPath = Application.dataPath + "/InerData/Answer.json";
        string jsontext1 = File.ReadAllText(aPath);
        AnswerList answerList = JsonUtility.FromJson<AnswerList>(jsontext1);
        answers = answerList.answers;

        string oPath = Application.dataPath + "/InerData/Option.json";
        string jsontext2 = File.ReadAllText(oPath);
        OptionList optionList = JsonUtility.FromJson<OptionList>(jsontext2);
        options = optionList.options;

        SetOptions();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            FinishJdge();
        }

    }
}
