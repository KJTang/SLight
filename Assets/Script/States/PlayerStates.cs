using UnityEngine;
using UnityEngine.Assertions;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerIdleState : State {
    Animator animator;

    public PlayerIdleState() {
        name = "Idle";
    }

    public override void OnEnter() {
        // Debug.Log("Idle OnEnter");
        animator = stateMachine.gameObject.GetComponent<Animator>();
        Assert.IsNotNull(animator);
        animator.SetBool("IsWalking", false);
    }

    public override void Update() {
        // Walk
        if (GameKernel.inputManager.GetKey(InputKey.Left) || GameKernel.inputManager.GetKey(InputKey.Right)) {
            stateMachine.ChangeState("Walk");
            return;
        }
    }

    public override void OnExit() {
        // Debug.Log("Idle OnExit");
    }
}

public class PlayerWalkState : State {
    Animator animator;

    public PlayerWalkState() {
        name = "Walk";
    }

    public override void OnEnter() {
        // Debug.Log("Walk OnEnter");
        animator = stateMachine.gameObject.GetComponent<Animator>();
        Assert.IsNotNull(animator);
        animator.SetBool("IsWalking", true);
    }

    public override void Update() {
        // Idle
        if (!GameKernel.inputManager.GetKey(InputKey.Left) && !GameKernel.inputManager.GetKey(InputKey.Right)) {
            stateMachine.ChangeState("Idle");
            return;
        }
        // still Walk
        Vector2 velocity = stateMachine.gameObject.GetComponent<Rigidbody2D>().velocity;
        Vector3 scale = stateMachine.gameObject.transform.localScale;
        if (velocity.x >= 0.0f) {
            stateMachine.gameObject.transform.localScale = new Vector3(Math.Abs(scale.x), scale.y, scale.z);
        } else {
            stateMachine.gameObject.transform.localScale = new Vector3(-Math.Abs(scale.x), scale.y, scale.z);
        }
    }

    public override void OnExit() {
        // Debug.Log("Walk OnExit");
    }
}