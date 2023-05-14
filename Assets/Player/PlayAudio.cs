using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip confirmB;
    public AudioClip backB;
    public AudioClip startB;
    public AudioClip judgeB;
    public AudioClip wrongSaint;
    public AudioClip correctSaint;


    public void PlayconfirmB()
    {
        if(Chat.saintTime % 4 == 0)
        {
            if(!Chat.isAnswer)
            {
                Debug.Log(Judge.iscorrect);
                if (Judge.iscorrect)
                {
                    this.GetComponent<AudioSource>().clip = correctSaint;
                }
                else
                {
                    this.GetComponent<AudioSource>().clip = wrongSaint;
                    
                }
            }
            else
            {
                this.GetComponent<AudioSource>().clip = confirmB;
            }
            Judge.iscorrect = false;

        }
        else
        {
            this.GetComponent<AudioSource>().clip = confirmB;
        }

        this.GetComponent<AudioSource>().Play();
    }
    public void PlaybackB()
    {
        this.GetComponent<AudioSource>().clip = backB;
        this.GetComponent<AudioSource>().Play();
    }
    public void PlaystartB()
    {
        this.GetComponent<AudioSource>().clip = startB;
        this.GetComponent<AudioSource>().Play();
    }
    public void PlayjuegeB()
    {
        this.GetComponent<AudioSource>().clip = judgeB;
        this.GetComponent<AudioSource>().Play();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
