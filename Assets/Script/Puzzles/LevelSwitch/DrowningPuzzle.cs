using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
public class DrowningPuzzle : Puzzle {
    private float count;

    public float Timelimit;
    public Transform player;
	// Use this for initialization
	void Start () {
        Assert.IsNotNull(player);
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")//另一物体是player
        {
            count = 0;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "player")//另一物体是player
        {
            //set state
            count += Time.deltaTime;
            if (count >= Timelimit) isTriggered = true;
        }
    }
}
