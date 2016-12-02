using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class ShadowLightPuzzle : LightPuzzle {
    public float offset = 1.2f;

    private GameObject player;
    private PlayerControl script;

    void Start() {
        isTriggered = true;
        player = GameObject.Find("Player");
        Assert.IsNotNull(player);
        script = player.GetComponent<PlayerControl>();
        Assert.IsNotNull(script);
    }
    
    public override void Update() {
        base.Update();
        if (GetTrigger()) {
            ChangeDirection();
        }
    }

    void ChangeDirection() {
        Vector3 relativePos = (new Vector3(player.transform.position.x, offset, player.transform.position.z)) - transform.position;
        // Vector3 relativePos = (player.transform.position + new Vector3(0.0f, offset, 0.0f)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up) * Quaternion.Euler(90.0f, 0.0f, 0.0f);
        transform.rotation = rotation;
    }
}
