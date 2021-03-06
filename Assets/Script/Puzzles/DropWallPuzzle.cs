﻿using UnityEngine;

public class DropWallPuzzle : MonoBehaviour {
    // Use this for initialization
    private bool flag = true;
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if(gameObject.GetComponentInChildren<RopePuzzle>().isTriggered == true&&flag)
        {
            Debug.Log(gameObject.GetComponent<Rigidbody2D>().isKinematic);
            GameKernel.actionManager.RunAction(new ActionSequence(gameObject,
                new ActionDelay(gameObject, 0.5f),
                new ActionCallFunc(gameObject, (object obj) =>
                {
                    GameObject go = (GameObject)obj;
                    Debug.Log("V");
                    go.GetComponent<Rigidbody2D>().isKinematic = false;
                    gameObject.GetComponentInChildren<RopePuzzle>().PlayerGetDown(false);
                }, gameObject)
                )
            );
            flag = false;
        }
	}
}
