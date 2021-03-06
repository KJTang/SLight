﻿using UnityEngine;
using System.Collections;

public class Sp_B1 : Sp_B2 {
    public Puzzle sp1, sp2, sp3;
    public Vector3 sd1, sd2, sd3;
    public Transform ball;

    // Use this for initialization	
    // Update is called once per frame

    void Start()
    {
    }
	public override void Update () {
        sd2 = ball.position - transform.position;
        sd2.z = 0;
        Debug.Log(flag);
        if (sp1.GetTriggerDown() && flag)
        {
            flag = false;
            GameKernel.inputManager.Enable = false;
            GameKernel.actionManager.RunAction(new ActionSequence(gameObject,
                new ActionMoveBy(gameObject,
                    -sd1,
                    1.0f),
                new ActionDelay(gameObject, 2.0f),
                new ActionMoveBy(gameObject,
                    sd1,
                    1.0f),
                new ActionCallFunc(gameObject, (object obj) =>
                {
                    GameObject go = (GameObject)obj;
                    flag = true;
                    //Debug.Log(go.transform.position.y);
                    //Debug.Log("aa");
                    GameKernel.inputManager.Enable = true;
                }, gameObject)
            ));
        }
        if (sp2.GetTriggerDown() && flag)
        {
            //Debug.Log("33");
            flag = false;
            GameKernel.inputManager.Enable = false;
            GameKernel.actionManager.RunAction(new ActionSequence(gameObject,
                new ActionMoveBy(gameObject,
                    sd2,
                    1.0f),
                new ActionDelay(gameObject, 1.0f),
                new ActionMoveBy(gameObject,
                    -sd2,
                    1.0f),
                new ActionCallFunc(gameObject, (object obj) =>
                {
                    GameObject go = (GameObject)obj;
                    flag = true;
                    //Debug.Log(go.transform.position.y);
                    //Debug.Log("aa");
                    GameKernel.inputManager.Enable = true;
                }, gameObject)
            ));
        }
        if (sp3.GetTriggerDown() && flag)
        {
            //Debug.Log("33");
            flag = false;
            GameKernel.inputManager.Enable = false;
            GameKernel.actionManager.RunAction(new ActionSequence(gameObject,
                new ActionMoveBy(gameObject,
                    sd3,
                    1.0f),
                new ActionDelay(gameObject, 1.0f),
                new ActionMoveBy(gameObject,
                    -sd3,
                    1.0f),
                new ActionCallFunc(gameObject, (object obj) =>
                {
                    GameObject go = (GameObject)obj;
                    flag = true;
                    //Debug.Log(go.transform.position.y);
                    //Debug.Log("aa");
                    GameKernel.inputManager.Enable = true;
                }, gameObject)
            ));
        }
        base.Update();

    }
}
