using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueEvents : MonoBehaviour
{
    public GameObject clueCanvas;
    public GameObject menuCanvas;
    public void BackMenu()
    {
        menuCanvas.SetActive(true);
        clueCanvas.SetActive(false);

    }
}
