using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class RopeTriggerPuzzle : Puzzle {
    Collider2D collider2d;

	void Start() {
        isTriggered = false;
        collider2d = gameObject.GetComponent<Collider2D>();
        Assert.IsNotNull(collider2d);
    }
	
	public override void Update() {
        // will not use default trigger way
        // base.Update();
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            // Debug.Log("enter");
            isTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            // Debug.Log("exit");
            isTriggered = false;
        }
    }
}
