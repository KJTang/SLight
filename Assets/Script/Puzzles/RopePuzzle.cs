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
    public string spriteLayer = "ForeGround";
    public Vector3 spriteScale = new Vector3(1f, 3f, 1f);
    public int grabPos = 0;
    public GameObject grabTrigger;
    public float reGrabDelay= 1.5f;

    private List<GameObject> rope;
    private bool isGrabbing = false;
    private Joint2D grabJoint;

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
            BoxCollider2D collider = seg.AddComponent<BoxCollider2D>();
            collider.size = segSize;
            // HingeJoint2D joint = seg.AddComponent<HingeJoint2D>();
            // FixedJoint2D joint = seg.AddComponent<FixedJoint2D>();
            DistanceJoint2D joint = seg.AddComponent<DistanceJoint2D>();
            joint.distance = 0.01f;
            body.useAutoMass = false;
            body.mass = segMass;
            // collider.size = segSize;
            joint.connectedBody = rope[i].GetComponent<Rigidbody2D>();
            seg.layer = LayerMask.NameToLayer("rope");
            // Segment Sprite
            GameObject segSprite = new GameObject();
            segSprite.transform.parent = seg.transform;
            segSprite.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            SpriteRenderer renderer = segSprite.AddComponent<SpriteRenderer>();

            //Rigidbody2D rid2d = segSprite.AddComponent<Rigidbody2D>();
            //BoxCollider2D b2d = segSprite.AddComponent<BoxCollider2D>();
            segSprite.GetComponent<SpriteRenderer>().sortingLayerName = spriteLayer;
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
                PlayerGetDown();
            }
        }
    }

    void OnTriggerDown() {
        PlayerGetUp();
    }

    void PlayerGetUp() {
        GameObject player = GameObject.Find("Player");
        Assert.IsNotNull(player);
        player.GetComponent<PlayerControl>().isPlayerClimbingRope = true;
        GameObject grabSeg = rope[grabPos];
        player.transform.position = grabSeg.transform.position;
        grabJoint = grabSeg.AddComponent<FixedJoint2D>();
        grabJoint.connectedBody = player.GetComponent<Rigidbody2D>();
        isGrabbing = true;

        grabTrigger.SetActive(false);
    }

    public void PlayerGetDown(bool canReGetUp = true) {
        Destroy(grabJoint);
        isGrabbing = false;

        if (canReGetUp) {
            GameKernel.actionManager.RunAction(new ActionSequence(gameObject, 
                new ActionDelay(gameObject, reGrabDelay), 
                new ActionCallFunc(gameObject, (object obj) => {
                    GameObject go = (GameObject)obj;
                    go.SetActive(true);
                    }, grabTrigger)
                )
            );
        } else {
            grabTrigger.SetActive(false);
        }

        GameObject player = GameObject.Find("Player");
        Assert.IsNotNull(player);
        player.GetComponent<PlayerControl>().isPlayerClimbingRope = false;
    }
}
