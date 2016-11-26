using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class UntouchablePuzzle : Puzzle {
    public Transform player;
	// Use this for initialization
	void Start () {
        Assert.IsNotNull(player);
	}
	// Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")//另一物体是player
        {
            //set state
            isTriggered = true;
        }
    }
}
