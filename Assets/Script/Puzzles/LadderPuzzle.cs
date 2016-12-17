using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
public class LadderPuzzle : Puzzle {
    //p1 is downside ,p2 is upside;
    public Puzzle p1, p2;
    public Transform player;
    public float length, time;

    private Animator playerAnimator;

	// Use this for initialization
	void Start () {
        Assert.IsNotNull(player);
        playerAnimator = player.GetComponent<Animator>();
        Assert.IsNotNull(playerAnimator);
	}
	
	// Update is called once per frame
	public override void Update () {
        if (p1.GetTriggerDown()&&!GameKernel.actionManager.IsRunning(player.gameObject))
        {
            // Debug.Log("p1 is running");
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            player.GetComponent<BoxCollider2D>().isTrigger = true;
            player.GetComponent<PlayerControl>().enableMove = false;
            player.GetComponent<PlayerControl>().isPlayerClimbingLadder = true;
            GameKernel.actionManager.RunAction(new ActionSequence(player.gameObject,
                new ActionMoveBy(player.gameObject, new Vector3(0, -length, 0), time),
                new ActionCallFunc(player.gameObject, (object obj) =>
                {
                    player.GetComponent<PlayerControl>().enableMove = true;
                    player.GetComponent<Rigidbody2D>().gravityScale = 1;
                    player.GetComponent<PlayerControl>().isPlayerClimbingLadder = false;
                    player.GetComponent<BoxCollider2D>().isTrigger = false;
                })
                )
            );
        }
        if (p2.GetTriggerDown() && !GameKernel.actionManager.IsRunning(player.gameObject))
        {
            // Debug.Log("p2 is running");
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            player.GetComponent<BoxCollider2D>().isTrigger = true;
            player.GetComponent<PlayerControl>().enableMove = false;
            player.GetComponent<PlayerControl>().isPlayerClimbingLadder = true;
            Debug.Log(player.GetComponent<PlayerControl>().isPlayerClimbingLadder);
            GameKernel.actionManager.RunAction(new ActionSequence(player.gameObject,
                new ActionMoveBy(player.gameObject, new Vector3(0, length, 0), time),
                new ActionCallFunc(player.gameObject, (object obj) =>
                {
                    player.GetComponent<PlayerControl>().enableMove = true;
                    player.GetComponent<BoxCollider2D>().isTrigger = false;
                    player.GetComponent<Rigidbody2D>().gravityScale = 1;
                    player.GetComponent<PlayerControl>().isPlayerClimbingLadder = false;
                })
                )
            );
        }
    }
}
