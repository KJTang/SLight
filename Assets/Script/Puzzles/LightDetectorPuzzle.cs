using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;

public struct LightInfo {
    public string name;
    public Vector3 eulerAngles;
    public LayerMask raycastLayer;
    public Vector2 hitPoint;
}

public class LightDetectorPuzzle : Puzzle {
    protected Dictionary<GameObject, LightInfo> lights = new Dictionary<GameObject, LightInfo>();

    void Start() {
        isTriggered = false;
    }
    
    public override void Update() {
        // base.Update();
        isTriggered = (lights.Count != 0);
    }

    public virtual void AddLightPoint(GameObject light, LightInfo info) {
        lights[light] = info;
    }

    public virtual void RemoveLightPoint(GameObject light) {
        lights.Remove(light);
    }
}
