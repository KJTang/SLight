using UnityEngine;
using System.Collections;
using System;

public class SpeContPuzzle : MonoBehaviour{
    public GameObject target;
    public Puzzle p1, p2;
    public float distance;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            //Debug.Log("judgemove");
            if (Math.Abs(transform.position.x - target.transform.position.x) >= 0.01f ||
                Math.Abs(transform.position.y - target.transform.position.y) >= 0.01f)
            {
                // Debug.Log("Move");
                GameKernel.actionManager.RunAction(new ActionMoveTo(
                    gameObject,
                    new Vector3(target.transform.position.x, transform.position.y, -10.0f),
                    1.0f));
            }
        }
        if (p1.GetTriggerDown())
        {
            GameKernel.actionManager.RunAction(new ActionMoveBy(
                gameObject,
                new Vector3(0, distance, 0),
                1.0f));
        }
        if (p2.GetTriggerDown())
        {
            GameKernel.actionManager.RunAction(new ActionMoveBy(
                gameObject,
                new Vector3(0, -distance, 0),
                1.0f));
        }
    }
}
