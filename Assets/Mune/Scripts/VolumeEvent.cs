using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeEvent : MonoBehaviour
{
    public GameObject volumeCanvas;
    public GameObject menuCanvas;
    public void BackMenu()
    {
        menuCanvas.SetActive(true);
        volumeCanvas.SetActive(false);

    }
}
