using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class RopeTriggerPuzzle : Puzzle {
    Collider2D collider;

	void Start() {
        isTriggered = false;
        collider = gameObject.GetComponent<Collider2D>();
        Assert.IsNotNull(collider);
    }
	
	void Update() {
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
