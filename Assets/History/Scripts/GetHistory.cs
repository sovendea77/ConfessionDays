using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHistory : MonoBehaviour
{
    public GameObject hDialogue;
    public GameObject hContent;
    public GameObject hHandle;

    public List<GameObject> dialogues = new List<GameObject>();
    public static List<string> hQuestion = new List<string>();
    public static List<string> hAnswer = new List<string>();


    public Dialogue CreatDialogue(int n)
    {
        GameObject obj;
        obj = Instantiate(hDialogue, new Vector3(480, -700 - 670 * (n-1), 0), Quaternion.identity);
        obj.transform.parent = hContent.transform;
        dialogues.Add(obj);
        return obj.GetComponent<Dialogue>();
    }

    public void DestroyDialogue()
    {
        int n = dialogues.Count;
        if(n > 0)
        {
            for (int i = 0; i < n; i++)
            {
                Destroy(dialogues[i]);
            }
        }
        hContent.GetComponent<RectTransform>().position = new Vector2(63, 868);

    }
    public void SetDialogue()
    {
        
        int n = hAnswer.Count;

        hContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 800*n);
        //hHandle.GetComponent<RectTransform>().sizeDelta = new Vector2(24.72f, 20);

        for (int i = 0; i < n; i++)
        {
            Dialogue dia;
            dia = CreatDialogue(i);
            dia.Init("»Ø´ð", "ÌáÎÊ", hAnswer[i], hQuestion[i]);
        }
    }
    private void Awake()
    {

    }

    void Start()
    {
        hAnswer.Add("TEST");
        hQuestion.Add("aaaaaaaaaaa");
        SetDialogue();
    }

    void Update()
    {
        //Debug.Log(hAnswer.Count);
    }
}
