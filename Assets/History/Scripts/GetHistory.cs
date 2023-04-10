using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHistory : MonoBehaviour
{
    public GameObject hDialogue;
    public GameObject hContent;
    public GameObject hHandle;

    public static List<string> hQuestion = new List<string>();
    public static List<string> hAnswer = new List<string>();

    public Dialogue CreatDialogue(int n)
    {
        GameObject obj;
        obj = Instantiate(hDialogue, new Vector3(480, -827 - 670 * n, 0), Quaternion.identity);
        obj.transform.parent = hContent.transform;
        return obj.GetComponent<Dialogue>();
    }
    public void SetDialogue()
    {
        int n = hAnswer.Count;

        hContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 800*n);
        Debug.Log(hHandle.GetComponent<RectTransform>().sizeDelta);
        //hHandle.GetComponent<RectTransform>().sizeDelta = new Vector2(24.72f, 20);

        for(int i = 0; i < n; i++)
        {
            Dialogue dia;
            dia = CreatDialogue(i);
            dia.Init("»Ø´ð", "ÌáÎÊ", hAnswer[i], hQuestion[i]);
        }
    }
    private void Awake()
    {
        hQuestion.Add("test");
        hAnswer.Add("test");
        hQuestion.Add("test2");
        hAnswer.Add("test2");
    }
    void Start()
    {
        SetDialogue();
        Debug.Log("11");
    }

    void Update()
    {

    }
}
