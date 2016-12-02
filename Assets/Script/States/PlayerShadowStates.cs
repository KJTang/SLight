using UnityEngine;
using UnityEngine.Assertions;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerShadowIdleState : State {
    Animator animator;

    public PlayerShadowIdleState() {
        name = "Idle";
    }

    public override void OnEnter() {
        // Debug.Log("Idle OnEnter");
        animator = stateMachine.gameObject.GetComponent<Animator>();
        Assert.IsNotNull(animator);

        animator.SetBool("IsIdling", true);
    }

    public override void Update() {
    }

    public override void OnExit() {
        // Debug.Log("Idle OnExit");
        animator.SetBool("IsIdling", false);
    }
}

public class PlayerShadowWalkState : State {
    Animator animator;

    public PlayerShadowWalkState() {
        name = "Walk";
    }

    public override void OnEnter() {
        // Debug.Log("Walk OnEnter");
        animator = stateMachine.gameObject.GetComponent<Animator>();
        Assert.IsNotNull(animator);

        animator.SetBool("IsWalking", true);
    }

    public override void Update() {
    }

    public override void OnExit() {
        // Debug.Log("Walk OnExit");
        animator.SetBool("IsWalking", false);
    }
}

public class PlayerShadowJumpState : State {
    Animator animator;

    public PlayerShadowJumpState() {
        name = "Jump";
    }

    public override void OnEnter() {
        // Debug.Log("Jump OnEnter");
        animator = stateMachine.gameObject.GetComponent<Animator>();
        Assert.IsNotNull(animator);

        animator.SetBool("IsJumping", true);
    }

    public override void Update() {
    }

    public override void OnExit() {
        // Debug.Log("Jump OnExit");
        animator.SetBool("IsJumping", false);
    }
}
