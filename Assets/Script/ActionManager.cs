using UnityEngine;
// using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;

public class ActionManager : IGameManager {
    Dictionary<GameObject, Action> actionList = new Dictionary<GameObject, Action>(30);

    public void Init() {}

    public void Update() {
        foreach (GameObject key in new List<GameObject>(actionList.Keys)) {
            Action ac = actionList[key];
            ac.Update();
            if (ac.IsFinished()) {
                ac.Destroy();
                actionList.Remove(key);
            }
        }
    }

    public void Destroy() {}

    public void RunAction(Action ac) {
        GameObject go = ac.GetGameObject();
        if (actionList.ContainsKey(go)) {
            actionList.Remove(go);
        }
        actionList.Add(go, ac);
        ac.Init();
    }
}