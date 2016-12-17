using UnityEngine;
using System.Collections;

public class AreaPuzzle : Puzzle {
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")//另一物体是player
        {
            //set state
            isTriggered = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")//另一物体是player
        {
            //set state
            isTriggered = false;
        }
    }
}
