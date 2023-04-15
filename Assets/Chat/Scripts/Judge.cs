using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

[Serializable]
public class Answer
{
    public int character;
    public int time;
    public int place;
    public int crime;
}

[Serializable]
public class AnswerList
{
    public List<Answer> answers;
}

public class Judge : MonoBehaviour
{
    public TMP_Dropdown cCharacter;
    public TMP_Dropdown cTime;
    public TMP_Dropdown cPlace;
    public TMP_Dropdown cCrime;
    public GameObject judgeCanvas;
    public AudioClip wrongSaint;
    public AudioClip correctSaint;
    public static bool iscorrect;

    [SerializeField] public List<Answer> answers;

    public void StartJudge()
    {
        judgeCanvas.SetActive(true);
    }
    public bool CheckAnswer(int character, int time, int place, int crime)
    {
        foreach (Answer answer in answers)
        {
            if(character == answer.character && time == answer.time && place == answer.place && crime == answer.crime)
            {
                return true;
            }
        }
        return false;
    }

    public void FinishJdge()
    {
        if(Chat.saintTime%5 == 0 && Chat.saintTime != 0)
        {
            if (CheckAnswer(cCharacter.value, cTime.value, cPlace.value, cCrime.value))
            {
                judgeCanvas.GetComponent<AudioSource>().clip = correctSaint;
                judgeCanvas.GetComponent<AudioSource>().Play();
                Debug.Log("âã»ÚÕýÈ·");
                iscorrect = true;

            }
            else
            {
                judgeCanvas.GetComponent<AudioSource>().clip = wrongSaint;
                judgeCanvas.GetComponent<AudioSource>().Play();
                Debug.Log("âã»Ú´íÎó");

            }
        }


    }
    void Start()
    {
        
        string path = Application.streamingAssetsPath + "/InerData/Answer.json";

        string jsontext = File.ReadAllText(path);
        AnswerList answerList = JsonUtility.FromJson<AnswerList>(jsontext);
        answers = answerList.answers;

    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            FinishJdge();
        }


    }
}
