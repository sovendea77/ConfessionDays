using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CheckEnd : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public GameObject vedioCanvas;

    public VideoClip trueEnd;
    public VideoClip normalEnd;
    public VideoClip badEnd;
    void Start()
    {
        videoPlayer.targetTexture = new RenderTexture((int)rawImage.rectTransform.rect.width, (int)rawImage.rectTransform.rect.height, 0);
        rawImage.texture = videoPlayer.targetTexture;

        switch (Chat.end)
        {
            case 1:
                videoPlayer.clip = trueEnd;
                vedioCanvas.SetActive(true);
                videoPlayer.Play();
                break;
            case 2:
                videoPlayer.clip = normalEnd;
                vedioCanvas.SetActive(true);
                videoPlayer.Play();
                break;
            case 3:
                videoPlayer.clip = badEnd;
                vedioCanvas.SetActive(true);
                videoPlayer.Play();
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
