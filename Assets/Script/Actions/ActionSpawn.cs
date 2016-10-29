using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionSpawn : Action {
    private List<Action> actions;

    public ActionSpawn(GameObject go, params Action[] ac) {
        gameObject = go;
        actions = new List<Action>(ac);
    }

    public override void Init() {
        foreach (Action action in actions) {
            action.Init();
        }
    }

    public override void Update() {
        if (actions.Count == 0) {
            isFinished = true;
        } else {
            for (int i = 0; i != actions.Count; ) {
                actions[i].Update();
                if (actions[i].IsFinished()) {
                    actions[i].Destroy();
                    actions.RemoveAt(i);
                } else {
                    ++i;
                }
            }
        }
    }

    public override void Destroy() {}
}
