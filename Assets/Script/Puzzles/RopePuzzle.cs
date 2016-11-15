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
    public int grabPos = 0;
    public GameObject grabTrigger;

    private List<GameObject> rope;
    private bool isGrabbing = false;

    void Start() {
        Assert.IsNotNull(sprite);
        Assert.IsNotNull(grabTrigger);

        rope = new List<GameObject>(length);
        GameObject point = new GameObject();
        point.transform.parent = transform;
        point.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        Rigidbody2D pointBody = point.AddComponent<Rigidbody2D>();
        pointBody.isKinematic = true;
        rope.Add(point);

        for (int i = 0; i != length; ++i) {
            // Rope Segment
            GameObject seg = new GameObject();
            seg.transform.parent = transform;
            seg.transform.localPosition = new Vector3(0.0f, -offset * (i + 1), 0.0f);
            Rigidbody2D body = seg.AddComponent<Rigidbody2D>();
            // BoxCollider2D collider = seg.AddComponent<BoxCollider2D>();
            // HingeJoint2D joint = seg.AddComponent<HingeJoint2D>();
            DistanceJoint2D joint = seg.AddComponent<DistanceJoint2D>();
            joint.distance = 0.01f;
            body.useAutoMass = false;
            body.mass = segMass;
            // collider.size = segSize;
            joint.connectedBody = rope[i].GetComponent<Rigidbody2D>();
            // Segment Sprite
            GameObject segSprite = new GameObject();
            segSprite.transform.parent = seg.transform;
            segSprite.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            SpriteRenderer renderer = segSprite.AddComponent<SpriteRenderer>();
            renderer.sprite = sprite;
            renderer.transform.localScale = spriteScale;

            rope.Add(seg);
        }

        Assert.IsTrue(grabPos <= rope.Count);
        grabTrigger.transform.parent = rope[grabPos].transform;
    }
    
    public override void Update() {
        if (!isGrabbing) {
            base.Update();
            if (GetTriggerDown()) {
                OnTriggerDown();
            }
        } else {
            if (GameKernel.inputManager.GetKeyDown(InputKey.Jump)) {
                Destroy(rope[grabPos].GetComponent<FixedJoint2D>());
                isGrabbing = false;
            }
        }
    }

    void OnTriggerDown() {
        GameObject player = GameObject.Find("Player");
        Assert.IsNotNull(player);
        GameObject grabSeg = rope[grabPos];
        player.transform.position = grabSeg.transform.position;
        FixedJoint2D joint = grabSeg.AddComponent<FixedJoint2D>();
        joint.connectedBody = player.GetComponent<Rigidbody2D>();
        isGrabbing = true;
    }
}
