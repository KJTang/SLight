using UnityEngine;
using System;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public GameObject target;
    private bool flag = true;
	void Start () {
    }
	
	void Update () {
        //Debug.Log(gameObject.name);
        if (target) {
            //Debug.Log("judgemove");
            if (Math.Abs(transform.position.x - target.transform.position.x) >= 0.01f || 
                Math.Abs(transform.position.y - target.transform.position.y) >= 0.01f) {
               // Debug.Log("Move");
                GameKernel.actionManager.RunAction(new ActionMoveTo(
                    gameObject, 
                    new Vector3(target.transform.position.x,transform.position.y, -10.0f), 
                    1.0f));
            }
        }
    }
}
