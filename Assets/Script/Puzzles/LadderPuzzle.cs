using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
public class LadderPuzzle : Puzzle {
    public Puzzle p1, p2;
    public Transform player;
    public float length, time;
    //p1 is downside ,p2 is upside;
	// Use this for initialization
	void Start () {
        Assert.IsNotNull(player);
	}
	
	// Update is called once per frame
	public override void Update () {
        if (p1.GetTriggerDown()&&!GameKernel.actionManager.IsRunning(player.gameObject))
        {
            Debug.Log("p2 is running");
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            player.GetComponent<PlayerControl>().enableMove = false;
            GameKernel.actionManager.RunAction(new ActionSequence(player.gameObject,
                new ActionMoveBy(player.gameObject, new Vector3(0, -length, 0), time),
                new ActionCallFunc(player.gameObject, (object obj) =>
                {
                    player.GetComponent<PlayerControl>().enableMove = true;
                    player.GetComponent<Rigidbody2D>().isKinematic = false;
                    Debug.Log("run ac2");
                })
                )
            );
        }
        if (p2.GetTriggerDown() && !GameKernel.actionManager.IsRunning(player.gameObject))
        {
            Debug.Log("p2 is running");
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            player.GetComponent<PlayerControl>().enableMove = false;
            GameKernel.actionManager.RunAction(new ActionSequence(player.gameObject,
                new ActionMoveBy(player.gameObject, new Vector3(0, length, 0), time),
                new ActionCallFunc(player.gameObject, (object obj) =>
                {
                    player.GetComponent<PlayerControl>().enableMove = true;
                    player.GetComponent<Rigidbody2D>().isKinematic = false;
                    Debug.Log("run ac2");
                })
                )
            );
        }
	}
}
