using UnityEngine;
using System.Collections;

public class PlayerActionPuzzle : Puzzle {

    void Start() {
        isTriggered = false;
    }
	
    public override void Update() {
        // will not use default trigger way
        // base.Update();
        isTriggered = GameKernel.inputManager.GetKey(InputKey.Action);
    }
}
