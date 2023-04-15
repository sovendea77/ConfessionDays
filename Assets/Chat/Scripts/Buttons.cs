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

    public GameObject chatCanvas;
    public GameObject historyCanvas;
    public GameObject judgeCanvas;
    public GameObject charaCanvas;
    public GameObject churchCanvas;
    public GameObject muneCanvas;
    public GameObject courseCanvas;

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
    }

    private void SaintBack()
    {
        judgeCanvas.GetComponent<Canvas>().sortingOrder = -5;
    }
    private void HistoryBack()
    {
        chatCanvas.SetActive(true);
        churchCanvas.SetActive(true);
        charaCanvas.SetActive(true);
        historyCanvas.SetActive(false);
        judgeCanvas.SetActive(true);
    }

    private void CourseBack()
    {
        courseCanvas.SetActive(false);
    }

    private void Awake()
    {
        chatCanvas.SetActive(true);
        historyCanvas.SetActive(false);
        churchCanvas.SetActive(true);
        charaCanvas.SetActive(true);
        muneCanvas.SetActive(false);
        courseCanvas.SetActive(true);
    }
    void Start()
    {
        historyB.GetComponent<Button>().onClick.AddListener(History);
        saintB.GetComponent<Button>().onClick.AddListener(Saint);
        sBackB.GetComponent<Button>().onClick.AddListener(SaintBack);
        hBackB.GetComponent<Button>().onClick.AddListener(HistoryBack);
        muneB.GetComponent<Button>().onClick.AddListener(Mune);
        mBackB.GetComponent<Button>().onClick.AddListener(MuneBack);
        cBackB.GetComponent<Button>().onClick.AddListener(CourseBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
