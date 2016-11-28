using UnityEngine;
using UnityEngine.Assertions;
using System;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    private Rigidbody2D body;
    private Collider2D collider;
    private StateMachine stateMachine;

    public Vector2 maxSpeed = new Vector2(3.0f, 3.0f);
    public float moveImpulse = 0.2f;
    public float jumpImpulse = 5.0f;
    public float jumpInAirImpulse = 8.0f;

    public bool enableMove = true;

	void Start() {
        body = (Rigidbody2D)gameObject.GetComponent<Rigidbody2D>();
        collider = (Collider2D)gameObject.GetComponent<Collider2D>();
        Assert.IsNotNull(body);
        Assert.IsNotNull(collider);

        stateMachine = new StateMachine();
        stateMachine.gameObject = gameObject;
        stateMachine.Init();
        stateMachine.AddState(new PlayerIdleState());
        stateMachine.AddState(new PlayerWalkState());
        stateMachine.AddState(new PlayerJumpState());
        stateMachine.ChangeState("Idle");
    }
	
	void Update() {
        // Debug.Log(body.velocity.y);
        DoMove();
        DoAction();

        if (enableMove) {
            stateMachine.Update();
        } else {
            stateMachine.ChangeState("Idle");
        }
	}

    void OnDestroy() {
        stateMachine.Destroy();
    }
    
    void DoMove() {
        if (enableMove) {
            Vector3 scale = stateMachine.gameObject.transform.localScale;
            if (GameKernel.inputManager.GetKey(InputKey.Left)) {
                transform.localScale = new Vector3(-Math.Abs(scale.x), scale.y, scale.z);
            }
            if (GameKernel.inputManager.GetKey(InputKey.Right)) {
                transform.localScale = new Vector3(Math.Abs(scale.x), scale.y, scale.z);
            }
        }
    }

    void DoAction() {
        // if (GameKernel.inputManager.GetKeyDown(InputKey.Jump) && body.velocity.y == 0) {
        //     body.AddForce(new Vector2(0.0f, jumpImpulse), ForceMode2D.Impulse);
        // }
    }
}
