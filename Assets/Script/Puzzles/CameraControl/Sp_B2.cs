using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Sp_B2 : MonoBehaviour {
    public Transform target;

    protected bool flag = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	public virtual void Update () {
        if (target&&flag)
        {
            //Debug.Log("judgemove");
            if (Math.Abs(transform.position.x - target.transform.position.x) >= 0.01f ||
                Math.Abs(transform.position.y - target.transform.position.y) >= 0.01f)
            {
                // Debug.Log("Move");
                GameKernel.actionManager.RunAction(new ActionMoveTo(
                    gameObject,
                    new Vector3(target.transform.position.x, target.transform.position.y, -10.0f),
                    1.0f));
            }
        }
    }
}
