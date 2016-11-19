using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using System;
using System.Collections.Generic;

public class ClambPuzzle : Puzzle
{//
    public Transform player;
    private GameObject sprite;//人物的形体
    public Vector3 v;//要移动到的地点
    // Use this for initialization
    void Start()
    {
        Assert.IsNotNull(player);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (GetTriggerDown()&&player.position.y<transform.position.y)
        {
            player.position = v;
            GameKernel.inputManager.Enable = false;
            //播放动画

            //播放完毕
            GameKernel.inputManager.Enable = true;
        }
    }
}
