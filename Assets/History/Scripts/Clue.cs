using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clue : MonoBehaviour
{
    public TMP_Text text;

    public void init(string t)
    {
        text.text = t;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
