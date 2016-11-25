using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
public class LevelClearPuzzle : Puzzle {
    public Transform player;
	// Use this for initialization
	void Start () {
        Assert.IsNotNull(player);
	}

    // Update is called once per frame
    public override void Update () {
        base.Update();  
	}
}
