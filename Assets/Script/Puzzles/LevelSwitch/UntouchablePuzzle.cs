using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class UntouchablePuzzle : Puzzle {
	// Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")//另一物体是player
        {
            //set state
            isTriggered = true;
        }
    }
}
