using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class ButtonPuzzle : Puzzle {
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
        GameKernel.actionManager.RunAction(new ActionMoveTo(sprite.gameObject, new Vector3(-5.0f, -5.0f, 0.0f), 0.1f));
    }

    void OnTriggerUp() {
        GameKernel.actionManager.RunAction(new ActionMoveTo(sprite.gameObject, new Vector3(-5.0f, -4.0f, 0.0f), 0.1f));
    }
}
