using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Drawing;
using UnityEngine.UIElements;
using TMPro;

public class MuneButtons : MonoBehaviour
{
    public GameObject black;
    public GameObject startB;
    public GameObject quitB;
    public GameObject loadB;
    //public TextMeshProUGUI stratText;
    //public TextMeshProUGUI quitText;
    public bool isstart;
    public bool isload;


    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        isstart = true;


    }
    public void LoadGame()
    {
        isload = true;
    }

    public void FadeOut(GameObject obj)
    {
        float color = obj.GetComponent<TextMeshProUGUI>().color.a;
        float a = Mathf.Lerp(color, 0, 0.5f * Time.deltaTime);

        obj.GetComponent<TextMeshProUGUI>().color = new UnityEngine.Color(1, 1, 1, a);
    }

    private void Start()
    {
        isstart = false;
        this.GetComponent<AudioSource>().Play();

    }
    void Update()
    {
        if(isstart||isload)
        {
            float color = black.GetComponent<UnityEngine.UI.Image>().color.a;
            float a = Mathf.Lerp(color, 1, 0.5f * Time.deltaTime);
            black.GetComponent<UnityEngine.UI.Image>().color = new UnityEngine.Color(0, 0, 0, a);

            FadeOut(startB);
            FadeOut(quitB);
            FadeOut(loadB);
        }

        if(black.GetComponent<UnityEngine.UI.Image>().color.a > 0.95f && isstart)
        {
            startB.SetActive(false);
            quitB.SetActive(false);
            loadB.SetActive(false);
            SceneManager.LoadScene("Xuzhang");
        }
        if (black.GetComponent<UnityEngine.UI.Image>().color.a > 0.95f && isload)
        {
            startB.SetActive(false);
            quitB.SetActive(false);
            loadB.SetActive(false);
            SceneManager.LoadScene("Saint");
        }
    }
}
