using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class SpeContPuzzle : MonoBehaviour{
    public GameObject target;
    public enum side{ upside,downside};
    public List<Puzzle> puzzles = new List<Puzzle>();
    public List<float> distance = new List<float>();
    public List<side> sides = new List<side>();

    protected bool flag;
    // Use this for initialization
    void Start () {
        //Debug.Log(distance);
        flag = true;
	}
	
	// Update is called once per frame
	virtual public void Update () {
        Debug.Log(flag);
        if (target)
        {
            //Debug.Log("judgemove");
            if (Math.Abs(transform.position.x - target.transform.position.x) >= 0.01f ||
                Math.Abs(transform.position.y - target.transform.position.y) >= 0.01f)
            {
                // Debug.Log("Move");
                int i = 0;
                foreach(Puzzle p in puzzles)
                {
                    if (p.GetTriggerDown() && flag)
                    {
                        //Debug.Log("11");
                        flag = false;
                        if (sides[i] == side.downside) if (distance[i] >= 0) distance[i] = -distance[i];
                        GameKernel.actionManager.RunAction(new ActionSequence(gameObject,
                            new ActionMoveTo(
                            gameObject,
                            new Vector3(transform.position.x, transform.position.y + distance[i], -10.0f),
                            1.0f),
                            new ActionCallFunc(gameObject, (object obj) =>
                            {
                                GameObject go = (GameObject)obj;
                                flag = true;
                            }, gameObject)
                        ));
                        break;
                    }
                    i++;
                }

                if (flag)
                {
                    //Debug.Log("ss");
                    GameKernel.actionManager.RunAction(new ActionMoveTo(
                        gameObject,
                        new Vector3(target.transform.position.x, transform.position.y, -10.0f),
                        1.0f));
                }
            }
        }
    }
}
