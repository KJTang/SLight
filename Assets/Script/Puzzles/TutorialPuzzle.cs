using UnityEngine;
using UnityEditor.Animations;
using System.Collections;
using System.Collections.Generic;
public class TutorialPuzzle : MonoBehaviour
 {
    public List<Puzzle> puzzles = new List<Puzzle>();
    // Use this for initialization
    private bool[] l = { false,false,false,false };
    void Start()
    {
        int i = 0;
        foreach (Puzzle p in puzzles)
        {
            Debug.Log(transform.GetChild(i) + "initset");
            transform.GetChild(i).GetComponent<Animator>().enabled = false;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (Puzzle p in puzzles)
        {
            if (i == 1 && p.GetTriggerDown()) Debug.Log(p);
            if (p.GetTriggerDown() && !l[i])
            {
                Debug.Log(transform.GetChild(i) + "settrue");
                transform.GetChild(i).GetComponent<Animator>().enabled = true;
                l[i] = true;
            }
            if (p.GetTriggerUp())
            {
                Debug.Log(transform.GetChild(i) + "setfalse");
                transform.GetChild(i).GetComponent<Animator>().enabled = false;
                transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = null;
            }
            i++;
        }
    }
}
