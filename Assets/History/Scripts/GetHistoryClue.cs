using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHistoryClue : MonoBehaviour
{
    public static bool gClue;
    public GameObject clue;
    public GameObject hContent;
    public GameObject hHandle;

    public List<GameObject> clues = new List<GameObject>();
    public static List<string> gotClues = new List<string>();


    public Clue CreateClues(int n)
    {
        GameObject obj;
        obj = Instantiate(clue, new Vector3(520, -300 - 300 * (n - 1), 0), Quaternion.identity);
        obj.transform.parent = hContent.transform;
        clues.Add(obj);
        return obj.GetComponent<Clue>();
    }

    public void DestroyClue()
    {
        int n = clues.Count;
        if (!clues.Equals(null))
        {
            for (int i = 0; i < n; i++)
            {
                Destroy(clues[i]);
            }
        }
        hContent.GetComponent<RectTransform>().position = new Vector2(63, 868);

    }
    public void SetClue()
    {
        gClue = true;

        int n = gotClues.Count;

        hContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 400 * n);
        //hHandle.GetComponent<RectTransform>().sizeDelta = new Vector2(24.72f, 20);

        for (int i = 0; i < n; i++)
        {
            Clue c;
            c = CreateClues(i);
            c.init(gotClues[i]);


        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
