using UnityEngine;
using System.Collections;

public class SpecialDoorpuzzle1 : DoorPuzzle {
    public Puzzle p1, p2;
	// Use this for initialization	
	// Update is called once per frame
	public override void Update () {
        if (p1.GetTriggerDown() && !acting)
        {
            OnTriggerDown();
            acting = true;
        }
        else if (p2.GetTriggerDown() && !acting)
        {
            OnTriggerUp();
            acting = true;;
        }
        if (!GameKernel.actionManager.IsRunning(gameObject)) acting = false;
    }
}
