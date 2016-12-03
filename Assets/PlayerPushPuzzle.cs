using UnityEngine;
using System.Collections;

public class PlayerPushPuzzle : Puzzle {
    private Rigidbody2D body;
    public float length;
    public float forcex;
	// Use this for initialization
	void Start () {
        body = this.GetComponent<Rigidbody2D>();
        isPermanentChange = true;
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        if (GetTriggerDown())
        {
            body.centerOfMass += new Vector2(0, length / 2);
            body.AddForce(new Vector2(forcex, 0));
        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Ground (16)")
        {

            body.isKinematic = true;
            //Debug.Log("Done");
        }
    }
}
