using UnityEngine;
using UnityEngine.Assertions;
using System;

public class BoxPuzzle : Puzzle
{
    private Vector2 maxSpeed;
    private float moveImpulse = 0.2f;
    public Transform player;
    private Rigidbody2D body; 
    void Start()
    {
        Assert.IsNotNull(player);
        gameObject.GetComponent<Rigidbody2D>().mass = 150;
        maxSpeed = player.GetComponent<PlayerControl>().maxSpeed;
        moveImpulse = player.GetComponent<PlayerControl>().moveImpulse;
        body = gameObject.GetComponent<Rigidbody2D>();
        //gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public override void Update()
    {
        base.Update();
        if (GetTriggerDown()) {
            if (player.position.x < transform.position.x) {
                if (player.localScale.x < 0) {
                    player.localScale = new Vector3(-player.localScale.x, player.localScale.y, player.localScale.z);
                }
                player.GetComponent<PlayerControl>().isPlayerPushingLeft = true;
            } else {
                if (player.localScale.x > 0) {
                    player.localScale = new Vector3(-player.localScale.x, player.localScale.y, player.localScale.z);
                }
                player.GetComponent<PlayerControl>().isPlayerPushingRight = true;
            }
        }
        if (GetTrigger()) {
            if (Math.Abs(body.velocity.x) <= maxSpeed.x) {
                if (GameKernel.inputManager.GetKey(InputKey.Left)) {
                    body.AddForce(new Vector2(-100*moveImpulse, 0.0f), ForceMode2D.Impulse);
                }
                if (GameKernel.inputManager.GetKey(InputKey.Right)) {
                    body.AddForce(new Vector2(100*moveImpulse, 0.0f), ForceMode2D.Impulse);
                }
            }   
        } 
        if (GetTriggerUp()) {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
            player.GetComponent<PlayerControl>().isPlayerPushingLeft = false;
            player.GetComponent<PlayerControl>().isPlayerPushingRight = false;
        }
        // if (GetTriggerUp())
        // {
        //     //gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        //     transform.rotation = new Quaternion(0,0,0,0);//排除移动箱子以后不能左右跳跃的bug
        // }
    }
}
