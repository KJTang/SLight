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
        animator.SetBool("IsIdling", true);
    }

    public override void Update() {
        // Jump
        if (GameKernel.inputManager.GetKey(InputKey.Jump)) {
            stateMachine.ChangeState("Jump");
            return;
        }
        // Walk
        if (GameKernel.inputManager.GetKey(InputKey.Left) || GameKernel.inputManager.GetKey(InputKey.Right)) {
            stateMachine.ChangeState("Walk");
            return;
        }
    }

    public override void OnExit() {
        // Debug.Log("Idle OnExit");
        animator.SetBool("IsIdling", false);
    }
}

public class PlayerWalkState : State {
    Animator animator;
    Rigidbody2D body;
    PlayerControl script;

    public PlayerWalkState() {
        name = "Walk";
    }

    public override void OnEnter() {
        // Debug.Log("Walk OnEnter");

        animator = stateMachine.gameObject.GetComponent<Animator>();
        Assert.IsNotNull(animator);
        body = stateMachine.gameObject.GetComponent<Rigidbody2D>();
        Assert.IsNotNull(body);
        script = stateMachine.gameObject.GetComponent<PlayerControl>();
        Assert.IsNotNull(script);
        animator.SetBool("IsWalking", true);
    }

    public override void Update() {
        // Jump
        if (GameKernel.inputManager.GetKey(InputKey.Jump)) {
            stateMachine.ChangeState("Jump");
            return;
        }
        Vector2 velocity = stateMachine.gameObject.GetComponent<Rigidbody2D>().velocity;
        // Idle
        if (!GameKernel.inputManager.GetKey(InputKey.Left) && 
            !GameKernel.inputManager.GetKey(InputKey.Right)) {
            stateMachine.ChangeState("Idle");
            return;
        }
        // still Walk
        Vector3 scale = stateMachine.gameObject.transform.localScale;
        if (velocity.x >= 0.0f) {
            stateMachine.gameObject.transform.localScale = new Vector3(Math.Abs(scale.x), scale.y, scale.z);
        } else {
            stateMachine.gameObject.transform.localScale = new Vector3(-Math.Abs(scale.x), scale.y, scale.z);
        }
        // Impulse
        if (Math.Abs(body.velocity.x) <= script.maxSpeed.x) {
            if (GameKernel.inputManager.GetKey(InputKey.Left)) {
                body.AddForce(new Vector2(-script.moveImpulse, 0.0f), ForceMode2D.Impulse);
            }
            if (GameKernel.inputManager.GetKey(InputKey.Right)) {
                body.AddForce(new Vector2(script.moveImpulse, 0.0f), ForceMode2D.Impulse);
            }
        }
    }

    public override void OnExit() {
        // Debug.Log("Walk OnExit");
        animator.SetBool("IsWalking", false);
    }
}

public class PlayerJumpState : State {
    Animator animator;
    Collider2D collider;
    Rigidbody2D body;
    PlayerControl script;

    public PlayerJumpState() {
        name = "Jump";
    }

    public override void OnEnter() {
        // Debug.Log("Jump OnEnter");

        animator = stateMachine.gameObject.GetComponent<Animator>();
        Assert.IsNotNull(animator);
        collider = stateMachine.gameObject.GetComponent<Collider2D>();
        Assert.IsNotNull(collider);
        body = stateMachine.gameObject.GetComponent<Rigidbody2D>();
        Assert.IsNotNull(body);
        script = stateMachine.gameObject.GetComponent<PlayerControl>();
        Assert.IsNotNull(script);
        animator.SetBool("IsJumping", true);
        if (Math.Abs(body.velocity.y) <= script.maxSpeed.y) {
            body.AddForce(new Vector2(0.0f, script.jumpImpulse), ForceMode2D.Impulse);
        }
    }

    public override void Update() {
        // Idle
        if (collider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            stateMachine.ChangeState("Idle");
            return;
        }
        // still Jump
        Vector3 scale = stateMachine.gameObject.transform.localScale;
        // Impulse
        if (Math.Abs(body.velocity.x) <= script.maxSpeed.x) {
            if (GameKernel.inputManager.GetKey(InputKey.Left)) {
                body.AddForce(new Vector2(-script.moveImpulse, 0.0f), ForceMode2D.Impulse);
                stateMachine.gameObject.transform.localScale = new Vector3(-Math.Abs(scale.x), scale.y, scale.z);
            }
            if (GameKernel.inputManager.GetKey(InputKey.Right)) {
                body.AddForce(new Vector2(script.moveImpulse, 0.0f), ForceMode2D.Impulse);
                stateMachine.gameObject.transform.localScale = new Vector3(Math.Abs(scale.x), scale.y, scale.z);
            }
        }
    }

    public override void OnExit() {
        // Debug.Log("Jump OnExit");
        animator.SetBool("IsJumping", false);
    }
}