using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
public class LadderPuzzle : Puzzle {
    public Puzzle p1, p2;
    public Puzzle Up, Down;
    public Transform player;
    public float length, time;
    //p1 is downside ,p2 is upside;
	// Use this for initialization
	void Start () {
        Assert.IsNotNull(player);
	}
	
	// Update is called once per frame
	public override void Update () {
        Up.isTriggered = false;
        Down.isTriggered = false;
        if (p1.GetTriggerDown()&&!GameKernel.actionManager.IsRunning(player.gameObject))
        {
            Debug.Log("p1 is running");
            Down.isTriggered = true;
            Debug.Log(Down.isTriggered);
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            player.GetComponent<PlayerControl>().enableMove = false;
            GameKernel.actionManager.RunAction(new ActionSequence(player.gameObject,
                new ActionMoveBy(player.gameObject, new Vector3(0, -length, 0), time),
                new ActionCallFunc(player.gameObject, (object obj) =>
                {
                    player.GetComponent<PlayerControl>().enableMove = true;
                    player.GetComponent<Rigidbody2D>().isKinematic = false;
                    //Debug.Log("run ac2");
                })
                )
            );
        }
        if (p2.GetTriggerDown() && !GameKernel.actionManager.IsRunning(player.gameObject))
        {
            Up.isTriggered = true;
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            player.GetComponent<PlayerControl>().enableMove = false;
            GameKernel.actionManager.RunAction(new ActionSequence(player.gameObject,
                new ActionMoveBy(player.gameObject, new Vector3(0, length, 0), time),
                new ActionCallFunc(player.gameObject, (object obj) =>
                {
                    player.GetComponent<PlayerControl>().enableMove = true;
                    player.GetComponent<Rigidbody2D>().isKinematic = false;
                    //Debug.Log("run ac2");
                })
                )
            );
        }
        if(Down.isTriggered)Debug.Log(Down.isTriggered);
    }
}
