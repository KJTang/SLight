using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class ButtonPuzzle : Puzzle {
    Transform sprite;
    private Vector3 Init_position;
    public Vector3 Moved_position;
    void Start() {
        Init_position = transform.position;
        //sprite = transform.Find("Sprite");
        sprite = transform.GetChild(0);
        Debug.Log(sprite);
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
        GameKernel.actionManager.RunAction(new ActionMoveTo(sprite.gameObject, Moved_position, 0.1f));
    }

    void OnTriggerUp() {
        GameKernel.actionManager.RunAction(new ActionMoveTo(sprite.gameObject, Init_position, 0.1f));
    }
}
