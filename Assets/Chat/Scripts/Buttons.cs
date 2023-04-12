using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject historyB;
    public GameObject saintB;
    public GameObject hBackB;

    public GameObject chatCanvas;
    public GameObject historyCanvas;
    public GameObject judgeCanvas;
    public GameObject charaCanvas;
    public GameObject churchCanvas;

    private void History()
    {
        chatCanvas.SetActive(false);
        churchCanvas.SetActive(false);
        charaCanvas.SetActive(false);
        historyCanvas.SetActive(true);
    }

    private void Saint()
    {
        chatCanvas.SetActive(false);
        churchCanvas.SetActive(false);
        charaCanvas.SetActive(false);
        judgeCanvas.SetActive(true);
    }

    private void HistoryBack()
    {
        chatCanvas.SetActive(true);
        churchCanvas.SetActive(true);
        charaCanvas.SetActive(true);
        historyCanvas.SetActive(false);
    }
    void Start()
    {
        historyB.GetComponent<Button>().onClick.AddListener(History);
        saintB.GetComponent<Button>().onClick.AddListener(Saint);
        hBackB.GetComponent<Button>().onClick.AddListener(HistoryBack);    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
