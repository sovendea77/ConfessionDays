using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    public GameObject volumeCanvas;
    public GameObject menuCanvas;
    public GameObject clueCanvas;

    public void ToClue()

    {
        clueCanvas.SetActive(true);
        menuCanvas.SetActive(false);
        clueCanvas.GetComponent<Canvas>().sortingOrder = 9;
        menuCanvas.GetComponent<Canvas>().sortingOrder = 0;
    }
    public void ClueBack()
    {
        clueCanvas.GetComponent<Canvas>().sortingOrder = 0;
        menuCanvas.GetComponent<Canvas>().sortingOrder = 9;
        clueCanvas.SetActive(false);
    }

    public void ToMain()
    {
        SceneManager.LoadScene("MainMune");
    }
    public void SetVolume()
    {
        volumeCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }
}
