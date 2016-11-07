using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class BoxPuzzle : Puzzle
{
    public Transform player;
    private Vector3 distance;
    static float m;
    void Start()
    {
        m = gameObject.GetComponent<Rigidbody2D>().mass;
        Assert.IsNotNull(player);
    }

    public override void Update()
    {
        Vector2 zero = new Vector2(0, 0);
        base.Update();
        if (GetTriggerDown())
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            gameObject.GetComponent<Rigidbody2D>().mass = 0;
            distance = player.position - transform.position;
            Debug.Log(distance);
        }
        if (GetTrigger())
        {
            transform.position = player.position - distance;           
        }
        if (GetTriggerUp())
        {
            gameObject.GetComponent<Rigidbody2D>().mass = m;
            Debug.Log(gameObject.GetComponent<Rigidbody2D>().mass+"kg");
            gameObject.GetComponent<Rigidbody2D>().velocity = zero;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
