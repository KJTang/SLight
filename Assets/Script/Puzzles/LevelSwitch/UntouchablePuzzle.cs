using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class UntouchablePuzzle : Puzzle {
    // Update is called once per frame
    Collider2D c;
    void Start()
    {
        c = gameObject.GetComponent<PolygonCollider2D>();
        if (c)
        {
            c.isTrigger = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")//另一物体是player
        {
            //set state
            isTriggered = true;
        }
    }
}
