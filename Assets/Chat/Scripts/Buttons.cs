using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Buttons : MonoBehaviour
{
  public GameObject historyB;
  public GameObject saintB;
  public GameObject hBackB;
  public GameObject muneB;
  public GameObject mBackB;
  public GameObject sBackB;
  public GameObject cBackB;
  public GameObject nextB;

  // guides btns
  public GameObject guideBackBtn;
  public GameObject closeTipBtn;
  public GameObject closeGuideSaintBtn;
  public GameObject closeGuideSaintBackBtn;
  
  public GameObject toPromptBtn;

  public GameObject chatCanvas;
  public GameObject historyCanvas;
  public GameObject judgeCanvas;
  public GameObject charaCanvas;
  public GameObject churchCanvas;
  public GameObject muneCanvas;
  public GameObject courseCanvas;
  public GameObject background;
  public GameObject introduce;
  public GameObject guide;

    // guides canvas
  public GameObject guideStoryCanvas;
  public GameObject guideTipsCanvas;
  public GameObject guideSaintCanvas;
  public GameObject guideSaintBackCanvas;

  public TMP_InputField prompt;

  public static bool isSaint;

  private bool firstTime;

    private void Next()
    {
        if(background.activeSelf)
        {
            background.SetActive(false);
            introduce.SetActive(true);
        }
        else
        {
            introduce.SetActive(false);
            guide.SetActive(true);
        }
    }    

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
    ShowGuideSaintBack();
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
      if (firstTime || Debug.isDebugBuild) {
        ShowGuideTips();
        PlayerPrefs.SetInt("firstTime", 0);
      }
    });

    guide.SetActive(false);
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

  public void ShowGuideSaint()
  {
    guideSaintCanvas.SetActive(true);
    CanvasUtils.FadeIn(this, guideSaintCanvas.GetComponent<CanvasGroup>(), 0.5f);
  }

  public void HideGuideSaint()
  {
    CanvasUtils.FadeOut(this, guideSaintCanvas.GetComponent<CanvasGroup>(), 0.3f, () =>
    {
      guideSaintCanvas.SetActive(false);
    });
  }

  public void ShowGuideSaintBack()
  {
    guideSaintBackCanvas.SetActive(true);
    CanvasUtils.FadeIn(this, guideSaintBackCanvas.GetComponent<CanvasGroup>(), 0.5f);
  }

  public void HideGuideSaintBack()
  {
    CanvasUtils.FadeOut(this, guideSaintBackCanvas.GetComponent<CanvasGroup>(), 0.3f, () =>
    {
      guideSaintBackCanvas.SetActive(false);
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
    guideTipsCanvas.SetActive(false);
    guideSaintCanvas.SetActive(false);
    guideSaintBackCanvas.SetActive(false);
    ShowCourse();
  }

  private void GuideToPrompt()
  {
    prompt.text = "爱丽丝很感谢克里斯";
    HideGuideTips();
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
    nextB.GetComponent<Button>().onClick.AddListener(Next);
    toPromptBtn.GetComponent<Button>().onClick.AddListener(GuideToPrompt);
    closeGuideSaintBtn.GetComponent<Button>().onClick.AddListener(HideGuideSaint);
    closeGuideSaintBackBtn.GetComponent<Button>().onClick.AddListener(HideGuideSaintBack);

    firstTime = PlayerPrefs.GetInt("firstTime", 1) == 0;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
