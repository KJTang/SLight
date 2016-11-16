using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;

public class State {
    public string name = "default";
    public StateMachine stateMachine;

    public virtual void OnEnter() {}
    public virtual void Update() {}
    public virtual void OnExit() {}
}

public class StateMachine {
    public GameObject gameObject;
    public State curState;
    public State lastState;

    private List<State> states = new List<State>();

    public void Init() {
        Assert.IsNotNull(gameObject);
        lastState = curState = null;
    }

    public void AddState(State s) {
        s.stateMachine = this;
        states.Add(s);
    }

    public void RemoveState(State s) {
        states.Remove(s);
    }

    public void ChangeState(string stateName) {
        State newState = null;
        for (int i = 0; i != states.Count; ++i) {
            if (states[i].name == stateName) {
                newState = states[i];
                break;
            }
        }
        Assert.IsNotNull(newState);
        if (curState != null) {
            lastState = curState;
            curState.OnExit();
        }
        curState = newState;
        curState.OnEnter();
    }

    public void Update() {
        if (curState != null) {
            curState.Update();
        }
    }

    public void Destroy() {}
}