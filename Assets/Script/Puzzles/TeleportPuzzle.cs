using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using System;
using System.Collections.Generic;


public class TeleportPuzzle : Puzzle
{
    public Transform player;
    public Transform destination;

    private bool flag = false;
    void Start () {
        Assert.IsNotNull(player);
        Assert.IsNotNull(destination);
    }
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        if (GetTriggerDown()&&flag == false)
        {
            GameKernel.inputManager.Enable = false;
            GameKernel.actionManager.RunAction(new ActionSequence(gameObject,
                new ActionDelay(gameObject, 0.5f),
                new ActionCallFunc(player.gameObject, (object obj) =>
                {
                    GameObject go = (GameObject)obj;
                    go.transform.position = destination.position;
                    GameKernel.inputManager.Enable = true;
                }, player.gameObject)
                
                )
            );
            //Debug.Log(GameKernel.inputManager.Enable);
            destination.gameObject.GetComponent<TeleportPuzzle>().flag = true;
        }
        if (GetTriggerUp())
        {
            flag = false;
        }
        }
}
