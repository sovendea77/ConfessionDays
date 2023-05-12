using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
  public GameObject historyB;
  public GameObject saintB;
  public GameObject hBackB;
  public GameObject muneB;
  public GameObject mBackB;
  public GameObject sBackB;
  public GameObject cBackB;

  // guides btns
  public GameObject guideBackBtn;
  public GameObject closeTipBtn;

  public GameObject chatCanvas;
  public GameObject historyCanvas;
  public GameObject judgeCanvas;
  public GameObject charaCanvas;
  public GameObject churchCanvas;
  public GameObject muneCanvas;
  public GameObject courseCanvas;

  // guides canvas
  public GameObject guideStoryCanvas;
  public GameObject guideTipsCanvas;

  public static bool isSaint;

  private bool firstTime;

  private void Mune()
  {
    chatCanvas.SetActive(false);
    churchCanvas.SetActive(false);
    charaCanvas.SetActive(false);
    muneCanvas.SetActive(true);
    judgeCanvas.SetActive(false);
  }

  private void MuneBack()
  {
    chatCanvas.SetActive(true);
    churchCanvas.SetActive(true);
    charaCanvas.SetActive(true);
    muneCanvas.SetActive(false);
    judgeCanvas.SetActive(true);
  }

  private void History()
  {
    chatCanvas.SetActive(false);
    churchCanvas.SetActive(false);
    charaCanvas.SetActive(false);
    historyCanvas.SetActive(true);
    judgeCanvas.SetActive(false);

  }

  private void Saint()
  {
    judgeCanvas.SetActive(true);
    judgeCanvas.GetComponent<Canvas>().sortingOrder = 5;
    isSaint = true;
  }

  private void SaintBack()
  {
    judgeCanvas.GetComponent<Canvas>().sortingOrder = -5;
    isSaint = false;
  }
  private void HistoryBack()
  {
    chatCanvas.SetActive(true);
    churchCanvas.SetActive(true);
    charaCanvas.SetActive(true);
    historyCanvas.SetActive(false);
    judgeCanvas.SetActive(true);
  }

  private void ShowCourse()
  {
    courseCanvas.SetActive(true);
    CanvasUtils.FadeIn(this, courseCanvas.GetComponent<CanvasGroup>(), 0.5f);
  }

  private void HideCourse()
  {
    CanvasUtils.FadeOut(this, courseCanvas.GetComponent<CanvasGroup>(), 0.3f, () =>
    {
      courseCanvas.SetActive(false);
      // 只有第一次打开游戏才显示教程
      if (firstTime) {
        ShowGuideStory();
        PlayerPrefs.SetInt("firstTime", 0);
      }
    });
  }

  private void ShowGuideStory()
  {
    guideStoryCanvas.SetActive(true);
    CanvasUtils.FadeIn(this, guideStoryCanvas.GetComponent<CanvasGroup>(), 0.5f);
  }

  private void HideGuideStory()
  {
    CanvasUtils.FadeOut(this, guideStoryCanvas.GetComponent<CanvasGroup>(), 0.3f, () =>
    {
      guideStoryCanvas.SetActive(false);
      ShowGuideTips();
    });
  }

  private void ShowGuideTips()
  {
    guideTipsCanvas.SetActive(true);
    CanvasUtils.FadeIn(this, guideTipsCanvas.GetComponent<CanvasGroup>(), 0.5f);
  }

  private void HideGuideTips()
  {
    CanvasUtils.FadeOut(this, guideTipsCanvas.GetComponent<CanvasGroup>(), 0.3f, () =>
    {
      guideTipsCanvas.SetActive(false);
    });
  }

  private void Awake()
  {
    chatCanvas.SetActive(true);
    historyCanvas.SetActive(false);
    churchCanvas.SetActive(true);
    charaCanvas.SetActive(true);
    muneCanvas.SetActive(false);
    guideStoryCanvas.SetActive(false);
    ShowCourse();
  }
  void Start()
  {
    historyB.GetComponent<Button>().onClick.AddListener(History);
    saintB.GetComponent<Button>().onClick.AddListener(Saint);
    sBackB.GetComponent<Button>().onClick.AddListener(SaintBack);
    hBackB.GetComponent<Button>().onClick.AddListener(HistoryBack);
    muneB.GetComponent<Button>().onClick.AddListener(Mune);
    mBackB.GetComponent<Button>().onClick.AddListener(MuneBack);
    cBackB.GetComponent<Button>().onClick.AddListener(HideCourse);
    guideBackBtn.GetComponent<Button>().onClick.AddListener(HideGuideStory);
    closeTipBtn.GetComponent<Button>().onClick.AddListener(HideGuideTips);

    firstTime = PlayerPrefs.GetInt("firstTime", 1) == 1;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
