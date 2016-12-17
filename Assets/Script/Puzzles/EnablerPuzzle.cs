using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class EnablerPuzzle : Puzzle {
    public GameObject target;

    private bool acting = false;

    void Start () {
        target.SetActive(false);
        isTriggered = false;
    }

    public override void Update () {
        base.Update();
        if (GetTrigger() && !acting) {
            acting = true;
            OnTriggerDown();
        }
        if (!GetTrigger() && acting) {
            acting = false;
            OnTriggerUp();
        }
    }

    void OnTriggerDown() {
        if (target != null) {
            target.SetActive(true);
        }
    }

    void OnTriggerUp() {
        if (target != null) {
            target.SetActive(false);
        }
    }
}
