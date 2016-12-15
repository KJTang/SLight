using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class TrapDestroyer : Puzzle {
    public Puzzle trapPuzzle;
    public Vector3 moveDist = new Vector3(0, 0, 0);
    public float moveTime = 1.0f;
    public bool shouldDestroy = false;

    private bool acting = false;

    void Start() {
        isTriggered = false;
        Assert.IsNotNull(trapPuzzle);
    }
    
    public override void Update() {
        base.Update();
        if (GetTrigger() && !acting) {
            acting = true;
            OnTriggerDown();
        }
        // if (!GetTrigger() && acting) {
        //     acting = false;
        //     OnTriggerUp();
        // }
    }

    void OnTriggerUp() {
        //
    }

    void OnTriggerDown() {
        GameKernel.actionManager.RunAction(new ActionSequence(gameObject, 
            new ActionMoveBy(trapPuzzle.gameObject, moveDist, moveTime), 
            new ActionCallFunc(gameObject, (object obj) => {
                    Debug.Log("Heyheyhey");
                    if (shouldDestroy) {
                        Destroy((GameObject)obj);
                    }
                }, 
                trapPuzzle.gameObject
            )
        ));
    }
}
