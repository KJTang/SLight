using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionSequence : Action {
    private List<Action> actions;
    private int current = 0;

    public ActionSequence(GameObject go, params Action[] ac) {
        gameObject = go;
        actions = new List<Action>(ac);
        if (actions.Count > 0) {
            actions[0].Init();
        }
    }

    public override void Init() {}

    public override void Update() {
        if (current == actions.Count) {
            isFinished = true;
        } else {
            actions[current].Update();
            if (actions[current].IsFinished()) {
                actions[current].Destroy();
                ++current;
                if (current != actions.Count) {
                    actions[current].Init();
                }
            }
        }
    }

    public override void Destroy() {}
}
