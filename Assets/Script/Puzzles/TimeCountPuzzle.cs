using UnityEngine;
using System.Collections;

public class TimeCountPuzzle : Puzzle {
    public float countSet;
    public bool countFull;
    private float count;
	// Use this for initialization
	void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        if (GetTriggerDown())
        {
            count = 0;
        }
        if (GetTrigger())
        {
            count += Time.deltaTime;
            if (count >= countSet)
            {
                countFull = true;
            }
        }
	}
}
