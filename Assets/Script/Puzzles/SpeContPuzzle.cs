using UnityEngine;
using System.Collections;
using System;

public class SpeContPuzzle : MonoBehaviour{
    public GameObject target;
    public Puzzle p1, p2, p3, p4;
    public float distance;

    private bool flag;
    // Use this for initialization
    void Start () {
        Debug.Log(distance);
        flag = true;
	}
	
	// Update is called once per frame
	void Update () {
        float a = transform.position.y;
        if (target)
        {
            //Debug.Log("judgemove");
            if (Math.Abs(transform.position.x - target.transform.position.x) >= 0.01f ||
                Math.Abs(transform.position.y - target.transform.position.y) >= 0.01f)
            {
                // Debug.Log("Move");


                if (p1.GetTriggerDown()&&flag)
                {
                    //Debug.Log("11");
                    flag = false;
                    GameKernel.actionManager.RunAction(new ActionSequence(gameObject,
                        new ActionMoveTo(
                        gameObject,
                        new Vector3(transform.position.x, transform.position.y+distance, -10.0f),
                        1.0f),
                        new ActionCallFunc(gameObject, (object obj) =>
                        {
                            GameObject go = (GameObject)obj;
                            flag = true;
                        }, gameObject)
                    ));
                }
                else if (p2.GetTriggerDown() && flag)
                {
                    //Debug.Log("22");
                    flag = false;
                    GameKernel.actionManager.RunAction(new ActionSequence(gameObject,
                        new ActionMoveTo(
                        gameObject,
                        new Vector3(transform.position.x, transform.position.y - distance, -10.0f),
                        1.0f),
                        new ActionCallFunc(gameObject, (object obj) =>
                        {
                            GameObject go = (GameObject)obj;
                            flag = true;
                        }, gameObject)
                    ));
                }
                else if (p3.GetTriggerDown() && flag)
                {
                    //Debug.Log("33");
                    flag = false;
                    GameKernel.inputManager.Enable = false;
                    GameKernel.actionManager.RunAction(new ActionSequence(gameObject,
                        new ActionMoveTo(gameObject, new Vector3(transform.position.x, transform.position.y - distance, -10.0f), 1.0f),
                        new ActionDelay(gameObject,1.0f),
                        new ActionMoveBy(gameObject,
                            new Vector3(0,
                                distance,
                                0
                            ),
                            1.0f),
                        new ActionCallFunc(gameObject, (object obj) =>
                        {
                            GameObject go = (GameObject)obj;
                            flag = true;
                            Debug.Log(go.transform.position.y);
                            //Debug.Log("aa");
                            GameKernel.inputManager.Enable = true;
                        }, gameObject)
                    ));
                }
                if (p4.GetTriggerDown() && flag)
                {
                    //Debug.Log("44");
                    flag = false;
                    GameKernel.actionManager.RunAction(new ActionSequence(gameObject,
                        new ActionMoveTo(
                        gameObject,
                        new Vector3(transform.position.x, transform.position.y - distance, -10.0f),
                        1.0f),
                        new ActionCallFunc(gameObject, (object obj) =>
                        {
                            GameObject go = (GameObject)obj;
                            flag = true;
                        }, gameObject)
                    ));
                }
                else if(flag)
                {
                    Debug.Log("ss");
                    GameKernel.actionManager.RunAction(new ActionMoveTo(
                        gameObject,
                        new Vector3(target.transform.position.x, transform.position.y, -10.0f),
                        1.0f));
                }
            }
        }
    }
}
