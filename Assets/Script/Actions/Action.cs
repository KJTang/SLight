using UnityEngine;
using System.Collections;

public class Action {
    protected GameObject gameObject;
    protected bool isFinished = false;

    public virtual void Init() {}

    public virtual void Update() {}
    
    public virtual void Destroy() {}
    
    public GameObject GetGameObject() {
        return gameObject;
    }

    public bool IsFinished() {
        return isFinished;
    }
}
