using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Net;

public class SetCourse : MonoBehaviour
{
    public GameObject background;
    public GameObject introduce;
    public TMP_Text guide;

    public void GetCourse()
    {
        switch(Chat.caseCount)
        {
            case 1:
                background.SetActive(true);
                goto case 2;
            case 2:
            case 3:
            case 5:
            case 6:
                //streamingAssetsPath
                string sPath = Application.dataPath + "/InerData/Intro/intro" + Chat.caseCount.ToString() + ".png";
                string tPath = Application.dataPath + "/InerData/Intro/intro" + Chat.caseCount.ToString() + ".txt";
                Sprite sprite = Resources.Load<Sprite>(sPath);
                string gText = File.ReadAllText(tPath);
                introduce.GetComponent<Image>().sprite = sprite;
                guide.text = gText;
                break;
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
