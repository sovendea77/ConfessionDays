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

    public GameObject chatCanvas;
    public GameObject historyCanvas;
    public GameObject judgeCanvas;
    public GameObject charaCanvas;
    public GameObject churchCanvas;
    public GameObject muneCanvas;

    private void Mune()
    {
        chatCanvas.SetActive(false);
        churchCanvas.SetActive(false);
        charaCanvas.SetActive(false);
        muneCanvas.SetActive(true);
    }

    private void MuneBack()
    {
        chatCanvas.SetActive(true);
        churchCanvas.SetActive(true);
        charaCanvas.SetActive(true);
        muneCanvas.SetActive(false);
    }

    private void History()
    {
        chatCanvas.SetActive(false);
        churchCanvas.SetActive(false);
        charaCanvas.SetActive(false);
        historyCanvas.SetActive(true);
    }

    private void Saint()
    {
        judgeCanvas.SetActive(true);
    }

    private void HistoryBack()
    {
        chatCanvas.SetActive(true);
        churchCanvas.SetActive(true);
        charaCanvas.SetActive(true);
        historyCanvas.SetActive(false);
    }

    private void Awake()
    {
        chatCanvas.SetActive(true);
        judgeCanvas.SetActive(false);
        historyCanvas.SetActive(false);
        churchCanvas.SetActive(true);
        charaCanvas.SetActive(true);
        muneCanvas.SetActive(false);
    }
    void Start()
    {
        historyB.GetComponent<Button>().onClick.AddListener(History);
        saintB.GetComponent<Button>().onClick.AddListener(Saint);
        hBackB.GetComponent<Button>().onClick.AddListener(HistoryBack);
        muneB.GetComponent<Button>().onClick.AddListener(Mune);
        mBackB.GetComponent<Button>().onClick.AddListener(MuneBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
