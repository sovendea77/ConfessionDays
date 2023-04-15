using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEx : MonoBehaviour
{
    public Animator normal;

    public void Delight()
    {
        normal.SetTrigger("delight");
    }

    public void Sad()
    {
        normal.SetTrigger("sad");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
