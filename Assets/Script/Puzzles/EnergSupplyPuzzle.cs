using UnityEngine;
using System.Collections;

public class EnergSupplyPuzzle : Puzzle {
    private float time_count;

    public float time_demand;//需求时间
	// Use this for initialization
	void Start () {
        time_count = 0;
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        if (GetTrigger())
        {
            //Debug.Log(time_count);
            time_count += Time.deltaTime;
        }
        if (time_count <= time_demand)
        {
            isTriggered = false;
        }
        else
        {
            isTriggered = true;
            isPermanentChange = true;
        }
	}
}
