using UnityEngine;
using UnityEngine.Assertions;

public class DoorPuzzle : Puzzle {
    //Transform sprite;
    private Vector3 Init_position;
    public Vector3 Moved_position;
    void Start() {
        //sprite = transform.Find("Sprite");
        //Assert.IsNotNull(sprite);
        Init_position = transform.position;
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
        GameKernel.actionManager.RunAction(new ActionMoveTo(gameObject, Init_position, 15.0f));
    }

    void OnTriggerUp() {
        GameKernel.actionManager.RunAction(new ActionMoveTo(gameObject, Moved_position, 2.0f));
    }
}
