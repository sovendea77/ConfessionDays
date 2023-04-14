using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptionsManager : MonoBehaviour
{
    public Button[] options;
    public int currentIndex = 0;
    public float unactiveAlpha = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentIndex -= 1;
            if (currentIndex < 0) currentIndex = options.Length - 1;
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentIndex += 1;
            if (currentIndex >= options.Length) currentIndex = 0;
        }
        RefreshOptions();
    }

    void SetButtonAlpha(Button btn, float alpha)
    {
        var color = btn.targetGraphic.color;
        color.a = alpha;
        btn.targetGraphic.color = color;
    }

    void RefreshOptions()
    {
        int i = 0;
        foreach (var option in options)
        {
            if (currentIndex == i)
            {
                SetButtonAlpha(option, 1f);
            } else
            {
                SetButtonAlpha(option, unactiveAlpha);
            }
            i++;
        }
    }
}
