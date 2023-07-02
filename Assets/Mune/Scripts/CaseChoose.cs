using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class CaseChoose : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public GameObject checkCanvas;
    public GameObject vedioCanvas;
    public bool ischeck;

    public void Check()
    {
        ischeck = true;
    }
    public void Case1()
    {
        ChatSave.stTime = 1;
        ChatSave.caCount = 1;
        GetHistory.hQuestion.Clear();
        GetHistory.hAnswer.Clear();
        checkCanvas.SetActive(false);
        vedioCanvas.SetActive(true);
        videoPlayer.Play();
        Invoke("Check", 2f);
    }
    public void Case2()
    {
        ChatSave.stTime = 1;
        ChatSave.caCount = 2;
        GetHistory.hQuestion.Clear();
        GetHistory.hAnswer.Clear();
        checkCanvas.SetActive(false);
        vedioCanvas.SetActive(true);
        videoPlayer.Play();
        Invoke("Check", 2f);
    }

    void Start()
    {
        ischeck = false;
        videoPlayer.targetTexture = new RenderTexture((int)rawImage.rectTransform.rect.width, (int)rawImage.rectTransform.rect.height, 0);
        rawImage.texture = videoPlayer.targetTexture;

    }
    public void SkipCG()
    {
        SceneManager.LoadScene("Saint");
    }
    // Update is called once per frame
    void Update()
    {
        if (!videoPlayer.isPlaying && ischeck)
        {
            SceneManager.LoadScene("Saint");
        }
    }
}
