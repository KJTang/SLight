using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;

public class RopePuzzle : Puzzle {
    public int length = 0;
    public float offset = 0.3f;
    public Vector2 segSize = new Vector2(0.1f, 0.3f);
    public float segMass = 0.1f;
    public Sprite sprite;
    public Vector3 spriteScale = new Vector3(1f, 3f, 1f);
    private List<GameObject> rope;

    void Start() {
        Assert.IsNotNull(sprite);

        rope = new List<GameObject>(length);
        GameObject point = new GameObject();
        // BoxCollider2D pointCollider = point.AddComponent<BoxCollider2D>();
        Rigidbody2D pointBody = point.AddComponent<Rigidbody2D>();
        pointBody.isKinematic = true;
        point.transform.parent = transform;
        point.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        rope.Add(point);
        for (int i = 0; i != length; ++i) {
            GameObject seg = new GameObject();
            Rigidbody2D body = seg.AddComponent<Rigidbody2D>();
            BoxCollider2D collider = seg.AddComponent<BoxCollider2D>();
            HingeJoint2D joint = seg.AddComponent<HingeJoint2D>();
            body.useAutoMass = false;
            body.mass = segMass;
            collider.size = segSize;
            joint.connectedBody = rope[i].GetComponent<Rigidbody2D>();
            seg.transform.parent = transform;
            // Sprite
            GameObject segSprite = new GameObject();
            SpriteRenderer renderer = segSprite.AddComponent<SpriteRenderer>();
            renderer.sprite = sprite;
            renderer.transform.localScale = spriteScale;
            segSprite.transform.parent = seg.transform;

            seg.transform.position = new Vector3(0.0f, -offset * (i + 1), 0.0f);
            rope.Add(seg);
        }
    }
    
    public override void Update() {
        base.Update();
    }
}
