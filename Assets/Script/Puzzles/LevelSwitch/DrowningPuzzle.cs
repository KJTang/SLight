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

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(count + "start");
        if (other.tag == "Player")//另一物体是player
        {
            count = 0;
            //Debug.Log(count+"start");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")//另一物体是player
        {
            //set state
            //Debug.Log(count + "counting");
            count += Time.deltaTime;
            if (count >= Timelimit) isTriggered = true;
        }
    }
}
