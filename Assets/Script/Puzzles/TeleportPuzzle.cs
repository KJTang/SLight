using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using System;
using System.Collections.Generic;


public enum state
{
    Locked,
    UnLocked,
};

public class TeleportPuzzle : Puzzle
{//连接谜题：0：player(PuzzleType:RANGE_IN)，1：another teleport（PuzzleType：SWITCH_OFF）。TriggerType.AND
    public Transform player;
    private Vector3 v;//与传送器的相对位置
    private bool f = false;
    // Use this for initialization
    static state t_state = state.UnLocked;
    void Start () {
        Assert.IsNotNull(player);
    }
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        if (GetTriggerDown())
        {   
            v = player.position - transform.position;
        }

        if (GetTrigger()&& t_state == state.UnLocked)
        {
            player.position = puzzles[1].transform.position + v;
            t_state = state.Locked;
            f = true;
        }
        if ((Math.Abs(player.position.x - puzzles[1].transform.position.x) > range.x ||
            Math.Abs(player.position.y - puzzles[1].transform.position.y) > range.y) &&
            f == true)
        {
            t_state = state.UnLocked;
            f = false;
        }
        }
}
