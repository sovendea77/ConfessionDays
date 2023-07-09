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
    public GameObject charaB;
    public GameObject guideB;
    public GameObject cLastB;
    public GameObject clueB;
    public GameObject clueBackB;

    // guides btns
    public GameObject guideBackBtn;
  public GameObject closeTipBtn;
  public GameObject closeGuideSaintBtn;
  public GameObject closeGuideSaintBackBtn;
  public GameObject closeGuideMenuBtn;
    public GameObject closeGuideHistoryBtn;
    public GameObject closeGuideConfirmBtn;  
    public GameObject closeGuideSaintDropdownBtn;  
  
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
    public GameObject clueCanvas;

    public GameObject cCharaCanvas;
    public GameObject cGuideCanvas;

    // guides canvas
  public GameObject guideStoryCanvas;
  public GameObject guideTipsCanvas;
  public GameObject guideMenuCanvas;
    public GameObject guideHistoryCanvas;
    public GameObject guideConfirmCanvas;
    public GameObject guideSaintTipsCanvas;
    public GameObject guideSaintBackCanvas;
    public GameObject guideSaintDropdownCanvas;

  public TMP_InputField prompt;

  public static bool isSaint;
   private bool menuCanShow = true;
   private bool guideSaintTipsCanvasCanShow = true;
   private bool guideSaintBackCanvasCanShow = true;
   private bool guideSaintDropdownCanvasCanShow = true;

    private void closeLastCourse()
    {
        CanvasUtils.FadeOut(this, courseCanvas.GetComponent<CanvasGroup>(), 0.3f, () =>
        {
            courseCanvas.SetActive(false);

           
                ShowGuideTips();
        });

        guide.SetActive(false);
    }
    private void Last()
    {
        if (introduce.activeSelf)
        {
            cLastB.SetActive(false);
            background.SetActive(true);
            introduce.SetActive(false);
        }
        else
        {
            introduce.SetActive(true);
            guide.SetActive(false);
            
        }
    }

    private void Next()
    {
        if(background.activeSelf)
        {
            background.SetActive(false);
            introduce.SetActive(true);
            cLastB.SetActive(true);
        }
        else
        {
            cLastB.SetActive(true);
            introduce.SetActive(false);
            guide.SetActive(true);
        }
    }    

    private void Chara()
    {
        CanvasUtils.FadeIn(this, courseCanvas.GetComponent<CanvasGroup>(), 0.5f);
        cGuideCanvas.SetActive(false);
        cCharaCanvas.SetActive(true);
        nextB.SetActive(false);
        cLastB.SetActive(false);

    }
    
    private void Guide()
    {
        CanvasUtils.FadeIn(this, courseCanvas.GetComponent<CanvasGroup>(), 0.5f);
        cGuideCanvas.SetActive(true);
        cLastB.SetActive(false);
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

    private void Clue()
    {
        chatCanvas.SetActive(false);
        churchCanvas.SetActive(false);
        charaCanvas.SetActive(false);
        clueCanvas.SetActive(true);
        judgeCanvas.SetActive(false);

    }
    private void Saint()
  {
    judgeCanvas.SetActive(true);
    judgeCanvas.GetComponent<Canvas>().sortingOrder = 10;
    isSaint = true;
    ShowGuideSaintDropdown();
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

    private void ClueBack()
    {
        chatCanvas.SetActive(true);
        churchCanvas.SetActive(true);
        charaCanvas.SetActive(true);
        clueCanvas.SetActive(false);
        judgeCanvas.SetActive(true);
    }

    private void ShowCourse()
  {
    courseCanvas.SetActive(true);
        nextB.SetActive(true);
        CanvasUtils.FadeIn(this, courseCanvas.GetComponent<CanvasGroup>(), 0.5f);
    nextB.SetActive(true);
  }

  private void HideCourse()
  {
    CanvasUtils.FadeOut(this, courseCanvas.GetComponent<CanvasGroup>(), 0.3f, () =>
    {
      courseCanvas.SetActive(false);

        ShowGuideMenu();
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
      //ShowGuideTips();
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
        ShowGuideConfirm();
      
    }

  public void ShowGuideSaint()
  {
    if (guideSaintTipsCanvasCanShow) {
      guideSaintTipsCanvas.SetActive(true);
      CanvasUtils.FadeIn(this, guideSaintTipsCanvas.GetComponent<CanvasGroup>(), 0.5f);
      
      guideSaintTipsCanvasCanShow = false;
    }
  }

  public void HideGuideSaint()
  {
    CanvasUtils.FadeOut(this, guideSaintTipsCanvas.GetComponent<CanvasGroup>(), 0.3f, () =>
    {
      guideSaintTipsCanvas.SetActive(false);
    });
  }

  public void ShowGuideSaintBack()
  {
    if (guideSaintBackCanvasCanShow) {
      guideSaintBackCanvas.SetActive(true);
      CanvasUtils.FadeIn(this, guideSaintBackCanvas.GetComponent<CanvasGroup>(), 0.5f);
      
      guideSaintBackCanvasCanShow = false;
    }
  }

  public void HideGuideSaintBack()
  {
    CanvasUtils.FadeOut(this, guideSaintBackCanvas.GetComponent<CanvasGroup>(), 0.3f, () =>
    {
      guideSaintBackCanvas.SetActive(false);
    });
  }

  public void ShowGuideMenu()
  {
        if(menuCanShow)
        {
            guideMenuCanvas.SetActive(true);
            CanvasUtils.FadeIn(this, guideMenuCanvas.GetComponent<CanvasGroup>(), 0.5f);
            menuCanShow = false;
        }
    
  }

  public void HideGuideMenu()
  {
    CanvasUtils.FadeOut(this, guideMenuCanvas.GetComponent<CanvasGroup>(), 0.3f, () =>
    {
      guideMenuCanvas.SetActive(false);
    });
        ShowGuideHistory();
  }
    public void ShowGuideHistory()
    {
        guideHistoryCanvas.SetActive(true);
        CanvasUtils.FadeIn(this, guideHistoryCanvas.GetComponent<CanvasGroup>(), 0.5f);
    }

    public void HideGuideHistory()
    {
        CanvasUtils.FadeOut(this, guideHistoryCanvas.GetComponent<CanvasGroup>(), 0.3f, () =>
        {
            guideHistoryCanvas.SetActive(false);
        });
        ShowGuideTips();
    }
    public void ShowGuideConfirm()
    {
        guideConfirmCanvas.SetActive(true);
        CanvasUtils.FadeIn(this, guideConfirmCanvas.GetComponent<CanvasGroup>(), 0.5f);
    }

    public void HideGuideConfirm()
    {
        CanvasUtils.FadeOut(this, guideConfirmCanvas.GetComponent<CanvasGroup>(), 0.3f, () =>
        {
            guideConfirmCanvas.SetActive(false);
        });

    }
    public void ShowGuideSaintDropdown()
    {
        if (guideSaintDropdownCanvasCanShow) {
          guideSaintDropdownCanvas.SetActive(true);
          CanvasUtils.FadeIn(this, guideSaintDropdownCanvas.GetComponent<CanvasGroup>(), 0.5f);

          guideSaintDropdownCanvasCanShow = false;
        }
        
    }

    public void HideGuideSaintDropdown()
    {
        CanvasUtils.FadeOut(this, guideSaintDropdownCanvas.GetComponent<CanvasGroup>(), 0.3f, () =>
        {
            guideSaintDropdownCanvas.SetActive(false);
        });
        ShowGuideSaintBack();
    }
    private void Awake()
  {
    chatCanvas.SetActive(true);
    churchCanvas.SetActive(true);
    charaCanvas.SetActive(true);

    historyCanvas.SetActive(false);
    muneCanvas.SetActive(false);
    guideStoryCanvas.SetActive(false);
    guideTipsCanvas.SetActive(false);
    guideSaintTipsCanvas.SetActive(false);
    guideSaintBackCanvas.SetActive(false);
    guideMenuCanvas.SetActive(false);
    guideSaintBackCanvas.SetActive(false);
    guideSaintDropdownCanvas.SetActive(false);

    ShowCourse();
  }

  private void GuideToPrompt()
  {
    prompt.text = "艾与莱欧的关系如何？";
    HideGuideTips();
  }

  void Start()
  {
    historyB.GetComponent<Button>().onClick.AddListener(History);
        clueB.GetComponent<Button>().onClick.AddListener(Clue);
        saintB.GetComponent<Button>().onClick.AddListener(Saint);
    sBackB.GetComponent<Button>().onClick.AddListener(SaintBack);
    hBackB.GetComponent<Button>().onClick.AddListener(HistoryBack);
        clueBackB.GetComponent<Button>().onClick.AddListener(ClueBack);
        muneB.GetComponent<Button>().onClick.AddListener(Mune);
    mBackB.GetComponent<Button>().onClick.AddListener(MuneBack);
    cBackB.GetComponent<Button>().onClick.AddListener(HideCourse);
    guideBackBtn.GetComponent<Button>().onClick.AddListener(HideGuideStory);
    closeTipBtn.GetComponent<Button>().onClick.AddListener(HideGuideTips);
    nextB.GetComponent<Button>().onClick.AddListener(Next);
        cLastB.GetComponent<Button>().onClick.AddListener(Last);
        toPromptBtn.GetComponent<Button>().onClick.AddListener(GuideToPrompt);
    closeGuideSaintBtn.GetComponent<Button>().onClick.AddListener(HideGuideSaint);
    closeGuideSaintBackBtn.GetComponent<Button>().onClick.AddListener(HideGuideSaintBack);

    closeGuideMenuBtn.GetComponent<Button>().onClick.AddListener(HideGuideMenu);
    charaB.GetComponent<Button>().onClick.AddListener(Chara);
    guideB.GetComponent<Button>().onClick.AddListener(Guide);
        closeGuideHistoryBtn.GetComponent<Button>().onClick.AddListener(HideGuideHistory);
        closeGuideConfirmBtn.GetComponent<Button>().onClick.AddListener(HideGuideConfirm);
        closeGuideSaintDropdownBtn.GetComponent<Button>().onClick.AddListener(HideGuideSaintDropdown);
    //cNextB.GetComponent<Button>().onClick.AddListener(closeLastCourse);


    }

}
