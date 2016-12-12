using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class ReflectLightPuzzle : LightPuzzle {
    void Start() {
        isTriggered = false;
    }
    
    public override void Update() {
        base.Update();
        // ShotLight();
    }
}
