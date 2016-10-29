using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class DoorPuzzle : Puzzle {
    Transform sprite;

    void Start() {
        sprite = transform.Find("Sprite");
        Assert.IsNotNull(sprite);
    }
    
    public override void Update() {
        base.Update();
        if (GetTriggerDown()) {
            OnTriggerDown();
        } else if (GetTriggerUp()) {
            OnTriggerUp();
        }
    }

    void OnTriggerDown() {
        GameKernel.actionManager.RunAction(new ActionMoveTo(gameObject, new Vector3(3.0f, 2.0f, 0.0f), 15.0f));
    }

    void OnTriggerUp() {
        GameKernel.actionManager.RunAction(new ActionMoveTo(gameObject, new Vector3(3.0f, -2.75f, 0.0f), 2.0f));
    }
}
