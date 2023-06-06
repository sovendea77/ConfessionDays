using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject menuList;
    public bool b1;
    public bool b2;

    public void EnterButton()
    {
        menuList.SetActive(true);
        b1 = false;
    }
    public void ExitButton()
    {
        b1 = true;
    }
    public void EnterBack()
    {
        b2 = false;
    }
    public void ExitBack()
    {
        b2 = true;
    }


    void Start()
    {
        b1 = b2 = true;
        menuList.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(b1 && b2)
        {
            menuList.SetActive(false);
        }

    }
}
