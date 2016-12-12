using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
public class FallFailedPuzzle : Puzzle {
    //public Transform player;
    // Use this for initialization
    void Start()
    {
     //   Assert.IsNotNull(player);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")//另一物体是player
        {
            isTriggered = true;
        }
    }

}
