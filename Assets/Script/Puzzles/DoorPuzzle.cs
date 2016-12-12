using UnityEngine;
using UnityEngine.Assertions;

public class DoorPuzzle : Puzzle {
    private bool acting = false;
    private Vector3 Init_position;
    public Vector3 Moved_position;
    void Start() {
        //sprite = transform.Find("Sprite");
        //Assert.IsNotNull(sprite);
        Init_position = transform.position;
    }
    
    public override void Update() {
        base.Update();
        if (GetTrigger() && !acting) {
            OnTriggerDown();
            acting = true;
        } else if (!GetTrigger() && acting) {
            OnTriggerUp();
            acting = false;
        }
        // if (GetTriggerDown()) {
        //     OnTriggerDown();
        // } else if (GetTriggerUp()) {
        //     OnTriggerUp();
        // }
    }

    void OnTriggerDown() {
        Debug.Log("++++++");
        GameKernel.actionManager.RunAction(new ActionMoveBy(gameObject, Moved_position, 15.0f));
    }

    void OnTriggerUp() {
        Debug.Log("------");
        GameKernel.actionManager.RunAction(new ActionMoveTo(gameObject, Init_position, 2.0f));
    }
}
