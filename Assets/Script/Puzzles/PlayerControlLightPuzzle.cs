using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class PlayerControlLightPuzzle : LightPuzzle {
    private GameObject player;
    private PlayerControl script;

    void Start() {
        isTriggered = false;
        player = GameObject.Find("Player");
        Assert.IsNotNull(player);
        script = player.GetComponent<PlayerControl>();
        Assert.IsNotNull(script);
    }
    
    public override void Update() {
        base.Update();
        if (GetTriggerDown()) {
            script.enableMove = false;
        }
        if (GetTrigger()) {
            ChangeDirection();
        }
        if (GetTriggerUp()) {
            script.enableMove = true;
        }
    }

    void ChangeDirection() {
        Vector3 angle = transform.localEulerAngles;
        if (GameKernel.inputManager.GetKey(InputKey.Left)) {
            transform.localEulerAngles = new Vector3(angle.x, angle.y, angle.z > 360.0f ? angle.z - 359.0f : angle.z + 1.0f);
        } else if (GameKernel.inputManager.GetKey(InputKey.Right)) {
            transform.localEulerAngles = new Vector3(angle.x, angle.y, angle.z < 0.0f ? angle.z + 359.0f : angle.z - 1.0f);
        }
    }
}
