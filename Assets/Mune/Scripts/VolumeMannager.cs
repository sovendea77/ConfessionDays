using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;

public class VolumeMannager : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider effectSlider;
    public Slider animationSlider;
    public AudioSource bgmAudio;
    public AudioSource effectAudio;
    public VideoPlayer animationAudio;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bgmAudio.volume = (float)(bgmSlider.value/100);
        effectAudio.volume = (float)(effectSlider.value / 100);
        animationAudio.SetDirectAudioVolume(0, (float)(effectSlider.value / 1000));
    }
}
