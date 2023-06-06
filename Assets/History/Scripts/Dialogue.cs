using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TMP_Text aName;
    public TMP_Text qName;
    public TMP_Text aText;
    public TMP_Text qText;
    public void Init(string a, string b, string c, string d)
    {
        aName.text = a;
        qName.text = b;
        if(c.Length > 100)
        {
            aText.text = c.Substring(0, 60);
        }
        else
        {
            aText.text = c;
        }

        qText.text = d;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
