using UnityEngine;
using UnityEngine.Assertions;
using System;
using System.Collections;

public class PlayerShadowControl : MonoBehaviour {
    private GameObject player;
    private Rigidbody2D playerBody;
    private PlayerControl playerScript;
    private StateMachine stateMachine;
    private string curState;

	void Start() {
        player = GameObject.Find("Player");
        Assert.IsNotNull(player);
        playerBody = (Rigidbody2D)player.GetComponent<Rigidbody2D>();
        Assert.IsNotNull(playerBody);
        playerScript = (PlayerControl)player.GetComponent<PlayerControl>();
        Assert.IsNotNull(playerScript);

        stateMachine = new StateMachine();
        stateMachine.gameObject = gameObject;
        stateMachine.Init();
        stateMachine.AddState(new PlayerShadowIdleState());
        stateMachine.AddState(new PlayerShadowWalkState());
        stateMachine.AddState(new PlayerShadowJumpState());
        stateMachine.ChangeState("Idle");

        curState = "Idle";
	}

	void Update() {
        // same animation as Player
        // Debug.Log(playerScript.CurrentState());
        string playerState = playerScript.CurrentState();
        if (curState != playerState) {
            if (playerState == "Jump") {
                if (Math.Abs(playerBody.velocity.x) >= 0.0f) {
                    stateMachine.ChangeState("Walk");
                } else {
                    stateMachine.ChangeState("Idle");
                }
            } else {
                stateMachine.ChangeState(playerState);
            }
            curState = playerState;
        }
        // same direction as Player
        if (player.transform.localScale.x < 0) {
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}
