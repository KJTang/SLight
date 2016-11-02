using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class BoxPuzzle : Puzzle {
    public Transform player;
    private Vector3 distance;

    void Start() {
        Assert.IsNotNull(player);
    }
    
    public override void Update() {
        base.Update();

        if (GetTriggerDown()) {
            distance = player.position - transform.position;
            Debug.Log(distance);
        }
        if (GetTrigger()) {
            transform.position = player.position - distance;
        }
    }
}
