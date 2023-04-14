using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Drawing;
using UnityEngine.UIElements;

public class MuneButtons : MonoBehaviour
{
    public GameObject black;
    public GameObject startB;
    public GameObject quitB;
    public bool isstart;


    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        isstart = true;
        startB.SetActive(false);
        quitB.SetActive(false);

    }

    private void Start()
    {
        isstart = false;
        this.GetComponent<AudioSource>().Play();

    }
    void Update()
    {
        if(isstart)
        {
            float color = black.GetComponent<SpriteRenderer>().color.a;
            float a = Mathf.Lerp(color, 1, 0.5f * Time.deltaTime);
            Debug.Log(color);
            black.GetComponent<SpriteRenderer>().color = new UnityEngine.Color(0, 0, 0, a);
        }

        if(black.GetComponent<SpriteRenderer>().color.a > 0.95f && isstart)
        {
            SceneManager.LoadScene("Xuzhang");
        }
    }
}
